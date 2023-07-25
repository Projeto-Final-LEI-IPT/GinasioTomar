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
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Ginasio.Epocas
{
    [Authorize(Roles = "Administrador")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        private async Task<bool> ValidaEpoca()
        {
            if (_context.Epoca == null || Epoca == null)
            {
                return false;
            }

            // Valida se o NomeÉpoca já existe na BD
            if (await _context.Epoca.AnyAsync(e => e.NomeEpoca == Epoca.NomeEpoca))
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
                                (e.DataInicio >= Epoca.DataInicio && e.DataInicio <= Epoca.DataFim) ||
                                (e.DataFim >= Epoca.DataInicio && e.DataFim <= Epoca.DataFim) ||
                                (Epoca.DataInicio >= e.DataInicio && Epoca.DataInicio <= e.DataFim) ||
                                (Epoca.DataFim >= e.DataInicio && Epoca.DataFim <= e.DataFim));

            if (isOverlapping)
            {
                ModelState.AddModelError("Epoca.DataInicio", "Já existe uma época com datas sobrepostas.");
                return false;
            }

            return true;
        }
        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Epoca = new Epoca(); 
            // Apresenta valores por defeito

            //data inicio
            Epoca.DataInicio = new DateTime(DateTime.Now.Year, 9, 1);

            //data fim
            DateTime currentDate = DateTime.Now;
            DateTime newDate = currentDate.AddYears(1);
            Epoca.DataFim = new DateTime(newDate.Year, 7, 31);

            //Nome época
            Epoca.NomeEpoca = DateTime.Today.Year + "/" + @DateTime.Today.AddYears(1).Year;
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

            if (!await ValidaEpoca())
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
