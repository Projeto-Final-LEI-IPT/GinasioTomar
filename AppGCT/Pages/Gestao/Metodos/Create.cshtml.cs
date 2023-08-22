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

namespace AppGCT.Pages.Gestao.Metodos
{
    [Authorize(Roles = "Administrador")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private async Task<bool> ValidaMetodo()
        {
            if (_context.MetodoPagamento == null || MetodoPagamento == null)
            {
                return false;
            }

            // Valida se o códido metodo já existe na BD
            if (await _context.MetodoPagamento.AnyAsync(e => e.CodMetodo == MetodoPagamento.CodMetodo))
            {
                ModelState.AddModelError("MetodoPagamento.CodMetodo", "Código Método Pagamento já existente.");
                return false;
            }

            // Valida se o nome metodo já existe na BD
            if (await _context.MetodoPagamento.AnyAsync(e => e.DescMetodo == MetodoPagamento.DescMetodo))
            {
                ModelState.AddModelError("MetodoPagamento.DescMetodo", "Já existe um Método Pagamento com esta descrição.");
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
        public MetodoPagamento MetodoPagamento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.MetodoPagamento == null || MetodoPagamento == null)
            {
                return Page();
            }
            if (!await ValidaMetodo())
            {
                return Page();
            }
            MetodoPagamento.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MetodoPagamento.IdCriacao = userId;
            MetodoPagamento.DataModificacao = DateTime.MinValue;
            MetodoPagamento.IdModificacao = "";
            _context.MetodoPagamento.Add(MetodoPagamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
