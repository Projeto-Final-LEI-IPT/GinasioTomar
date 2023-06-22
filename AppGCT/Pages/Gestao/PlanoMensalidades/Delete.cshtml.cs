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

namespace AppGCT.Pages.Inscricoes.PlanoMensalidades
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
      public PlanoMensalidade PlanoMensalidade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlanoMensalidade == null)
            {
                return NotFound();
            }

            var planomensalidade = await _context.PlanoMensalidade.Include(i => i.Aluno)
                                                                  .Include(i => i.Epoca)
                                                                  .FirstOrDefaultAsync(m => m.IdPlanoM == id);

            if (planomensalidade == null)
            {
                return NotFound();
            }
            else 
            {
                PlanoMensalidade = planomensalidade;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PlanoMensalidade == null)
            {
                return NotFound();
            }
            var planomensalidade = await _context.PlanoMensalidade.FindAsync(id);

            if (planomensalidade != null)
            {
                PlanoMensalidade = planomensalidade;
                _context.PlanoMensalidade.Remove(PlanoMensalidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
