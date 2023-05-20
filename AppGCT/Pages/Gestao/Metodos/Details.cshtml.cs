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

namespace AppGCT.Pages.Gestao.Metodos
{
    [Authorize(Roles = "Administrador")]
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetailsModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

      public MetodoPagamento MetodoPagamento { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.MetodoPagamento == null)
            {
                return NotFound();
            }

            var metodopagamento = await _context.MetodoPagamento.FirstOrDefaultAsync(m => m.CodMetodo == id);
            if (metodopagamento == null)
            {
                return NotFound();
            }
            else 
            {
                MetodoPagamento = metodopagamento;
            }
            return Page();
        }
    }
}
