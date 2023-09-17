using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public EditModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        [TempData]
        public string StatusMessageFinal1 { get; set; }


        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string userId = User.Identity.GetUserId();
            ViewData["ClasseId"] = new SelectList(_context.Classe.Where(i => i.EstadoClasse == "A"), "IdClasse", "NomeClasse");

            var descontos = _context.Desconto.Where(i => i.EstadoDesconto == "A").ToList();
            descontos.Insert(0, new Desconto
            {
                CodDesconto = "",
                DescDesconto = "Seleccionar Desconto"

            });

            ViewData["CodDesconto"] = new SelectList(descontos, "CodDesconto", "DescDesconto");


            if (id == null || _context.Inscricao == null)
            {
                return RedirectToPage("./AcessDenied");
            }

            if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
            {
                var inscricao = await _context.Inscricao.Include(i => i.Atleta)
                                                     .FirstOrDefaultAsync(m => m.Id == id);
                if (inscricao == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Inscricao = inscricao;
            }
            else
            {
                var inscricao = await _context.Inscricao.Include(i => i.Atleta)
                                     .FirstOrDefaultAsync(m => m.Id == id && m.Atleta.UtilizadorId == userId);

                if (inscricao == null)
                {
                    return RedirectToPage("./AcessDenied");
                }

                Inscricao = inscricao;
            }
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Obtem EpocaId
            int epocaId = Inscricao.EpocaId;
            // Obtem CodDesconto
            string codDesconto = Inscricao.CodDesconto;
            //obtem dtinscricao
            DateTime dataDia = DateTime.Now;

             //obtem ginasta em estado ativo
            var ginasta = await _context.Ginasta
                                        .FirstOrDefaultAsync(r => r.Id == Inscricao.GinastaId && r.EstadoGinasta == "A");
            if (ginasta == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Ginasta Inativo, deverá ativar para modificar inscrição");
                await OnGetAsync(Inscricao.GinastaId);
                return Page();
            }

            //VALIDA EXAME MÉDICO E VALIDADE 
            if (Inscricao.IExamMed == "S")
            {
                if (Inscricao.DtExamMed.Date <= DateTime.Now.Date)
                {
                    ModelState.AddModelError("Inscricao.DtExamMed", "Só pode ser colocada uma data validade a futuro");
                    await OnGetAsync(Inscricao.GinastaId);
                    return Page();
                }   
            }else
            {
                Inscricao.DtExamMed = DateTime.MinValue;
            }

            //VALIDA FICHA INDIVIDUAL E DATA 
            if (Inscricao.IFicFGP == "S")
            {
                if (Inscricao.DtFicFGP.Date == DateTime.MinValue)
                {
                    ModelState.AddModelError("Inscricao.DtFicFGP", "Data é obrigatória");
                    await OnGetAsync(Inscricao.GinastaId);
                    return Page();
                }
            }
            else
            {
                Inscricao.DtFicFGP = DateTime.MinValue;
            }

            //obtem rubrica
            var rubrica = await _context.Rubrica
                                        .FirstOrDefaultAsync(r => r.ClasseId == Inscricao.ClasseId && r.DescontoId == Inscricao.CodDesconto);
            if (rubrica == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Rúbrica não definida no Preçário");
                await OnGetAsync(Inscricao.GinastaId);
                return Page();
            }
            decimal valorMensalidade = rubrica.ValorUnitario ?? 0m;

            // Valida se a época existe
            var epoca = await _context.Epoca.FindAsync(epocaId);

            if (epoca == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Época não está definida");
                await OnGetAsync(Inscricao.GinastaId);
                return Page();
            }

                // Calcula o número de meses entre a DataInicio e DataFim da época
                int numberOfMonths = (epoca.DataFim.Year - epoca.DataInicio.Year) * 12
                    + epoca.DataFim.Month - epoca.DataInicio.Month;

                //modifica Plano Mensalidade
                for (int i = 0; i <= numberOfMonths; i++)
                {
                    DateTime dataMensalidade = epoca.DataInicio.AddMonths(i);
                    //se ainda não chegamos à data da mensalidade atualiza plano
                    if (dataMensalidade.Date > dataDia.Date)
                    {
                        var planoMensalidade = await _context.PlanoMensalidade
                            .FirstOrDefaultAsync(p => p.GinastaId == Inscricao.GinastaId && p.EpocaId == epocaId && p.DataMensalidade == dataMensalidade);

                        //se for o último mês da época não cobra e coloca o valor da mensalidade a 0
                        if (dataMensalidade.Month == epoca.DataFim.Month &&
                            epoca.ICobrancUltimoMes == "N")
                        {
                            valorMensalidade = 0;
                        }
                        //atualiza plano
                        if (planoMensalidade != null)
                        {
                            // Atualiza Plano
                            planoMensalidade.ValorMensalidade = valorMensalidade;
                            planoMensalidade.DataModificacao = DateTime.Now;
                            planoMensalidade.IdModificacao = User.Identity.GetUserId();
                        }
                    }
                    //se já chegamos à data da mensalidade só atualizamos se ainda não tivermos lançado a cobrança (ILANCADO != "S")
                    //e estivermos no mesmo mês do plano
                    //NÂO vamos atualizar planos que já deviam ter sido lançados em meses anteriores
                    else
                    {

                        var planoMensalidade = await _context.PlanoMensalidade
                            .FirstOrDefaultAsync(p => p.GinastaId == Inscricao.GinastaId && p.EpocaId == epocaId && p.DataMensalidade == dataMensalidade);

                        if (planoMensalidade.ILancado != "S" && planoMensalidade.DataMensalidade.Month == DateTime.Now.Month)
                        {
                            //se for o último mês da época não cobra e coloca o valor da mensalidade a 0
                            if (dataMensalidade.Month == epoca.DataFim.Month)
                            {
                                valorMensalidade = 0;
                            }
                            //atualiza plano
                            if (planoMensalidade != null)
                            {
                                // Atualiza Plano
                                planoMensalidade.ValorMensalidade = valorMensalidade;
                                planoMensalidade.DataModificacao = DateTime.Now;
                                planoMensalidade.IdModificacao = User.Identity.GetUserId();
                            }
                        }
                    }
                }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Inscricao.IdModificacao = User.Identity.GetUserId(); ;
            Inscricao.DataModificacao = DateTime.Now;
                       
            _context.Attach(Inscricao).State = EntityState.Modified;

            try
            {
                // Só é permitido Editar uma inscrição até ao dia anterior ao fim da Epoca
                if (epoca.DataFim >= DateTime.Now)
                {
                    await _context.SaveChangesAsync();
                }
                else
                {
                    StatusMessageFinal1 = " Só é possível editar a época até ao dia anterior à Época Terminar";
                    return RedirectToPage("./Edit", new { id = Inscricao.Id });
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoExists(Inscricao.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = Inscricao.GinastaId });
        }

        private bool InscricaoExists(int? id)
        {
          return (_context.Inscricao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
