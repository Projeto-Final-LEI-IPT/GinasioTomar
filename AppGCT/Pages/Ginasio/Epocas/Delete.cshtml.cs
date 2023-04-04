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

namespace AppGCT.Pages.Ginasio.Epocas
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DeleteModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Epoca Epoca { get; set; } = default!;

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
