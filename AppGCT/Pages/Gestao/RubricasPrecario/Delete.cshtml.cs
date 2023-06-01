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

namespace AppGCT.Pages.Gestao.RubricasPrecario
{
    [Authorize(Roles = "Administrador")]
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DeleteModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rubrica Rubrica { get; set; } = default!;

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
