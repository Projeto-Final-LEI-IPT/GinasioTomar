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

namespace AppGCT.Pages.Inscricoes.Ginastas
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
        public Ginasta Ginasta { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ginasta == null)
            {
                return NotFound();
            }

            var ginasta = await _context.Ginasta.Include(g => g.Socio)
                                                .FirstOrDefaultAsync(m => m.Id == id);

            if (ginasta == null)
            {
                return NotFound();
            }
            else 
            {
                Ginasta = ginasta;
                var user = await _userManager.FindByIdAsync(Ginasta.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Ginasta.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ginasta == null)
            {
                return NotFound();
            }
            var ginasta = await _context.Ginasta.FindAsync(id);

            if (ginasta != null)
            {
                Ginasta = ginasta;
                _context.Ginasta.Remove(Ginasta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
