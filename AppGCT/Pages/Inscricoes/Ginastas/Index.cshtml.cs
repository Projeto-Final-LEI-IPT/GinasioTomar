using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AppGCT.Pages.Inscricoes.Ginastas
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public string NomeSort { get; set; }
        public string DataNascSort { get; set; }
        public string EstadoSort { get; set; }
        public string EmailSort { get; set; }
        public string NumSocioSort { get; set; }
        public string NomeSocioSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Ginasta> Ginastas { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Ginasta != null)
            {
                NomeSort = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
                DataNascSort = sortOrder == "DataNasc" ? "datanasc_desc" : "DataNasc";
                EstadoSort = sortOrder == "Estado" ? "estado_desc" : "Estado";
                EmailSort = sortOrder == "Email" ? "email_desc" : "Email";
                NumSocioSort = sortOrder == "NumSocio" ? "numsocio_desc" : "NumSocio";
                NomeSocioSort = sortOrder == "NomeSocio" ? "nomesocio_desc" : "NomeSocio";

                CurrentFilter = searchString;

                string userId = User.Identity.GetUserId();
                var GinastaIQ = _context.Ginasta.AsQueryable();

                if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
                {
                    GinastaIQ = GinastaIQ.Include(r => r.Socio);

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        GinastaIQ = GinastaIQ.Include(r => r.Socio).Where(s => s.NomeCompleto.ToUpper().Contains(searchString.ToUpper())
                                                                    || s.Socio.Nome.ToUpper().Contains(searchString.ToUpper()));
                    }
                }
                else
                {
                    GinastaIQ = GinastaIQ.Include(r => r.Socio)
                                         .Where(s => s.UtilizadorId.Equals(userId));

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        GinastaIQ = GinastaIQ.Include(r => r.Socio)
                                         .Where(s => s.UtilizadorId.Equals(userId) && s.NomeCompleto.ToUpper().Contains(searchString.ToUpper()));
                    }
                }

                switch (sortOrder)
                {
                    case "nome_desc":
                        GinastaIQ = GinastaIQ.OrderByDescending(s => s.NomeCompleto);
                        break;
                    case "DataNasc":
                        GinastaIQ = GinastaIQ.OrderBy(s => s.DtNascim);
                        break;
                    case "datanasc_desc":
                        GinastaIQ = GinastaIQ.OrderByDescending(s => s.DtNascim);
                        break;
                    case "Estado":
                        GinastaIQ = GinastaIQ.OrderBy(s => s.EstadoGinasta);
                        break;
                    case "estado_desc":
                        GinastaIQ = GinastaIQ.OrderByDescending(s => s.EstadoGinasta);
                        break;
                    case "Email":
                        GinastaIQ = GinastaIQ.OrderBy(s => s.Email);
                        break;
                    case "email_desc":
                        GinastaIQ = GinastaIQ.OrderByDescending(s => s.Email);
                        break;
                    case "NumSocio":
                        GinastaIQ = GinastaIQ.OrderBy(s => s.Socio.NumSocio);
                        break;
                    case "numsocio_desc":
                        GinastaIQ = GinastaIQ.OrderByDescending(s => s.Socio.NumSocio);
                        break;
                    case "NomeSocio":
                        GinastaIQ = GinastaIQ.OrderBy(s => s.Socio.Nome);
                        break;
                    case "nomesocio_desc":
                        GinastaIQ = GinastaIQ.OrderByDescending(s => s.Socio.Nome);
                        break;
                    default:
                        GinastaIQ = GinastaIQ.OrderBy(s => s.NomeCompleto);
                        break;
                }

                Ginastas = await GinastaIQ.AsNoTracking().ToListAsync();
            }
        }
    }
}
