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
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Inscricoes.PlanoMensalidades
{
    [Authorize(Roles = "Administrador")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
        ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
            return Page();
        }

        [BindProperty]
        public PlanoMensalidade PlanoMensalidade { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.PlanoMensalidade == null || PlanoMensalidade == null)
            {
                return Page();
            }

            //Valida ILancado e idmovimento
            if (PlanoMensalidade.ILancado == "S")
            {
                //se movimento vazio
                if(PlanoMensalidade.IdMovimento == null)
                {
                    ModelState.AddModelError("PlanoMensalidade.IdMovimento", "Id Movimento não está preenchido");
                    ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
                    ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
                    return Page();
                }else
                //valida se movimento existe
                {
                    //obtem movimento
                    var movimento = await _context.Movimento
                                                .FirstOrDefaultAsync(r => r.PlanoMovimento == PlanoMensalidade.IdMovimento);
                    if (movimento == null)
                    {
                        ModelState.AddModelError("PlanoMensalidade.IdMovimento", "Id Movimento inexistente");
                        ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
                        ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
                        return Page();
                    }else
                    {
                        //valida se pertence ao mesmo ginasta e valor que estamos a tentar inserir
                        if( movimento.AtletaMovimentoId != PlanoMensalidade.GinastaId)
                        {
                            ModelState.AddModelError("PlanoMensalidade.IdMovimento", "Id Movimento não está associado ao Ginasta");
                            ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
                            ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
                            return Page();
                        }
                        if (movimento.ValorMovimento != PlanoMensalidade.ValorMensalidadeLanc)
                        {
                            ModelState.AddModelError("PlanoMensalidade.ValorMensalidadeLanc", "Valor é diferente do existente no movimento");
                            ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_DescrGinasta");
                            ViewData["EpocaId"] = new SelectList(_context.Epoca, "IdEpoca", "NomeEpoca");
                            return Page();
                        }
                    }
                }
            }else
            {
                PlanoMensalidade.ILancado = "N";
                PlanoMensalidade.ValorMensalidadeLanc = 0;
                PlanoMensalidade.IdMovimento = null;
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

            PlanoMensalidade.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            PlanoMensalidade.IdCriacao = userId;
            PlanoMensalidade.DataModificacao = DateTime.MinValue;
            PlanoMensalidade.IdModificacao = "";
            _context.PlanoMensalidade.Add(PlanoMensalidade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
