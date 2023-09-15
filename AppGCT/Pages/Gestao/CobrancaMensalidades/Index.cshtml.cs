using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppGCT.Pages.Gestao.CobrancaMensalidades
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        [TempData]
        public string StatusMessageFinal { get; set; }
        [TempData]
        public string StatusMessageRub { get; set; }


        public List<DataViewModel> Mensalidades { get; set; } = new List<DataViewModel>();

        public class DataViewModel
        {
            public DateOnly? DataMensalidade { get; set; }
            public Decimal? ValorLancar { get; set; }
            public String? Ginasta { get; set; }
            public String? Socio { get; set; }
        }

        public async Task OnGetAsync()
        {
            var dataCorrente = DateTime.Today.Month;
            // Consultar todos os Sócios Ativos
            var sociosAtivos = await _context.Users.Where(i => i.EstadoUtilizador == "A").ToListAsync();
            foreach (var socioAtivo in sociosAtivos)
            {
                // TODO - Verificar se há QUOTAS a lançar e popular tabela
                if(dataCorrente == 9)
                {

                }
                // Consultar Ginastas Ativos para o Sócio em tratamento
                var ginastasAtivos = await _context.Ginasta.Where(i => i.UtilizadorId == socioAtivo.Id &&
                                                                       i.EstadoGinasta == "A"
                                                                 ).ToListAsync();
                foreach(var ginastaAtivo in ginastasAtivos)
                {
                    // Consultar mensalidades planeadas para o mês corrente e que não tenham sido já lançadas
                    var mensalidades = await _context.PlanoMensalidade.Where(i => i.DataMensalidade.Month == dataCorrente     &&
                                                                                  i.GinastaId             == ginastaAtivo.Id  &&
                                                                                  i.ILancado              == "N"              &&
                                                                                  !i.IdMovimento.HasValue
                                                                              ).ToListAsync();
                    foreach (var mensalidade in mensalidades)
                    {
                        var epocaAtiva = _context.Epoca.Where(i => i.IdEpoca == mensalidade.EpocaId).FirstOrDefault().EstadoEpoca;
                        if(epocaAtiva == "A")
                        {
                            DataViewModel model = new DataViewModel();
                            model.DataMensalidade = DateOnly.FromDateTime(mensalidade.DataMensalidade);
                            model.ValorLancar = mensalidade.ValorMensalidade;
                            model.Ginasta = ginastaAtivo.NomeCompleto;
                            model.Socio = socioAtivo.Nome;
                            Mensalidades.Add(model);
                        }
                    }
                }
            }


        }
        public async Task<IActionResult> OnPost()
        {
            StatusMessageFinal = "Inicialização de controlo";
            var dataCorrente = DateTime.Today.Month;
            // Consultar todos os Sócios Ativos
            var sociosAtivos = await _context.Users.Where(i => i.EstadoUtilizador == "A").ToListAsync();
            foreach (var socioAtivo in sociosAtivos)
            {
                // TODO - Verificar se há QUOTAS a lançar e popular tabela
                if (dataCorrente == 9)
                {

                }
                // Consultar Ginastas Ativos para o Sócio em tratamento
                var ginastasAtivos = await _context.Ginasta.Where(i => i.UtilizadorId == socioAtivo.Id &&
                                                                       i.EstadoGinasta == "A"
                                                                 ).ToListAsync();
                foreach (var ginastaAtivo in ginastasAtivos)
                {
                    // Consultar mensalidades planeadas para o mês corrente e que não tenham sido já lançadas
                    var mensalidades = await _context.PlanoMensalidade.Where(i => i.DataMensalidade.Month == dataCorrente &&
                                                                                  i.GinastaId == ginastaAtivo.Id &&
                                                                                  i.ILancado == "N" &&
                                                                                  !i.IdMovimento.HasValue
                                                                              ).ToListAsync();
                    //TODO - validar se existe mais de uma mensalidade por lançar para o corrente mês, e dar erro se isso acontecer ???
                    foreach (var mensalidade in mensalidades)
                    {
                        var epocaAtiva = _context.Epoca.Where(i => i.IdEpoca == mensalidade.EpocaId).FirstOrDefault();
                        if (epocaAtiva.EstadoEpoca == "A")
                        {
                            // Consultar saldo do sócio, antes de efetivar movimento
                            var saldoAnt = _context.Saldo.Where(i => i.IdSocio == socioAtivo.Id).FirstOrDefault().MSaldo;
                            // Consultar valor da mensalidade
                            //valida se Ginasta já tem inscrição na Época
                            bool JaInscritoEpoca = await _context.Inscricao
                                                          .AnyAsync(i => i.GinastaId == mensalidade.GinastaId && i.EpocaId == mensalidade.EpocaId);

                            if (epocaAtiva.ICobrancUltimoMes == "N" &&
                               epocaAtiva.DataFim.Month == mensalidade.DataMensalidade.Month)
                            {
                                // Atualiza ILancado, ValorMensalidadeLanc e IdMovimento
                                var mensalidadeObj = _context.PlanoMensalidade.FirstOrDefault(s => s.IdPlanoM == mensalidade.IdPlanoM);

                                if (mensalidadeObj != null)
                                {
                                    // Step 3: Modify the properties you want to update
                                    mensalidadeObj.ILancado = "S";

                                    // Step 4: Save the changes back to the database
                                    _context.PlanoMensalidade.Update(mensalidadeObj);

                                }
                                try
                                {
                                    await _context.SaveChangesAsync();
                                    StatusMessageFinal = "Lançamento de movimentos realizado com sucesso";

                                }
                                catch (Exception ex)
                                {
                                    StatusMessageFinal = "Erro de base de dados no lançamento de movimentos - Mensalidade: " +
                                                          mensalidade.IdPlanoM + " Solicitar apoio informático";
                                    return RedirectToPage("./Index");
                                }
                            }
                            else 
                            { 
                                // Se atleta inscrito na epoca da mensalidade em tratamento, vamos lançar o respetivo movimento
                                if (JaInscritoEpoca)
                                {
                                    // Consultar inscrição para buscar Classe e Desconto associado
                                    var incricaoAtiva = _context.Inscricao
                                                              .Where(i => i.GinastaId == mensalidade.GinastaId && i.EpocaId == mensalidade.EpocaId).FirstOrDefault();
                                    //obtem rubrica
                                    var rubrica = await _context.Rubrica
                                                                .FirstOrDefaultAsync(r => r.ClasseId == incricaoAtiva.ClasseId &&
                                                                                     r.DescontoId == incricaoAtiva.CodDesconto);

                                    if (rubrica == null)
                                    {
                                        StatusMessageRub = "Rúbrica associada à inscrição não existe na BD";
                                        return RedirectToPage("./Index");
                                    }
                                    decimal valorMensalidade = rubrica.ValorUnitario ?? 0m;

                                    Guid planoMovimento = Guid.NewGuid();

                                    var movimento = new Movimento
                                    {
                                        Id = planoMovimento,
                                        DesRubrica = rubrica.DescricaoRubrica + " Proc. Automático",
                                        DtMovimento = DateTime.Now,
                                        ValorMovimento = valorMensalidade,
                                        ValorDesconto = 0,
                                        NumFatura = "",
                                        NumNotaCredito = "",
                                        MSaldo = saldoAnt - valorMensalidade,
                                        DataCriacao = DateTime.Now,
                                        IdCriacao = User.Identity.GetUserId(),
                                        DataModificacao = DateTime.MinValue,
                                        IdModificacao = " ",
                                        UtilizadorId = socioAtivo.Id,
                                        AtletaMovimentoId = ginastaAtivo.Id,
                                        RubricaId = rubrica.CodRubrica,
                                        MetodoPagamentoId = null
                                    };
                                    _context.Movimento.Add(movimento);

                                    // Atualiza Saldo do Sócio na tabela Saldos
                                    var saldoObj = _context.Saldo.FirstOrDefault(s => s.IdSocio == socioAtivo.Id);

                                    if (saldoObj != null)
                                    {
                                        // Step 3: Modify the properties you want to update
                                        saldoObj.MSaldo = saldoAnt - valorMensalidade;

                                        // Step 4: Save the changes back to the database
                                        _context.Saldo.Update(saldoObj);

                                    }
                                    // Atualiza ILancado, ValorMensalidadeLanc e IdMovimento
                                    var mensalidadeObj = _context.PlanoMensalidade.FirstOrDefault(s => s.IdPlanoM == mensalidade.IdPlanoM);

                                    if (mensalidadeObj != null)
                                    {
                                        // Step 3: Modify the properties you want to update
                                        mensalidadeObj.ILancado = "S";
                                        mensalidadeObj.ValorMensalidadeLanc = valorMensalidade;
                                        mensalidadeObj.IdMovimento = planoMovimento;

                                        // Step 4: Save the changes back to the database
                                        _context.PlanoMensalidade.Update(mensalidadeObj);

                                    }

                                    try
                                    {
                                        await _context.SaveChangesAsync();
                                        StatusMessageFinal = "Lançamento de movimentos realizado com sucesso";

                                    }
                                    catch (Exception ex)
                                    {
                                        StatusMessageFinal = "Erro de base de dados no lançamento de movimentos - Mensalidade: " +
                                                              mensalidade.IdPlanoM + " Solicitar apoio informático";
                                        return RedirectToPage("./Index");
                                    }



                                }
                            }
                        }
                    }
                }
            }
            if(StatusMessageFinal == "Inicialização de controlo")
            {
                StatusMessageFinal = "Sem movimentos válidos para lançar. Não foram lançados movimentos.";
            }

            // all  done
            return RedirectToPage("./Index");
        }
    }



}

