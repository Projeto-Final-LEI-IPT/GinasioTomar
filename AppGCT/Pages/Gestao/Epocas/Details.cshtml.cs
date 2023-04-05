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
    [Authorize(Roles = "Administrador")]
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetailsModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

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
    }
}
