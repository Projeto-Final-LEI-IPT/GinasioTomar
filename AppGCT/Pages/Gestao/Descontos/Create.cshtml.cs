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

namespace AppGCT.Pages.Gestao.Descontos
{
    [Authorize(Roles = "Administrador")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

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
            Desconto.EstadoDesconto = "A";
            Desconto.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            Desconto.IdCriacao = userId;
            Desconto.DataModificacao = DateTime.MinValue;
            Desconto.IdModificacao = "";
            _context.Desconto.Add(Desconto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
