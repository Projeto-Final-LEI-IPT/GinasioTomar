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

namespace AppGCT.Pages.Gestao.RubricasPrecario
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
        public Rubrica Rubrica { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Rubrica == null)
            {
                return NotFound();
            }

            var rubrica = await _context.Rubrica.Include(i => i.Discount).Include(i => i.Modalidade)
                                                .FirstOrDefaultAsync(m => m.CodRubrica == id);

            if (rubrica == null)
            {
                return NotFound();
            }
            else 
            {
                Rubrica = rubrica;
                var user = await _userManager.FindByIdAsync(Rubrica.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Rubrica.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Rubrica == null)
            {
                return NotFound();
            }
            var rubrica = await _context.Rubrica.FindAsync(id);

            if (rubrica != null)
            {
                Rubrica = rubrica;
                _context.Rubrica.Remove(Rubrica);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
