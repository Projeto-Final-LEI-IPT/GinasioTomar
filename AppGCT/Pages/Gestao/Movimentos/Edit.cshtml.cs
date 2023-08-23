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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace AppGCT.Pages.Gestao.Movimentos
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
        public Movimento Movimento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movimento == null)
            {
                return NotFound();
            }

            var movimento =  await _context.Movimento.FirstOrDefaultAsync(m => m.Id == id);
            if (movimento == null)
            {
                return NotFound();
            }
            Movimento = movimento;
           ViewData["AtletaMovimentoId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
           ViewData["MetodoPagamentoId"] = new SelectList(_context.MetodoPagamento, "CodMetodo", "ID_DescrMetodo");
           ViewData["UtilizadorId"] = new SelectList(_context.Users.Where(i => i.Id == Movimento.UtilizadorId), "Id", "ID_Description");
           ViewData["RubricaId"] = new SelectList(_context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId), "CodRubrica", "ID_DescriptionRubrica");

            // Passamos TipoRubrica para a View, para sabermos que cmapo mostrar (Nuemro de fatura ou Nota de Crédito)
            var tipoRub = _context.Rubrica.Where(i => i.CodRubrica == movimento.RubricaId).FirstOrDefault().TipoRubrica;

            ViewData["TipoRubrica"] = tipoRub;
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
            var movimentoAtualizar = _context.Movimento.Where(i => i.Id == Movimento.Id).FirstOrDefault();
            movimentoAtualizar.DtMovimento = Movimento.DtMovimento;
            movimentoAtualizar.DataModificacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            movimentoAtualizar.IdModificacao = userId;

            if (!Movimento.NumFatura.IsNullOrEmpty())
            {
                movimentoAtualizar.NumFatura = Movimento.NumFatura;
            }

            if (!Movimento.NumNotaCredito.IsNullOrEmpty())
            {
                movimentoAtualizar.NumNotaCredito = Movimento.NumNotaCredito;
            }


            _context.Update(movimentoAtualizar);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

    }
}
