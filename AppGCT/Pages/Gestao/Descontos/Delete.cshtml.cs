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
using System.Data;

namespace AppGCT.Pages.Gestao.Descontos
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
      public Desconto Desconto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Desconto == null)
            {
                return NotFound();
            }

            var desconto = await _context.Desconto.FirstOrDefaultAsync(m => m.CodDesconto == id);

            if (desconto == null)
            {
                return NotFound();
            }
            else 
            {
                Desconto = desconto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.Desconto == null)
            {
                return NotFound();
            }
            var desconto = await _context.Desconto.FindAsync(id);

            if (desconto != null)
            {
                Desconto = desconto;
                _context.Desconto.Remove(Desconto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
