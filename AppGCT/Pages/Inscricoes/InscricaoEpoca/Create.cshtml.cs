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
            ViewData["ClasseId"] = new SelectList(_context.Classe.Where(i => i.EstadoClasse == "A"), "IdClasse", "NomeClasse");

            ViewData["BackId"] = id;
            return Page();
        }

        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /// Algoritmo para cálculo de Anos entre duas datas
            /// https://stackoverflow.com/questions/4127363/date-difference-in-years-using-c-sharp
            DateTime zeroTime = new DateTime(1, 1, 1);

            DateTime a = _context.Ginasta.Where(i => i.Id == Inscricao.GinastaId).FirstOrDefault().DtNascim;
            DateTime c = _context.Epoca.Where(i => i.IdEpoca == Inscricao.EpocaId).FirstOrDefault().DataFim;
            DateTime b = new DateTime(c.Year, 8, 31);

            TimeSpan span = b - a;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            int years = (zeroTime + span).Year - 1;

            Inscricao.IdadeAgosto = years;
            Inscricao.IConsentimento = "N";
            Inscricao.DtExamMed = DateTime.MinValue;
            Inscricao.ILeituraObrig = "N";
            Inscricao.IExamMed = "N";
            Inscricao.DtExamMed = DateTime.MinValue;
            Inscricao.IFicFGP = "N";
            Inscricao.DtFicFGP = DateTime.MinValue;
            Inscricao.ISeguro = "N";
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
