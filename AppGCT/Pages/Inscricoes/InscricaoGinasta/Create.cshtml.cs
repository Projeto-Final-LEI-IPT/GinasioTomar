using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Inscricoes.InscricaoGinasta
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
            if (User.IsInRole("Administrador"))
            {
                ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "NumSocio");
            }
            else
            {
                /// Utilizamos LINQ para ir buscar apenas o USERID autenticado, quando o ROLE é <> Administrador                
                ViewData["UtilizadorId"] = new SelectList(_context.Users.Where(x => x.Id == User.Identity.GetUserId()), "Id", "NumSocio");
            }
            return Page();
        }

        [BindProperty]
        public Ginasta Ginasta { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Ginasta == null || Ginasta == null)
            {
                return Page();
            }

            Ginasta.UtilizadorId = User.Identity.GetUserId();
            _context.Ginasta.Add(Ginasta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
