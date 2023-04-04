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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Pages.Ginasio.Epocas
{
    [Authorize]
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
        public Epoca Epoca { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Epoca == null || Epoca == null)
            {
                return Page();
            }
            Epoca.EstadoEpoca = "A";
            Epoca.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Epoca.IdCriacao = userId;
            Epoca.DataModificacao = DateTime.MinValue;
            Epoca.IdModificacao = "";
            _context.Epoca.Add(Epoca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
