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
using Microsoft.AspNetCore.Identity;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Pages.Gestao.Classes
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
        public Classe Classe { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Classe == null)
            {
                return NotFound();
            }

            var classe = await _context.Classe.FirstOrDefaultAsync(m => m.IdClasse == id);

            if (classe == null)
            {
                return NotFound();
            }
            else 
            {
                Classe = classe;
                if (Classe.IdCriacao == "SEED")
                {
                    IdCriacaoName = "SEED INICIAL";
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(Classe.IdCriacao);
                    IdCriacaoName = user?.Nome;
                }
                    
                var user2 = await _userManager.FindByIdAsync(Classe.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Classe == null)
            {
                return NotFound();
            }
            var classe = await _context.Classe.FindAsync(id);

            var rubricas = await _context.Rubrica.Where(u => u.ClasseId == classe.IdClasse).FirstOrDefaultAsync();

            if (rubricas != null)
            {
                TempData["ErrorMessage"] = "Apagar Classe não é possivel. Já existem Rúbricas associadas à Classe.";
                return RedirectToPage("./Erro");
            }

            if (classe != null)
            {
                Classe = classe;
                _context.Classe.Remove(Classe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
