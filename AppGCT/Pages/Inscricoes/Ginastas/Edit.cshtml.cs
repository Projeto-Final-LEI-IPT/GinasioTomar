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
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AppGCT.Pages.Inscricoes.Ginastas
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
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

            if (User.IsInRole("Administrador") || User.IsInRole("Administrador"))
            {
                ViewData["UtilizadorId"] = new SelectList(_context.Users.Where(x => x.NumSocio != " "), "Id", "ID_Description");
            }
            else
            {
                /// Utilizamos LINQ para ir buscar apenas o USERID autenticado, quando o ROLE é <> Administrador                
                ViewData["UtilizadorId"] = new SelectList(_context.Users.Where(x => x.Id == User.Identity.GetUserId()), "Id", "ID_Description");
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Ginasta.IdModificacao = User.Identity.GetUserId(); ;
            Ginasta.DataModificacao = DateTime.Now;
        
            if (imageFile != null && imageFile.Length > 0)
            {
                // Convert the image to a byte array and store it in the Ginasta model
                using (var ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    Ginasta.Foto = ms.ToArray();
                }
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
