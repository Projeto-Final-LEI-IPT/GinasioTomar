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

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetailsModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

      public Inscricao Inscricao { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string userId = User.Identity.GetUserId();

            if (id == null || _context.Inscricao == null)
            {
                return RedirectToPage("./AcessDenied");
            }

            if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
            {
                var inscricao = await _context.Inscricao.Include(i => i.Atleta).Include(i => i.Periodo).Include(i => i.Class).Include(i => i.Descont)
                                                     .FirstOrDefaultAsync(m => m.Id == id);
                if (inscricao == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Inscricao = inscricao;
            }
            else
            {
                var inscricao = await _context.Inscricao.Include(i => i.Atleta).Include(i => i.Periodo).Include(i => i.Class).Include(i => i.Descont)
                                     .FirstOrDefaultAsync(m => m.Id == id && m.Atleta.UtilizadorId == userId);

                if (inscricao == null)
                {
                    return RedirectToPage("./AcessDenied");
                }

                Inscricao = inscricao;
            }

            return Page();
        }
    }
}
