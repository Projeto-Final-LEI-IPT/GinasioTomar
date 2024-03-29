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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AppGCT.Pages.Gestao.Metodos
{
    [Authorize(Roles = "Administrador")]
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private async Task<bool> ValidaMetodo()
        {
            if (_context.MetodoPagamento == null || MetodoPagamento == null)
            {
                return false;
            }

            // Valida se o nome metodo já existe na BD
            if (await _context.MetodoPagamento.AnyAsync(e => e.DescMetodo == MetodoPagamento.DescMetodo && e.CodMetodo != MetodoPagamento.CodMetodo))
            {
                ModelState.AddModelError("MetodoPagamento.DescMetodo", "Já existe um Método Pagamento com esta descrição.");
                return false;
            }

            return true;
        }

        public EditModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MetodoPagamento MetodoPagamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.MetodoPagamento == null)
            {
                return NotFound();
            }

            var metodopagamento =  await _context.MetodoPagamento.FirstOrDefaultAsync(m => m.CodMetodo == id);
            if (metodopagamento == null)
            {
                return NotFound();
            }
            MetodoPagamento = metodopagamento;
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
            if (!await ValidaMetodo())
            {
                return Page();
            }
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MetodoPagamento.IdModificacao = userId;
            MetodoPagamento.DataModificacao = DateTime.Now;
            _context.Attach(MetodoPagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoPagamentoExists(MetodoPagamento.CodMetodo))
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

        private bool MetodoPagamentoExists(string id)
        {
          return (_context.MetodoPagamento?.Any(e => e.CodMetodo == id)).GetValueOrDefault();
        }
    }
}
