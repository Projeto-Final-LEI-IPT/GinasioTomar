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

namespace AppGCT.Pages.Gestao.RubricasPrecario
{
    [Authorize(Roles = "Administrador")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        private async Task<bool> ValidaRubrica()
        {
            if (_context.Rubrica == null || Rubrica == null)
            {
                return false;
            }

            // Valida se o codRubrica já existe na BD
            if (await _context.Rubrica.AnyAsync(e => e.CodRubrica == Rubrica.CodRubrica))
            {
                ModelState.AddModelError("Rubrica.CodRubrica", "Já existe uma rúbrica para o código inserido");
                return false;
            }

            // Validações se Classe não estive preenchida
            if (Rubrica.ClasseId.Equals(null))
            {
                if (Rubrica.DescontoId != null)
                {
                    ModelState.AddModelError("ErroDesconto", "Desconto só pode ser preenchido se Classe preenchido");
                    return false;
                }
                    
            }

            return true;
        }
        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var descontos = _context.Desconto.ToList();
            descontos.Insert(0, new Desconto
            {
                CodDesconto = "",
                DescDesconto = "Seleccionar Desconto"

            });

            ViewData["DescontoId"] = new SelectList(descontos, "CodDesconto", "DescDesconto");

            var classes = _context.Classe.ToList();
            classes.Insert(0, new Classe
            {
                NomeClasse = "Seleccionar Classe"

            });

            ViewData["ClasseId"] = new SelectList(classes, "IdClasse", "NomeClasse");
            return Page();

        }

        [BindProperty]
        public Rubrica Rubrica { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rubrica == null || Rubrica == null)
            {
                return Page();
            }

          if (!await ValidaRubrica())
            {
                return Page();
            }

            Rubrica.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            Rubrica.IdCriacao = userId;
            Rubrica.DataModificacao = DateTime.MinValue;
            Rubrica.IdModificacao = "";

            _context.Rubrica.Add(Rubrica);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
