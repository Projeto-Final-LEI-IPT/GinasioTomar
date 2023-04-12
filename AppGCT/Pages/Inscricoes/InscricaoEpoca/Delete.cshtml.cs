using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DeleteModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inscricao Inscricao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricao.FirstOrDefaultAsync(m => m.Id == id);

            if (inscricao == null)
            {
                return NotFound();
            }
            else 
            {
                Inscricao = inscricao;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }
            var inscricao = await _context.Inscricao.FindAsync(id);

            if (inscricao != null)
            {
                Inscricao = inscricao;
                _context.Inscricao.Remove(Inscricao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
