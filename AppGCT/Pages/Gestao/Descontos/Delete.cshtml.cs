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
using System.Data;
using Microsoft.AspNetCore.Identity;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Pages.Gestao.Descontos
{
    [Authorize(Roles = "Administrador")]
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public DeleteModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Desconto Desconto { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

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
                if (Desconto.IdCriacao == "SEED")
                {
                    IdCriacaoName = "SEED INICIAL";
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(Desconto.IdCriacao);
                    IdCriacaoName = user?.Nome;
                }
                var user2 = await _userManager.FindByIdAsync(Desconto.IdModificacao);
                IdModificacaoName = user2?.Nome;
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

            var rubricas = await _context.Rubrica.Where(u => u.DescontoId == desconto.CodDesconto).FirstOrDefaultAsync();

            if (rubricas != null)
            {
                TempData["ErrorMessage"] = "Apagar Desconto não é possivel. Já existem Rúbricas associadas ao Desconto.";
                return RedirectToPage("./Erro");
            }

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
