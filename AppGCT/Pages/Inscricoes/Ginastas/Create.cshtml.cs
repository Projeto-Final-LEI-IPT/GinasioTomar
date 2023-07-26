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
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AppGCT.Pages.Inscricoes.Ginastas
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class CreateModel : PageModel
    {

        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        private async Task<bool> NIFValido(string nif)
        {
            if (string.IsNullOrEmpty(nif) || nif.Length != 9 || !Regex.IsMatch(nif, @"^\d{9}$"))
            {
                return false;
            }

            int[] weight = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int sum = 0;

            for (int i = 0; i < 8; i++)
            {
                sum += (nif[i] - '0') * weight[i];
            }

            int checkDigit = 11 - (sum % 11);
            if (checkDigit >= 10)
            {
                checkDigit = 0;
            }

            return (checkDigit == nif[8] - '0');
        }


        public IActionResult OnGet()
        {
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

        [BindProperty]
        public Ginasta Ginasta { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile imageFile)
        {
            ModelState.Remove("Ginasta.EstadoGinasta"); // Remove validação para o campo EstadoGinasta que não é visivel
            ModelState.Remove("Ginasta.Foto"); // Remove validação para o campo Foto (se vazio)
            ModelState.Remove("imageFile"); // Remove validação para o imageFile (se vazio)
            Ginasta.IdCriacao = User.Identity.GetUserId(); 
            Ginasta.DataCriacao = DateTime.Now;
            Ginasta.IdModificacao = "";
            Ginasta.EstadoGinasta = "A";
            Ginasta.DataModificacao = DateTime.MinValue;

            if (!ModelState.IsValid || _context.Ginasta == null || Ginasta == null)
            {
                return Page();
            }

            //valida NIF
            if (!await NIFValido(Ginasta.NIF))
            {
                ModelState.AddModelError("Ginasta.NIF", "NIF é inválido");
                OnGet();
                return Page();
            }

            //valida NIF(EE)
            if (Ginasta.NIFEE != null)
            {
                if (!await NIFValido(Ginasta.NIFEE))
                {
                    ModelState.AddModelError("Ginasta.NIFEE", "NIF EE é inválido");
                    OnGet();
                    return Page();
                }
            }
            

            // Read the uploaded image file from the form
            //var imageFile = Request.Form.Files.FirstOrDefault();

            if (imageFile != null && imageFile.Length > 0)
            {
                // Convert the image to a byte array and store it in the Ginasta model
                using (var ms = new MemoryStream())
                {
                    imageFile.CopyTo(ms);
                    Ginasta.Foto = ms.ToArray();
                }
            }
            _context.Ginasta.Add(Ginasta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
