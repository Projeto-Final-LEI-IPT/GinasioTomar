using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            ViewData["GinastaId"] = new SelectList(_context.Ginasta.Where(i => i.Id == id), "Id", "ID_DescrGinasta");
            ViewData["EpocaId"] = new SelectList(_context.Epoca.Where(i => i.EstadoEpoca == "A"), "IdEpoca", "NomeEpoca");
            ViewData["ClasseId"] = new SelectList(_context.Classe.Where(i => i.EstadoClasse == "A"), "IdClasse", "NomeClasse");

            var descontos = _context.Desconto.Where(i => i.EstadoDesconto == "A").ToList();
            descontos.Insert(0, new Desconto
            {
                CodDesconto = "",
                DescDesconto = "Seleccionar Desconto"
            });

            ViewData["CodDesconto"] = new SelectList(descontos, "CodDesconto", "DescDesconto");

            ViewData["BackId"] = id;
            return Page();
        }

        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /// Algoritmo para cálculo de Anos entre duas datas
            /// https://stackoverflow.com/questions/4127363/date-difference-in-years-using-c-sharp
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime a = _context.Ginasta.Where(i => i.Id == Inscricao.GinastaId).FirstOrDefault().DtNascim;
            DateTime c = _context.Epoca.Where(i => i.IdEpoca == Inscricao.EpocaId).FirstOrDefault().DataFim;
            DateTime b = new DateTime(c.Year, 8, 31);

            TimeSpan span = b - a;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            int years = (zeroTime + span).Year - 1;

            // Obtem EpocaId
            int epocaId = Inscricao.EpocaId;
            //obtem dtinscricao
            DateTime dtInscricao = Inscricao.DtInscricao;
            //obtem ginasta em estado ativo
            var ginasta = await _context.Ginasta
                                        .FirstOrDefaultAsync(r => r.Id == Inscricao.GinastaId && r.EstadoGinasta =="A");
            if (ginasta == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Ginasta Inativo, deverá ativar para efetuar inscrição");
                OnGet(Inscricao.GinastaId);
                return Page();
            }
            //VALIDA CONSENTIMENTO 
            if (Inscricao.IConsentimento != "S")
            {
                ModelState.AddModelError("Inscricao.IConsentimento", "Só é possivel a inscrição com Consentimento de Dados");
                OnGet(Inscricao.GinastaId);
                return Page();
            }
            //VALIDA DATA CONSENTIMENTO
            if (Inscricao.DtConsentimento.Date != Inscricao.DtInscricao.Date)
            {
                ModelState.AddModelError("Inscricao.DtConsentimento", "Data Consentimento tem de ser a data inscrição");
                OnGet(Inscricao.GinastaId);
                return Page();
            }

            //valida se Ginasta já tem inscrição na Época
            bool JaInscritoEpoca = await _context.Inscricao
                                          .AnyAsync(i => i.GinastaId == Inscricao.GinastaId && i.EpocaId == Inscricao.EpocaId);

            if (JaInscritoEpoca)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Ginasta já está inscrito na época!");
                OnGet(Inscricao.GinastaId);
                return Page();
            }

            //obtem rubrica
            var rubrica = await _context.Rubrica
                                        .FirstOrDefaultAsync(r => r.ClasseId == Inscricao.ClasseId && 
                                                                  r.DescontoId == Inscricao.CodDesconto && 
                                                                  r.EstadoRubrica == "A");
            if (rubrica == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Rúbrica não definida no Preçário ou inativa");
                OnGet(Inscricao.GinastaId);
                return Page();
            }

            decimal valorMensalidade = rubrica.ValorUnitario ?? 0m;

            // Valida se a época existe
            var epoca = await _context.Epoca.FindAsync(epocaId);

            if (epoca == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Época não está definida");
                OnGet(Inscricao.GinastaId);
                return Page();
            }

            DateTime dtIni30 = epoca.DataInicio.AddMonths(-2);

            if (Inscricao.DtInscricao > epoca.DataFim)
            {
                ModelState.AddModelError("Inscricao.DtInscricao", "Data Inscrição não pode ser superior à Data Fim da época");
                OnGet(Inscricao.GinastaId);
                return Page();
            }

            if (Inscricao.DtInscricao < dtIni30)
            {
                ModelState.AddModelError("Inscricao.DtInscricao", "Data Inscrição não pode ser inferior à Data Inicio da época menos 2 meses");
                OnGet(Inscricao.GinastaId);
                return Page();
            }

            if (Inscricao.DtInscricao.Date != DateTime.Now.Date)
            {
                ModelState.AddModelError("Inscricao.DtInscricao", "Data Inscrição tem de ser a data atual");
                OnGet(Inscricao.GinastaId);
                return Page();
            }

            // Calcula o número de meses entre a DataInicio e DataFim da época
            int numberOfMonths = (epoca.DataFim.Year - epoca.DataInicio.Year) * 12
                + epoca.DataFim.Month - epoca.DataInicio.Month;

            // Cria Plano Mensalidade
            for (int i = 0; i <= numberOfMonths; i++)
            {
                DateTime dataMensalidade = epoca.DataInicio.AddMonths(i);
                if (dataMensalidade.Month == dtInscricao.Month || dataMensalidade > dtInscricao)
                {
                    //se for o último mês da época não cobra e coloca o valor da mensalidade a 0
                    if (dataMensalidade.Month   == epoca.DataFim.Month && 
                        epoca.ICobrancUltimoMes == "N")
                    {
                        valorMensalidade = 0;
                    }
                    //cria plano
                    var planoMensalidade = new PlanoMensalidade
                    {
                        DataMensalidade = dataMensalidade,
                        ValorMensalidade = valorMensalidade,
                        DataCriacao = DateTime.Now,
                        IdCriacao = User.Identity.GetUserId(),
                        DataModificacao = DateTime.MinValue,
                        IdModificacao = "",
                        EpocaId = epocaId,
                        GinastaId = Inscricao.GinastaId,
                        ILancado = "N",
                        ValorMensalidadeLanc = 0,
                        IdMovimento = null
                    };
                    _context.PlanoMensalidade.Add(planoMensalidade);
                }
            }

            // LANÇA MOVIMENTOS INICIAIS DE COBRANÇA (INSCRIÇÃO, SEGUROS E OUTROS)
            //obtem rubricas ativas, marcadas como iniciais e com valor unitário > 0
            var rubricasIniciais = await _context.Rubrica.Where(h => h.EstadoRubrica == "A" &&
                                                                h.IPagInscricao == "S" &&
                                                                h.IVlrUnit == "S" &&
                                                                h.ValorUnitario > 0
                                                               ).ToListAsync();
            
            //obtem sociod (id) associado ao ginasta
            var idsocio = _context.Ginasta.Where(k => k.Id == Inscricao.GinastaId).FirstOrDefault().UtilizadorId;

            //obtem saldo (para o sócio)
            var saldo = _context.Saldo.Where(h => h.IdSocio == idsocio).FirstOrDefault();

            //percorre todas as rúbricas e lança os movimentos
            foreach (var rubricaini in rubricasIniciais)
            {
                //atualiza tabela de saldos
                if (rubricaini.TipoMovimento == "D")
                {
                    saldo.MSaldo = saldo.MSaldo - rubricaini.ValorUnitario;
                }
                else if (rubricaini.TipoMovimento == "C")
                {
                    saldo.MSaldo = saldo.MSaldo + rubricaini.ValorUnitario;
                }
                _context.Saldo.Update(saldo);
                Guid IdMovimento = Guid.NewGuid();
                var movimento = new Movimento 
                {
                    Id = IdMovimento,
                    DesRubrica = rubricaini.DescricaoRubrica,
                    DtMovimento = DateTime.Now,
                    ValorMovimento = rubricaini.ValorUnitario,
                    ValorDesconto = 0,
                    NumFatura = "",
                    NumNotaCredito = "",
                    MSaldo = saldo.MSaldo,
                    DataCriacao = DateTime.Now,
                    IdCriacao = User.Identity.GetUserId(),
                    DataModificacao = DateTime.MinValue,
                    IdModificacao = " ",
                    UtilizadorId = idsocio,
                    AtletaMovimentoId = Inscricao.GinastaId,
                    RubricaId = rubricaini.CodRubrica,
                    MetodoPagamentoId = null                  
                };
                _context.Movimento.Add(movimento);
            }

            Inscricao.IdFGP = "";
            Inscricao.IdadeAgosto = years;
            Inscricao.DtExamMed = DateTime.MinValue;
            Inscricao.ILeituraObrig = "N";
            Inscricao.IExamMed = "N";
            Inscricao.DtExamMed = DateTime.MinValue;
            Inscricao.IFicFGP = "N";
            Inscricao.DtFicFGP = DateTime.MinValue;
            Inscricao.ISeguro = "N";
            Inscricao.IPagamInscricao = "N";
            Inscricao.IdCriacao = User.Identity.GetUserId();
            Inscricao.DataCriacao = DateTime.Now;
            Inscricao.IdModificacao = "";
            Inscricao.DataModificacao = DateTime.MinValue;

            if (Inscricao.CodDesconto == null)
            {
                Inscricao.CodDesconto = null;
                ModelState.Remove("Inscricao.CodDesconto"); // Remove validação para o campo CodDesconto que não é visivel
            }

            if (!ModelState.IsValid || _context.Inscricao == null || Inscricao == null)
            {
                return Page();
            }

            _context.Inscricao.Add(Inscricao);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Inscricoes/Ginastas/Index");
        }
    }
}
