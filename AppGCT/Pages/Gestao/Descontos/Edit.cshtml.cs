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
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;

namespace AppGCT.Pages.Gestao.Descontos
{
    [Authorize(Roles = "Administrador")]
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public EditModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Desconto Desconto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Desconto == null)
            {
                return NotFound();
            }

            var desconto =  await _context.Desconto.FirstOrDefaultAsync(m => m.CodDesconto == id);
            if (desconto == null)
            {
                return NotFound();
            }
            Desconto = desconto;
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

            _context.Attach(Desconto).State = EntityState.Modified;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            Desconto.IdModificacao = userId;
            Desconto.DataModificacao = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescontoExists(Desconto.CodDesconto))
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

        private bool DescontoExists(string id)
        {
          return (_context.Desconto?.Any(e => e.CodDesconto == id)).GetValueOrDefault();
        }
    }
}
