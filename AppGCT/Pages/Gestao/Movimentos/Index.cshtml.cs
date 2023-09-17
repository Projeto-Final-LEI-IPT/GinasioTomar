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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Data;
using AppGCT.Areas.Identity.Data;
using System.Security.Claims;

namespace AppGCT.Pages.Gestao.Movimentos
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public IndexModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public string IdSocio { get; set; }
        [BindProperty(SupportsGet = true)]
        public int IdGinasta { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentFilterFim { get; set; }
        public IList<Movimento> Movimento { get;set; } = default!;

        public SelectList SociosList { get; set; }
        public SelectList GinastasList { get; set; }

        public async Task OnGetAsync(string? idsocio, int? idginasta, string searchString, string searchStringFim)
        {
            DateTime searchDate;
            DateTime searchDateFim;

            if (idsocio != null || idginasta.HasValue || (!string.IsNullOrEmpty(searchString)) || (!string.IsNullOrEmpty(searchStringFim)))
            {
                IdSocio = idsocio;
                IdGinasta = idginasta.Value;
                CurrentFilter = searchString;
                CurrentFilterFim = searchStringFim;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                searchDate = DateTime.Parse(searchString);
            }
            else
            {
                searchDate = DateTime.MinValue;
            }

            if (!string.IsNullOrEmpty(searchStringFim))
            {
                searchDateFim = DateTime.Parse(searchStringFim);
                //para forçar a última hora/min/segundo da data fim
                searchDateFim = searchDateFim.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            else
            {
                searchDateFim = DateTime.MaxValue;
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Preenche VIEWBAG com SALDO, para apresentar o mesmo ao Sócio, quando entra nésta página  (INDEX dos Movimentos)
            if (User.IsInRole("Sócio"))
            {
                ViewData["SaldoSocioVB"] = _context.Saldo.Where(i => i.IdSocio == userId).FirstOrDefault().MSaldo;
            }

            if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
            {
                List<string> userIdsInRole;
                //obtem lista de utilizadores associados ao role se role != null
                userIdsInRole = (await _userManager.GetUsersInRoleAsync("Sócio"))
                                                   .Select(u => u.Id)
                                                   .ToList();
                // preenche dropdown Sócios para filtro
                var socios = _context.Utilizador.Where(i => i.EstadoUtilizador == "A" &&
                                                       userIdsInRole.Contains(i.Id) && i.NumSocio != null && i.NumSocio != "")
                                                        .ToList();
                socios.Insert(0, new Utilizador
                {
                    Id = null,
                    Nome = "Seleccionar Sócio"
                });

                SociosList = new SelectList(socios, "Id", "Nome");

                // preenche dropdown Ginastas para filtro
                var ginastas = _context.Ginasta.Where(i => i.EstadoGinasta == "A").ToList();
                ginastas.Insert(0, new Ginasta
                {
                    Id = 0,
                    NomeCompleto = "Seleccionar Ginasta"
                });

                GinastasList = new SelectList(ginastas, "Id", "NomeCompleto");

                // Aqui, estamos como Administradores ou Ginásio
                // Assim sendo, se for selecionado o filtro de Sócio, devemos passar para a ViewBag SaldoAdminGinVB
                // o saldo desse mesmo sócio, para ser exibido ao Utilizador
                if(idsocio != null)
                {
                    ViewData["SaldoAdminGinVB"] = _context.Saldo.Where(i => i.IdSocio == idsocio).FirstOrDefault().MSaldo;
                }
                else
                {
                    // Inicializamos a ViewBag, para artifício de esconder o saldo sempre que o OnGetAsync é chamado sem Sócio 
                    // passado por parâmetro
                    ViewData["SaldoAdminGinVB"] = 9999999;
                }
            }
            else
            {
                // preenche dropdown Ginastas para filtro
                var ginastas = _context.Ginasta.Where(i => i.EstadoGinasta == "A" && i.UtilizadorId == userId).ToList();
                ginastas.Insert(0, new Ginasta
                {
                    Id = 0,
                    NomeCompleto = "Seleccionar Ginasta"
                });

                GinastasList = new SelectList(ginastas, "Id", "NomeCompleto");
            }

            if (_context.Movimento != null)
            {
                 if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
                {
                    // se sócio e ginasta preenchido
                    if (idsocio != null && idginasta != 0 && idginasta != null)
                    {
                        Movimento = await _context.Movimento
                                    .Include(m => m.Atleta)
                                    .Include(m => m.FormaPagamento)
                                    .Include(m => m.Socio)
                                    .Include(m => m.TipoDespesa)
                                    .Where(m => m.UtilizadorId == idsocio && m.AtletaMovimentoId == idginasta && m.DtMovimento >= searchDate && m.DtMovimento <= searchDateFim)
                                    .OrderByDescending(m => m.DtMovimento)
                                    .ToListAsync();
                    }
                    else
                    //se Sócio preenchido
                    if (idsocio != null && (idginasta == 0 || idginasta == null))
                    {
                        Movimento = await _context.Movimento
                                    .Include(m => m.Atleta)
                                    .Include(m => m.FormaPagamento)
                                    .Include(m => m.Socio)
                                    .Include(m => m.TipoDespesa)
                                    .Where(m => m.UtilizadorId == idsocio && m.AtletaMovimentoId == null && m.DtMovimento >= searchDate && m.DtMovimento <= searchDateFim)
                                    .OrderByDescending(m => m.DtMovimento)
                                    .ToListAsync();
                    }
                    else
                    // se Ginasta preenchido
                    if (idsocio == null && idginasta != 0 && idginasta != null)
                    {
                        Movimento = await _context.Movimento
                                    .Include(m => m.Atleta)
                                    .Include(m => m.FormaPagamento)
                                    .Include(m => m.Socio)
                                    .Include(m => m.TipoDespesa)
                                    .Where(m => m.AtletaMovimentoId == idginasta && m.DtMovimento >= searchDate && m.DtMovimento <= searchDateFim)
                                    .OrderByDescending(m => m.DtMovimento)
                                    .ToListAsync();
                    }
                    else
                    {
                        Movimento = await _context.Movimento
                                    .Include(m => m.Atleta)
                                    .Include(m => m.FormaPagamento)
                                    .Include(m => m.Socio)
                                    .Include(m => m.TipoDespesa)
                                    .Where(m => m.DtMovimento >= searchDate && m.DtMovimento <= searchDateFim)
                                    .OrderByDescending(m => m.DtMovimento)
                                    .ToListAsync();
                    }
                }
                else
                {
                    //se ginasta preenchido
                    if (idginasta != 0 && idginasta != null)
                    {
                        Movimento = await _context.Movimento
                                   .Include(m => m.Atleta)
                                   .Include(m => m.FormaPagamento)
                                   .Include(m => m.Socio)
                                   .Include(m => m.TipoDespesa).Where(m => m.UtilizadorId.Equals(userId) && m.AtletaMovimentoId == idginasta && m.DtMovimento >= searchDate && m.DtMovimento <= searchDateFim)
                                   .OrderByDescending(m => m.DtMovimento)
                                   .ToListAsync();
                    }
                    else
                    {
                        Movimento = await _context.Movimento
                                   .Include(m => m.Atleta)
                                   .Include(m => m.FormaPagamento)
                                   .Include(m => m.Socio)
                                   .Include(m => m.TipoDespesa)
                                   .Where(m => m.UtilizadorId.Equals(userId) && m.DtMovimento >= searchDate && m.DtMovimento <= searchDateFim)
                                   .OrderByDescending(m => m.DtMovimento)
                                   .ToListAsync();
                    }
                    
                }

            }
        }
    }
}
