using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Gestao.Classes
{
    [Authorize(Roles = "Administrador")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private async Task<bool> ValidaClasse()
        {
            if (_context.Classe == null || Classe == null)
            {
                return false;
            }

            // Valida se o NomeClasse já existe na BD
            if (await _context.Classe.AnyAsync(e => e.NomeClasse == Classe.NomeClasse))
            {
                ModelState.AddModelError("Classe.NomeClasse", "Já existe uma Classe com esse nome.");
                return false;
            }

            return true;
        }

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Classe Classe { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Classe == null || Classe == null)
          {
             return Page();
          }

          if (!await ValidaClasse())
          {
             return Page();
          }
          Classe.DataCriacao = DateTime.Now;
          // obtem User ID logado
          var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
          Classe.IdCriacao = userId;
          Classe.DataModificacao = DateTime.MinValue;
          Classe.IdModificacao = "";
          _context.Classe.Add(Classe);
          await _context.SaveChangesAsync();

          return RedirectToPage("./Index");
        }
    }
}
