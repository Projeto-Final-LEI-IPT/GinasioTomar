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

namespace AppGCT.Pages.Inscricoes.Ginastas
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
      public Ginasta Ginasta { get; set; } = default!;

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
