using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Gestao.Movimentos
{
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DeleteModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Movimento Movimento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movimento == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimento.FirstOrDefaultAsync(m => m.Id == id);

            if (movimento == null)
            {
                return NotFound();
            }
            else 
            {
                Movimento = movimento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Movimento == null)
            {
                return NotFound();
            }
            var movimento = await _context.Movimento.FindAsync(id);

            if (movimento != null)
            {
                Movimento = movimento;
                _context.Movimento.Remove(Movimento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
