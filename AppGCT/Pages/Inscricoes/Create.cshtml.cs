using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Inscricoes
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
        ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "Id");
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

            _context.Ginasta.Add(Ginasta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
