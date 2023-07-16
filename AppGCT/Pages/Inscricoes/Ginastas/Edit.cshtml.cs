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
            string userId = User.Identity.GetUserId();

            if (id == null || _context.Ginasta == null)
            {
                return RedirectToPage("./AcessDenied");
            }

            if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
            {
                var ginasta = await _context.Ginasta.FirstOrDefaultAsync(m => m.Id == id);
                if (ginasta == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Ginasta = ginasta;
            }
            else
            {
                var ginasta = await _context.Ginasta.FirstOrDefaultAsync(m => m.Id == id && m.UtilizadorId == userId);
                if (ginasta == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Ginasta = ginasta;
            }


            if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
            {
                ViewData["UtilizadorId"] = new SelectList(_context.Users.Where(x => x.NumSocio != " " && x.EstadoUtilizador == "A"), "Id", "ID_Description");
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
            ModelState.Remove("Ginasta.Foto"); // Remove validação para o campo Foto (se vazio)
            ModelState.Remove("imageFile"); // Remove validação para o imageFile (se vazio)
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Ginasta.IdModificacao = User.Identity.GetUserId(); ;
            Ginasta.DataModificacao = DateTime.Now;

            // Se não é carregada nova imagem mantêm a anterior (se existir)
            if (imageFile == null || imageFile.Length == 0)
            {
                // If no image is uploaded, retrieve the existing photo from the database
                var existingGinasta = await _context.Ginasta.AsNoTracking().FirstOrDefaultAsync(g => g.Id == Ginasta.Id);
                Ginasta.Foto = existingGinasta.Foto;
            }
            else
            {
                // converte a imagem e guarda na base de dados
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
