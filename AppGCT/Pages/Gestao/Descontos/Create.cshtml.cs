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
using System.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Gestao.Descontos
{
    [Authorize(Roles = "Administrador")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private async Task<bool> ValidaDesconto()
        {
            if (_context.Desconto == null || Desconto == null)
            {
                return false;
            }

            // Valida se o códido desconto já existe na BD
            if (await _context.Desconto.AnyAsync(e => e.CodDesconto == Desconto.CodDesconto))
            {
                ModelState.AddModelError("Desconto.CodDesconto", "Código Desconto já existente.");
                return false;
            }

            // Valida se o descrição desconto já existe na BD
            if (await _context.Desconto.AnyAsync(e => e.DescDesconto == Desconto.DescDesconto))
            {
                ModelState.AddModelError("Desconto.DescDesconto", "Já existe um Desconto com esta descrição.");
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
        public Desconto Desconto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Desconto == null || Desconto == null)
            {
                return Page();
            }
            if (!await ValidaDesconto())
            {
                return Page();
            }
            Desconto.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Desconto.IdCriacao = userId;
            Desconto.DataModificacao = DateTime.MinValue;
            Desconto.IdModificacao = "";
            _context.Desconto.Add(Desconto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
