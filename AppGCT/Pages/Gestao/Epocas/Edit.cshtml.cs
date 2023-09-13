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
using System.Security.Claims;

namespace AppGCT.Pages.Ginasio.Epocas
{
    [Authorize(Roles = "Administrador")]
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        [TempData]
        public string StatusMessageFinal { get; set; }

        private async Task<bool> ValidaEpoca()
        {
            if (_context.Epoca == null || Epoca == null)
            {
                return false;
            }

            // Valida se o NomeÉpoca já existe na BD (exceção feita a ela própria)
            if (await _context.Epoca.AnyAsync(e => e.NomeEpoca == Epoca.NomeEpoca && e.IdEpoca != Epoca.IdEpoca))
            {
                ModelState.AddModelError("Epoca.NomeEpoca", "Já existe uma época com esse nome.");
                return false;
            }

            // Valida se Data Fim é inferior à Data Inicio
            if (Epoca.DataFim < Epoca.DataInicio)
            {
                ModelState.AddModelError("Epoca.DataFim", "A data fim deve ser superior à data início.");
                return false;
            }

            var isOverlapping = _context.Epoca.Any(e =>
                                ((e.DataInicio >= Epoca.DataInicio && e.DataInicio <= Epoca.DataFim) ||
                                (e.DataFim >= Epoca.DataInicio && e.DataFim <= Epoca.DataFim) ||
                                (Epoca.DataInicio >= e.DataInicio && Epoca.DataInicio <= e.DataFim) ||
                                (Epoca.DataFim >= e.DataInicio && Epoca.DataFim <= e.DataFim)) &&
                                (e.IdEpoca != Epoca.IdEpoca));

            if (isOverlapping)
            {
                ModelState.AddModelError("Epoca.DataInicio", "Já existe uma época com datas sobrepostas.");
                return false;
            }

            return true;
        }

        public EditModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Epoca Epoca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Epoca == null)
            {
                return NotFound();
            }

            var epoca =  await _context.Epoca.FirstOrDefaultAsync(m => m.IdEpoca == id);
            if (epoca == null)
            {
                return NotFound();
            }
            Epoca = epoca;
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
            if (!await ValidaEpoca())
            {
                return Page();
            }
            _context.Attach(Epoca).State = EntityState.Modified;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Epoca.IdModificacao = userId;
            Epoca.DataModificacao = DateTime.Now;
            // Só permite Finalizar época após a data de fim ser ultrapassada
            if(Epoca.EstadoEpoca == "F" &&
               Epoca.DataFim     < DateTime.Now)
            {
                StatusMessageFinal = "Só é possível finalizar época após data de fim";
                return RedirectToPage("./Edit", new { id = Epoca.IdEpoca });
            }
            // Verifica se existem Mensalidades lançadas para época
               // Se sim, não deixa cancelar a época
            bool JaCobrancasLancadas = await _context.PlanoMensalidade
                                                     .AnyAsync(i => i.EpocaId == Epoca.IdEpoca &&
                                                                    i.ILancado == "S");
            if (Epoca.EstadoEpoca == "C" &&
                JaCobrancasLancadas)
            {
                StatusMessageFinal = "Não é possível cancelar época pois já existem mensalidades lançadas";
                return RedirectToPage("./Edit", new { id = Epoca.IdEpoca });
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpocaExists(Epoca.IdEpoca))
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

        private bool EpocaExists(int id)
        {
          return (_context.Epoca?.Any(e => e.IdEpoca == id)).GetValueOrDefault();
        }
    }
}
