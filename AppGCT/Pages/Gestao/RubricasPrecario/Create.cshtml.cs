using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Gestao.RubricasPrecario
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
            var descontos = _context.Desconto.ToList();
            descontos.Insert(0, new Desconto
            {
                CodDesconto = "",
                DescDesconto = ""

            });

            ViewData["DescontoId"] = new SelectList(descontos, "CodDesconto", "CodDesconto");
            return Page();



            // ViewData["DescontoId"] = new SelectList(_context.Desconto, "CodDesconto", "CodDesconto", null);
            // return Page();
        }

        [BindProperty]
        public Rubrica Rubrica { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rubrica == null || Rubrica == null)
            {
                return Page();
            }

            _context.Rubrica.Add(Rubrica);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
