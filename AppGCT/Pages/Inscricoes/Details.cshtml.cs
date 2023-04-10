using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Inscricoes
{
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetailsModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

      public Ginasta Ginasta { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ginasta == null)
            {
                return NotFound();
            }

            var ginasta = await _context.Ginasta.FirstOrDefaultAsync(m => m.IdGinasta == id);
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
    }
}
