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
                    ModelState.AddModelError("Rubrica.DescontoId", "Desconto só pode ser preenchido se Classe preenchido");
                    return false;
                }
            }

            // Validações se rubrica com valor unitário(IVlrUnit = S) e valor inferior ou igual a 0 e desconto vazio
            if (Rubrica.IVlrUnit == "S" && (Rubrica.ValorUnitario <= 0 || Rubrica.ValorUnitario == null ) &&
                Rubrica.DescontoId == null )
            {
                ModelState.AddModelError("Rubrica.ValorUnitario", "Valor unitário tem de ser superior a 0,00€");
                return false;
            }
            // Validações se rubrica com valor unitário(IVlrUnit = S) e valor inferior ou igual a 0 e desconto preenchido
            if (Rubrica.IVlrUnit == "S" && (Rubrica.ValorUnitario < 0 || Rubrica.ValorUnitario == null) &&
                Rubrica.DescontoId != null && Rubrica.TipoRubrica == "G")
            {
                ModelState.AddModelError("Rubrica.ValorUnitario", "Valor unitário tem de ser superior ou igual a 0,00€");
                return false;
            }

            // Só é possível haver uma Rúbrica do Tipo Sócio Ativa
            // isto é importante para que seja possível lançar as quotas automaticamente, em Janeiro de cada ano
            // caso contrário não saberíamos qual lançar
            if (Rubrica.TipoRubrica   == "S" &&
               Rubrica.EstadoRubrica == "A")
            {
                bool rubQuotaAtiva = await _context.Rubrica.AnyAsync(e => e.TipoRubrica == "S" &&
                                                                          e.EstadoRubrica == "A");
                if (rubQuotaAtiva)
                {
                    ModelState.AddModelError("Rubrica.TipoRubrica", "Não é possível haver mais de uma rúbrica do tipo " +
                                                                    "Sócio (Quota) ativa, em simultâneo. Crie a rúbrica como " +
                                                                    "Inativa, ou opte por inativar a que atualmente está Ativa");
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
                //faz refresh das dropdown's
                OnGet();
                return Page();
            }

          if (!await ValidaRubrica())
            {
                //faz refresh das dropdown's
                OnGet();
                return Page();
            }
            // Validações se rubrica com valor unitário(IVlrUnit = N)
            if (Rubrica.IVlrUnit == "N")
            {
                Rubrica.ValorUnitario = 0;
            }

            Rubrica.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Rubrica.IdCriacao = userId;
            Rubrica.DataModificacao = DateTime.MinValue;
            Rubrica.IdModificacao = "";

            _context.Rubrica.Add(Rubrica);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
