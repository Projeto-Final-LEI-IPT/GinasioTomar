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
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace AppGCT.Pages.Ginasio.Epocas
{
    [Authorize(Roles = "Administrador")]
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public DeleteModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Epoca Epoca { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Epoca == null)
            {
                return NotFound();
            }

            var epoca = await _context.Epoca.FirstOrDefaultAsync(m => m.IdEpoca == id);

            if (epoca == null)
            {
                return NotFound();
            }
            else 
            {
                Epoca = epoca;
                var user = await _userManager.FindByIdAsync(Epoca.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Epoca.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Epoca == null)
            {
                return NotFound();
            }
            var epoca = await _context.Epoca.FindAsync(id);

            if (epoca != null)
            {
                Epoca = epoca;
                _context.Epoca.Remove(Epoca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
