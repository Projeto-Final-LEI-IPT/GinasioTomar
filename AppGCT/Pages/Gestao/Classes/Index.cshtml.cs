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

namespace AppGCT.Pages.Gestao.Classes
{
    [Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        public string NomeClasseSort { get; set; }
        public string EstadoClasseSort { get; set; }
        public string CurrentFilter { get; set; }
        public IList<Classe> Classe { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Classe != null)
            {
               // Classe = await _context.Classe.ToListAsync();
                NomeClasseSort = String.IsNullOrEmpty(sortOrder) ? "nomeclasse_desc" : "";
                EstadoClasseSort = sortOrder == "EstadoClasse" ? "estadoclasse_desc" : "EstadoClasse";

                CurrentFilter = searchString;

                IQueryable<Classe> ClasseIQ = _context.Classe.AsQueryable();

                if (!String.IsNullOrEmpty(searchString))
                {
                    ClasseIQ = ClasseIQ.Where(s => s.NomeClasse.ToUpper().Contains(searchString.ToUpper()));
                }

                switch (sortOrder)
                {
                    case "nomeclasse_desc":
                        ClasseIQ = ClasseIQ.OrderByDescending(s => s.NomeClasse);
                        break;
                    case "EstadoClasse":
                        ClasseIQ = ClasseIQ.OrderBy(s => s.EstadoClasse);
                        break;
                    case "estadoclasse_desc":
                        ClasseIQ = ClasseIQ.OrderByDescending(s => s.EstadoClasse);
                        break;
                    default:
                        ClasseIQ = ClasseIQ.OrderBy(s => s.NomeClasse);
                        break;
                }

                Classe = await ClasseIQ.ToListAsync();
            }
        }
    }
}
