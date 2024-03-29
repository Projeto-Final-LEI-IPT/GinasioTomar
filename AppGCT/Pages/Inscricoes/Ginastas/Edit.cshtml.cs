﻿using System.Collections.Generic;
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
using System.Text.RegularExpressions;

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
            //Enviar para pagina campo do IIrmaos
            ViewData["FlagIrmaos"] = Ginasta.IIrmaos;

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
            //data nascimento superior a 1900
            if (Ginasta.DtNascim.Year < 1900)
            {
                ModelState.AddModelError("Ginasta.DtNascim", "Data Nascimento(ano) tem de ser superior ou igual a 1900");
                OnGetAsync(Ginasta.Id);
                return Page();
            }
            //valida data nascimento
            if (Ginasta.DtNascim.Date >= DateTime.Now.Date)
            {
                ModelState.AddModelError("Ginasta.DtNascim", "Data Nascimento tem de ser inferior à data atual");
                OnGetAsync(Ginasta.Id);
                return Page();
            }

            //valida NIF
            if (!await NIFValido(Ginasta.NIF))
            {
                ModelState.AddModelError("Ginasta.NIF", "NIF é inválido");
                OnGetAsync(Ginasta.Id);
                return Page();
            }

            //valida NIF(EE)
            if (Ginasta.NIFEE != null)
            {
                if (!await NIFValido(Ginasta.NIFEE))
                {
                    ModelState.AddModelError("Ginasta.NIFEE", "NIF EE é inválido");
                    OnGetAsync(Ginasta.Id);
                    return Page();
                }
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
