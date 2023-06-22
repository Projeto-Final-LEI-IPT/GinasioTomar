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

namespace AppGCT.Pages.Inscricoes.PlanoMensalidades
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
        public PlanoMensalidade PlanoMensalidade { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlanoMensalidade == null)
            {
                return NotFound();
            }

            var planomensalidade =  await _context.PlanoMensalidade.FirstOrDefaultAsync(m => m.IdPlanoM == id);
            if (planomensalidade == null)
            {
                return NotFound();
            }
            PlanoMensalidade = planomensalidade;
            ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
            ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
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

            // Valida se o Ginasta já está inscrito na época, só assim permite criar o plano
            var inscricao = await _context.Inscricao
                .FirstOrDefaultAsync(i => i.GinastaId == PlanoMensalidade.GinastaId && i.EpocaId == PlanoMensalidade.EpocaId);

            if (inscricao == null)
            {
                ModelState.AddModelError("PlanoMensalidade.GinastaId", "Ginasta não está inscrito na Época");
                ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
                ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
                return Page();
            }
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            PlanoMensalidade.IdModificacao = userId;
            PlanoMensalidade.DataModificacao = DateTime.Now;
            _context.Attach(PlanoMensalidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanoMensalidadeExists(PlanoMensalidade.IdPlanoM))
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

        private bool PlanoMensalidadeExists(int id)
        {
          return (_context.PlanoMensalidade?.Any(e => e.IdPlanoM == id)).GetValueOrDefault();
        }
    }
}
