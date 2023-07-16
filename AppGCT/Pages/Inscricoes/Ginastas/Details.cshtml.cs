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

namespace AppGCT.Pages.Inscricoes.Ginastas
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetailsModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

      public Ginasta Ginasta { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string userId = User.Identity.GetUserId();

            if (id == null || _context.Ginasta == null)
            {
                return RedirectToPage("./AcessDenied");
            }

            if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
            {
                var ginasta = await _context.Ginasta.Include(g => g.Socio).FirstOrDefaultAsync(m => m.Id == id);
                if (ginasta == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Ginasta = ginasta;
            }
            else
            {
                var ginasta = await _context.Ginasta.Include(g => g.Socio).FirstOrDefaultAsync(m => m.Id == id && m.UtilizadorId == userId);
                if (ginasta == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Ginasta = ginasta;
            }

            return Page();
        }
    }
}
