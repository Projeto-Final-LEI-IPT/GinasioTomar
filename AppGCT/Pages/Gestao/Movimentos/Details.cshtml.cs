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
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetailsModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

      public Movimento Movimento { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movimento == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimento.Include(i => i.Socio)
                                                    .Include(i => i.Atleta)
                                                    .Include(i => i.TipoDespesa)
                                                    .Include(i => i.FormaPagamento)
                                                    .FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
