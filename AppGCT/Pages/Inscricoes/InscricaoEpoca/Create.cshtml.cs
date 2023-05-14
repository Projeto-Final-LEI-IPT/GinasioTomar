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
using Microsoft.AspNet.Identity;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            ViewData["GinastaId"] = new SelectList(_context.Ginasta.Where(i => i.Id == id), "Id", "ID_DescrGinasta");
            ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
            ViewData["BackId"] = id;
            return Page();
        }

        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Inscricao.IConsentimento = " ";
            Inscricao.DtExamMed = DateTime.MinValue;
            Inscricao.ILeituraObrig = " ";
            Inscricao.IExamMed = " ";
            Inscricao.DtExamMed = DateTime.MinValue;
            Inscricao.IFicFGP = " ";
            Inscricao.DtFicFGP = DateTime.MinValue;
            Inscricao.ISeguro = " ";
            Inscricao.IPagamInscricao = "N";
            Inscricao.IdCriacao = User.Identity.GetUserId();
            Inscricao.DataCriacao = DateTime.Now;
            Inscricao.IdModificacao = "0";
            Inscricao.DataModificacao = DateTime.MinValue;

            if (!ModelState.IsValid || _context.Inscricao == null || Inscricao == null)
            {
                return Page();
            }


            _context.Inscricao.Add(Inscricao);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Inscricoes/Ginastas/Index");
        }
    }
}
