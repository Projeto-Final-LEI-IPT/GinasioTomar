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

namespace AppGCT.Pages.Ginasio.Epocas
{
    [Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        public string EpocaSort { get; set; }
        public string DataInicioSort { get; set; }
        public string DataFimSort { get; set; }
        public string EstadoEpocaSort { get; set; }
        public string CurrentFilter { get; set; }
        public IList<Epoca> Epoca { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Epoca != null)
            {
               EpocaSort = String.IsNullOrEmpty(sortOrder) ? "epoca" : "";
               DataInicioSort = sortOrder == "DataInicio" ? "datainicio_desc" : "DataInicio";
               DataFimSort = sortOrder == "DataFim" ? "datafim_desc" : "DataFim";
               EstadoEpocaSort = sortOrder == "EstadoEpoca" ? "estadoepoca_desc" : "EstadoEpoca";

               CurrentFilter = searchString;

               IQueryable<Epoca> EpocaIQ = _context.Epoca.AsQueryable();

               if (!String.IsNullOrEmpty(searchString))
               {
                  EpocaIQ = EpocaIQ.Where(s => s.NomeEpoca.ToUpper().Contains(searchString.ToUpper()));
               }

               switch (sortOrder)
               {
                   case "epoca":
                        EpocaIQ = EpocaIQ.OrderBy(s => s.NomeEpoca);
                        break;
                   case "DataInicio":
                        EpocaIQ = EpocaIQ.OrderBy(s => s.DataInicio);
                        break;
                   case "datainicio_desc":
                        EpocaIQ = EpocaIQ.OrderByDescending(s => s.DataInicio);
                        break;
                   case "DataFim":
                        EpocaIQ = EpocaIQ.OrderBy(s => s.DataFim);
                        break;
                   case "datafim_desc":
                        EpocaIQ = EpocaIQ.OrderByDescending(s => s.DataFim);
                        break;
                   case "EstadoEpoca":
                        EpocaIQ = EpocaIQ.OrderBy(s => s.EstadoEpoca);
                        break;
                   case "estadoepoca_desc":
                        EpocaIQ = EpocaIQ.OrderByDescending(s => s.EstadoEpoca);
                        break;
                   default:
                        EpocaIQ = EpocaIQ.OrderByDescending(s => s.NomeEpoca);
                        break;
               }

                    Epoca = await EpocaIQ.ToListAsync();
            }
        }
    }
}
