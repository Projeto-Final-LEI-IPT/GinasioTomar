﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetailsModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

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
    }
}
