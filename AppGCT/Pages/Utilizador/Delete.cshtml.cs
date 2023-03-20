using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Utilizador
{
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DeleteModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Utilizadores Utilizadores { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores.FirstOrDefaultAsync(m => m.Id == id);

            if (utilizadores == null)
            {
                return NotFound();
            }
            else 
            {
                Utilizadores = utilizadores;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Utilizadores == null)
            {
                return NotFound();
            }
            var utilizadores = await _context.Utilizadores.FindAsync(id);

            if (utilizadores != null)
            {
                Utilizadores = utilizadores;
                _context.Utilizadores.Remove(Utilizadores);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
