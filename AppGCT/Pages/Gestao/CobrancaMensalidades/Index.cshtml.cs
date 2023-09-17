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
using System.Text.Encodings.Web;
using AppGCT.Outros;
using Humanizer;

namespace AppGCT.Pages.Gestao.CobrancaMensalidades
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly IEmailSender _emailSender;

        private Movimento movimentoQuota;

        public IndexModel(AppGCT.Data.AppGCTContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
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
        private async Task<bool> lancaQuota(Areas.Identity.Data.Utilizador socio)
        {
            // Consultar saldo do socio, antes de efetivar movimento
            var saldoAnt = _context.Saldo.Where(i => i.IdSocio == socio.Id).FirstOrDefault().MSaldo;
            //obtem rubrica passivel de gerar movimento de Quota ( Ativa e do Tipo Socio)
            var rubrica = await _context.Rubrica
                                        .FirstOrDefaultAsync(r => r.TipoRubrica == "S" &&
                                                                  r.EstadoRubrica == "A");
            // Listar todas as Rubricas do tipo de Socio, para posteriormente verificar se para o mes de Janeiro
            // ja foi criado algum movimetno para s�cio, desse tipo
            var rubricasTipoSocio = await _context.Rubrica.Where(i => i.TipoRubrica == "S").ToListAsync();
            bool movimento = true;
            foreach (var rubricaTipoSocio in rubricasTipoSocio)
            {
                movimento = await _context.Movimento.AnyAsync(i => i.UtilizadorId == socio.Id &&
                                                                   i.DtMovimento.Year == DateTime.Now.Year &&
                                                                   i.DtMovimento.Month == DateTime.Now.Month &&
                                                                   i.RubricaId == rubricaTipoSocio.CodRubrica);
                // A primeira rubrica do tipoSocio encontrada, faz terminar o ciclo
                if (movimento)
                {
                    break;
                }
            }

            if (rubrica != null && !movimento)
            {

                decimal valorQuota = rubrica.ValorUnitario ?? 0m;

                Guid IdMovimento = Guid.NewGuid();

                movimentoQuota = new Movimento
                {
                    Id = IdMovimento,
                    DesRubrica = rubrica.DescricaoRubrica,
                    DtMovimento = DateTime.Now,
                    ValorMovimento = valorQuota,
                    ValorDesconto = 0,
                    NumFatura = "",
                    NumNotaCredito = "",
                    MSaldo = saldoAnt - valorQuota,
                    DataCriacao = DateTime.Now,
                    IdCriacao = User.Identity.GetUserId(),
                    DataModificacao = DateTime.MinValue,
                    IdModificacao = " ",
                    UtilizadorId = socio.Id,
                    AtletaMovimentoId = null,
                    RubricaId = rubrica.CodRubrica,
                    MetodoPagamentoId = null
                };
                _context.Movimento.Add(movimentoQuota);

                // Atualiza Saldo do Socio na tabela Saldos
                var saldoObj = _context.Saldo.FirstOrDefault(s => s.IdSocio == socio.Id);

                if (saldoObj != null)
                {
                    // Step 3: Modify the properties you want to update
                    saldoObj.MSaldo = saldoAnt - valorQuota;

                    // Step 4: Save the changes back to the database
                    _context.Saldo.Update(saldoObj);

                }
                return true;
            }
            return false;
        }
            public async Task OnGetAsync()
        {
            var dataCorrente = DateTime.Today.Month;
            // Consultar todos os Socios Ativos
            var sociosAtivos = await _context.Users.Where(i => i.EstadoUtilizador == "A" &&
                                                               i.RoleAux == "Sócio").ToListAsync();
            foreach (var socioAtivo in sociosAtivos)
            {
                // Verificar se ha QUOTAS a lancar e popular tabela
                if(dataCorrente == 9)
                {
                    //obtem rubrica passivel de gerar movimento de Quota ( Ativa e do Tipo Socio)
                    var rubrica = await _context.Rubrica
                                                .FirstOrDefaultAsync(r => r.TipoRubrica == "S" &&
                                                                          r.EstadoRubrica == "A");
                    if (rubrica != null)
                    {

                    decimal valorMensalidade = rubrica.ValorUnitario ?? 0m;
                    // Listar todas as Rubricas do tipo de Socio, para posteriormente verificar se para o mes de Janeiro
                    // ja foi criado algum movimetno para socio, desse tipo
                    var rubricasTipoSocio = await _context.Rubrica.Where(i => i.TipoRubrica == "S").ToListAsync();
                    var movimento = true;
                    foreach (var rubricaTipoSocio in rubricasTipoSocio)
                    {
                        movimento = await _context.Movimento.AnyAsync(i => i.UtilizadorId == socioAtivo.Id &&
                                                                           i.DtMovimento.Year == DateTime.Now.Year &&
                                                                           i.DtMovimento.Month == DateTime.Now.Month &&
                                                                           i.RubricaId == rubricaTipoSocio.CodRubrica);
                        // A primeira rubrica do tipoSocio encontrada, faz terminar o ciclo
                        if (movimento)
                        {
                            break;
                        }
                    }
                    if (!movimento)
                    {
                        DataViewModel model = new DataViewModel();
                        model.DataMensalidade = DateOnly.FromDateTime(DateTime.Now);
                        model.ValorLancar = rubrica.ValorUnitario ?? 0m;
                        model.Ginasta = "N/A - Quota de sócio";
                        model.Socio = socioAtivo.Nome;
                        Mensalidades.Add(model);
                    }
                    }
                }
                // Consultar Ginastas Ativos para o Socio em tratamento
                var ginastasAtivos = await _context.Ginasta.Where(i => i.UtilizadorId == socioAtivo.Id &&
                                                                       i.EstadoGinasta == "A"
                                                                 ).ToListAsync();
                foreach(var ginastaAtivo in ginastasAtivos)
                {
                    // Consultar mensalidades planeadas para o mes corrente e que nao tenham sido ja lancadas
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
            bool rubQuotaAtiva = await _context.Rubrica.AnyAsync(e => e.TipoRubrica == "S" &&
                                                                      e.EstadoRubrica == "A");
            StatusMessageFinal = "Inicialização de controlo";
            var dataCorrente = DateTime.Today.Month;
            // Consultar todos os Socios Ativos
            var sociosAtivos = await _context.Users.Where(i => i.EstadoUtilizador == "A" &&
                                                               i.RoleAux == "Sócio").ToListAsync();
            foreach (var socioAtivo in sociosAtivos)
            {
                // TODO - Verificar se ha QUOTAS a lancar e popular tabela
                if (dataCorrente == 9)
                {
                    // Se existe rubrica de quota Ativa podemos lançar Quota
                    if (rubQuotaAtiva)
                    {
                        // Faz a lógica para lançar movimentos de quotas e atualizar saldo
                        if(await lancaQuota(socioAtivo))
                        {
                            try
                            {
                                await _context.SaveChangesAsync();
                                //lança e-mail alerta
                                await _emailSender.SendEmailAsync(socioAtivo.Email, "Lançamento Quota Sócio Anual - Ginásio Clube de Tomar",
                                        $"<br><b>Lançamento Quota Anual!</b><br>" +
                                        $"<br> Caro(a) Sócio(a) <b>{socioAtivo.Nome}</b>,<br> " +
                                        $"Lançamos na sua conta corrente a Quota Anual abaixo:<br><br>" +
                                        $"<b>Data Quota:</b> {movimentoQuota.DtMovimento.Year}/{movimentoQuota.DtMovimento.Month}<br>" +
                                        $"<b>Valor Quota:</b> {movimentoQuota.ValorMovimento}€<br>" +
                                        $"<b>Saldo Conta Corrente:</b> {movimentoQuota.MSaldo}€<br>" +

                                        $"<br>Este e-mail foi enviado de forma automática, por favor não responda diretamente para este endereço." +
                                        $"<br>Alguma dúvida ou sugestão não hesite em contactar-nos.<br><br>" +
                                        $"Com os melhores cumprimentos,<br>" +
                                        $"<b>Ginásio Clube de Tomar</b>");
                                StatusMessageFinal = "Lançamento de quotas efetuado com sucesso. " +
                                                     "Não houveram mensalidades lançadas.";
                            }
                            catch (Exception ex)
                            {
                                StatusMessageFinal = "Erro no lançamento da quota do sócio " + socioAtivo.Nome + "(" +
                                     socioAtivo.NumSocio + ")";
                                return RedirectToPage("./Index");
                            }
                        };
                    }
                }
                // Consultar Ginastas Ativos para o Socio em tratamento
                var ginastasAtivos = await _context.Ginasta.Where(i => i.UtilizadorId == socioAtivo.Id &&
                                                                       i.EstadoGinasta == "A"
                                                                 ).ToListAsync();
                foreach (var ginastaAtivo in ginastasAtivos)
                {
                    // Consultar mensalidades planeadas para o mes corrente e que nao tenham sido ja lancadas
                    var mensalidades = await _context.PlanoMensalidade.Where(i => i.DataMensalidade.Month == dataCorrente &&
                                                                                  i.GinastaId == ginastaAtivo.Id &&
                                                                                  i.ILancado == "N" &&
                                                                                  !i.IdMovimento.HasValue
                                                                              ).ToListAsync();
                    //TODO - validar se existe mais de uma mensalidade por lancar para o corrente mes, e dar erro se isso acontecer ???
                    foreach (var mensalidade in mensalidades)
                    {
                        var epocaAtiva = _context.Epoca.Where(i => i.IdEpoca == mensalidade.EpocaId).FirstOrDefault();
                        if (epocaAtiva.EstadoEpoca == "A")
                        {
                            // Consultar saldo do s�cio, antes de efetivar movimento
                            var saldoAnt = _context.Saldo.Where(i => i.IdSocio == socioAtivo.Id).FirstOrDefault().MSaldo;
                            // Consultar valor da mensalidade
                            //valida se Ginasta ja tem inscri��o na �poca
                            bool JaInscritoEpoca = await _context.Inscricao
                                                          .AnyAsync(i => i.GinastaId == mensalidade.GinastaId && i.EpocaId == mensalidade.EpocaId);
                            // Se atleta inscrito na epoca da mensalidade em tratamento, vamos lan�ar o respetivo movimento
                            if (JaInscritoEpoca)
                            {
                                // Consultar inscricao para buscar Classe e Desconto associado
                                var incricaoAtiva = _context.Inscricao
                                                          .Where(i => i.GinastaId == mensalidade.GinastaId && i.EpocaId == mensalidade.EpocaId).Include(m => m.Class).FirstOrDefault();
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

                                // Atualiza Saldo do Socio na tabela Saldos
                                var saldoObj = _context.Saldo.FirstOrDefault(s => s.IdSocio == socioAtivo.Id);

                                if (epocaAtiva.ICobrancUltimoMes == "N" &&
                                    epocaAtiva.DataFim.Month == mensalidade.DataMensalidade.Month &&
                                    epocaAtiva.DataFim.Year == mensalidade.DataMensalidade.Year)
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
                                }
                                else
                                {
                                    Guid planoMovimento = Guid.NewGuid();

                                    var movimento = new Movimento
                                    {
                                        Id = planoMovimento,
                                        DesRubrica = rubrica.DescricaoRubrica,
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
                                }
                                try
                                {
                                    await _context.SaveChangesAsync();
                                    if (epocaAtiva.ICobrancUltimoMes == "N" &&
                                        epocaAtiva.DataFim.Month == mensalidade.DataMensalidade.Month &&
                                        epocaAtiva.DataFim.Year == mensalidade.DataMensalidade.Year)
                                    {
                                        // Se estamos em janeiro e não existe rubrica de quotas ativas, as mesma não serão lançadas
                                        if (!rubQuotaAtiva && dataCorrente == 1)
                                        {
                                            StatusMessageFinal = "Lançamento de mensalidades realizado com sucesso, no entanto, " +
                                                "considere que tratando-se do último mês da época, cujo o último mês está isento de cobrança, " +
                                                "a mesma não gerou movimentação financeira. Considere também que eventuais quotas em condições " +
                                                "de serem lançadas não o foram por não existir nenhuma rúbrica de quotas ativa";
                                        }
                                        else
                                        {
                                            StatusMessageFinal = "Lançamento de mensalidades realizado com sucesso, no entanto, " +
                                                "considere que tratando-se do último mês da época, cujo o último mês está isento de cobrança, " +
                                                "a mesma não gerou movimentação financeira.";
                                        }

                                    }
                                    else
                                    {
                                        // Se estamos em janeiro e não existe rubrica de quotas ativas, as mesma não serão lançadas
                                        if (!rubQuotaAtiva && dataCorrente == 1)
                                        {
                                            StatusMessageFinal = "Lançamento de movimentos realizado com sucesso, no entanto " +
                                                                 "considere que eventuais quotas em condições de serem lançadas " +
                                                                 "não o foram por não existir nenhuma rúbrica de quotas ativa";
                                        }
                                        else
                                        {
                                            StatusMessageFinal = "Lançamento de movimentos realizado com sucesso";
                                        }
                                        //lança e-mail alerta
                                        await _emailSender.SendEmailAsync(socioAtivo.Email, "Lançamento Mensalidade - Ginásio Clube de Tomar",
                                                $"<br><b>Lançamento Mensalidade!</b><br>" +
                                                $"<br> Caro(a) Sócio(a) <b>{socioAtivo.Nome}</b>,<br> " +
                                                $"Lançamos na sua conta corrente a mensalidade abaixo:<br><br>" +
                                                $"<b>Ginasta:</b> {ginastaAtivo.NomeCompleto}<br>" +
                                                $"<b>Classe:</b> {incricaoAtiva.Class.NomeClasse}<br>" +
                                                $"<b>Data Mensalidade:</b> {mensalidade.DataMensalidade.Year}/{mensalidade.DataMensalidade.Month}<br>" +
                                                $"<b>Valor Mensalidade:</b> {valorMensalidade}€<br>" +
                                                $"<b>Saldo Conta Corrente:</b> {saldoObj.MSaldo}€<br>" +

                                                $"<br>Este e-mail foi enviado de forma automática, por favor não responda diretamente para este endereço." +
                                                $"<br>Alguma dúvida ou sugestão não hesite em contactar-nos.<br><br>" +
                                                $"Com os melhores cumprimentos,<br>" +
                                                $"<b>Ginásio Clube de Tomar</b>");
                                    }
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
            if(StatusMessageFinal == "Inicialização de controlo")
            {
                StatusMessageFinal = "Sem movimentos válidos para lançar. Não foram lançados movimentos.";
            }
            // all  done
            return RedirectToPage("./Index");
        }
    }
}