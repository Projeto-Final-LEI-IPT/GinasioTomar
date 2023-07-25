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
using Microsoft.AspNetCore.Identity;
using AppGCT.Areas.Identity.Data;
using System.Security.Claims;

namespace AppGCT.Pages.Inscricoes.Ginastas
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public DetailsModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Ginasta Ginasta { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

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
                var user = await _userManager.FindByIdAsync(Ginasta.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Ginasta.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            else
            {
                var ginasta = await _context.Ginasta.Include(g => g.Socio).FirstOrDefaultAsync(m => m.Id == id && m.UtilizadorId == userId);
                if (ginasta == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Ginasta = ginasta;
                var user = await _userManager.FindByIdAsync(Ginasta.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Ginasta.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }

            return Page();
        }
    }
}
