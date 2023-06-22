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

namespace AppGCT.Pages.Inscricoes.PlanoMensalidades
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
        ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
        ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
            return Page();
        }

        [BindProperty]
        public PlanoMensalidade PlanoMensalidade { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PlanoMensalidade == null || PlanoMensalidade == null)
            {
                return Page();
            }
            PlanoMensalidade.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            PlanoMensalidade.IdCriacao = userId;
            PlanoMensalidade.DataModificacao = DateTime.MinValue;
            PlanoMensalidade.IdModificacao = "";
            _context.PlanoMensalidade.Add(PlanoMensalidade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
