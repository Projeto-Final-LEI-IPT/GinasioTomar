using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AppGCT.Areas.Identity.Data;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador123")]
    public class DeleteModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public DeleteModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [TempData]
        public string StatusMessageFinal1 { get; set; }

        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricao.Include(i => i.Atleta).Include(i => i.Periodo).Include(i => i.Class).Include(i => i.Descont)
                                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (inscricao == null)
            {
                return NotFound();
            }
            else 
            {
                Inscricao = inscricao;
                var user = await _userManager.FindByIdAsync(Inscricao.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Inscricao.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }
            var inscricao = await _context.Inscricao.FindAsync(id);

            if (inscricao != null)
            {
                Inscricao = inscricao;
                // Verifca se para inscrição existe pelo menos um mensalidade lançada, e se sim, não deixa Apagar
                bool JaCobrancasLancadas = await _context.PlanoMensalidade
                                                         .AnyAsync(i => i.GinastaId == Inscricao.GinastaId &&
                                                                        i.EpocaId == Inscricao.EpocaId &&
                                                                        i.ILancado == "S");
                if (!JaCobrancasLancadas)
                {
                    // Obtem planoMensalidade associados
                    var planoMensalidades = await _context.PlanoMensalidade
                        .Where(p => p.GinastaId == Inscricao.GinastaId && p.EpocaId == Inscricao.EpocaId)
                        .ToListAsync();
                    //remove planoMensalidades
                    _context.PlanoMensalidade.RemoveRange(planoMensalidades);
                    //remove inscrição
                    _context.Inscricao.Remove(Inscricao);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    StatusMessageFinal1 = "Mensalidades já lançadas impedem apagar Inscrição";
                    return RedirectToPage("./Delete", new { id = Inscricao.Id });
                }
            }

            return RedirectToPage("./Index", new { id = Inscricao.GinastaId });
        }
    }
}
