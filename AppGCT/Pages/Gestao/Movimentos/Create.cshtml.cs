using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Gestao.Movimentos
{
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AtletaMovimentoId"] = new SelectList(_context.Ginasta, "Id", "EstadoGinasta");
        ViewData["MetodoPagamentoId"] = new SelectList(_context.MetodoPagamento, "CodMetodo", "CodMetodo");
        ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["RubricaId"] = new SelectList(_context.Rubrica, "CodRubrica", "CodRubrica");
            return Page();
        }

        [BindProperty]
        public Movimento Movimento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Movimento == null || Movimento == null)
            {
                return Page();
            }

            _context.Movimento.Add(Movimento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
