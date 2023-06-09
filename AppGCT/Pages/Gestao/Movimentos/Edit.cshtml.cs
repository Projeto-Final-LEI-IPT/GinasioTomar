﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Gestao.Movimentos
{
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public EditModel(AppGCT.Data.AppGCTContext context)
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

            var movimento =  await _context.Movimento.FirstOrDefaultAsync(m => m.Id == id);
            if (movimento == null)
            {
                return NotFound();
            }
            Movimento = movimento;
           ViewData["AtletaMovimentoId"] = new SelectList(_context.Ginasta, "Id", "EstadoGinasta");
           ViewData["MetodoPagamentoId"] = new SelectList(_context.MetodoPagamento, "CodMetodo", "CodMetodo");
           ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["RubricaId"] = new SelectList(_context.Rubrica, "CodRubrica", "CodRubrica");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentoExists(Movimento.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovimentoExists(int? id)
        {
          return (_context.Movimento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
