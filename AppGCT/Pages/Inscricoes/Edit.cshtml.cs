using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Inscricoes
{
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public EditModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ginasta Ginasta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ginasta == null)
            {
                return NotFound();
            }

            var ginasta =  await _context.Ginasta.FirstOrDefaultAsync(m => m.Id == id);
            if (ginasta == null)
            {
                return NotFound();
            }
            Ginasta = ginasta;
           ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ginasta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GinastaExists(Ginasta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GinastaExists(int? id)
        {
          return (_context.Ginasta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
