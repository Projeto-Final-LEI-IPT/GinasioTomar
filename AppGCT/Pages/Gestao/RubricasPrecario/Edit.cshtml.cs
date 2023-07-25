using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AppGCT.Pages.Gestao.RubricasPrecario
{
    [Authorize(Roles = "Administrador")]
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        private async Task PopulaDropdownLists()
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
        }
        private async Task<bool> ValidaRubrica()
        {
            if (_context.Rubrica == null || Rubrica == null)
            {
                return false;
            }

            // Validações se Classe não estive preenchida
            if (Rubrica.ClasseId.Equals(null))
            {
                if (Rubrica.DescontoId != null)
                {
                    ModelState.AddModelError("Rubrica.DescontoId", "Desconto só pode ser preenchido se Classe preenchido");
                    return false;
                }
            }

            // Validações se rubrica com valor unitário(IVlrUnit = S) e valor inferior ou igual a 0
            if (Rubrica.IVlrUnit == "S" && Rubrica.ValorUnitario <= 0)
            {
                ModelState.AddModelError("Rubrica.ValorUnitario", "Valor unitário tem de ser superior a 0,00€");
                return false;
            }
            return true;
        }
        public EditModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rubrica Rubrica { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Rubrica == null)
            {
                return NotFound();
            }

            var rubrica =  await _context.Rubrica.FirstOrDefaultAsync(m => m.CodRubrica == id);
            if (rubrica == null)
            {
                return NotFound();
            }
            Rubrica = rubrica;
            //popula drop down's
            await PopulaDropdownLists();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //popula drop down's
                await PopulaDropdownLists();
                return Page();
            }

            if (!await ValidaRubrica())
            {
                //popula drop down's
                await PopulaDropdownLists();
                return Page();
            }

            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            Rubrica.IdModificacao = userId;
            Rubrica.DataModificacao = DateTime.Now;
 
            _context.Attach(Rubrica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RubricaExists(Rubrica.CodRubrica))
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

        private bool RubricaExists(string id)
        {
          return (_context.Rubrica?.Any(e => e.CodRubrica == id)).GetValueOrDefault();
        }
    }
}
