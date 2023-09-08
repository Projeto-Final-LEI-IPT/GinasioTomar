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

        public List<DataViewModel> Mensalidades { get; set; } = new List<DataViewModel>();

        public class DataViewModel
        {
            public DateOnly? DataMensalidade { get; set; }
            public Decimal? ValorLancar { get; set; }
            public String? Ginasta { get; set; }
            public String? Socio { get; set; }
        }

        // some message to be shown on the page 
        public string Message { get; set; }

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
            var movimento = new Movimento
            {
                DesRubrica = "Teste dia 6",
                DtMovimento = DateTime.Now,
                ValorMovimento = 14,
                ValorDesconto = 1,
                NumFatura = "",
                NumNotaCredito = "",
                MSaldo = 30,
                DataCriacao = DateTime.Now,
                IdCriacao = User.Identity.GetUserId(),
                DataModificacao = DateTime.MinValue,
                IdModificacao = " ",
                UtilizadorId = User.Identity.GetUserId(),
                AtletaMovimentoId = 2,
                RubricaId = "001",
                MetodoPagamentoId = null
            };
            _context.Movimento.Add(movimento);
            await _context.SaveChangesAsync();
            // all  done
            return Page();
        }
    }


}

