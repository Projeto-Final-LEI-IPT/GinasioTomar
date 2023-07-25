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
using System.Security.Claims;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public DetailsModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Inscricao Inscricao { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id == null || _context.Inscricao == null)
            {
                return RedirectToPage("./AcessDenied");
            }

            if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
            {
                var inscricao = await _context.Inscricao.Include(i => i.Atleta).Include(i => i.Periodo).Include(i => i.Class).Include(i => i.Descont)
                                                     .FirstOrDefaultAsync(m => m.Id == id);
                if (inscricao == null)
                {
                    return RedirectToPage("./AcessDenied");
                }
                Inscricao = inscricao;
                var user = await _userManager.FindByIdAsync(Inscricao.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Inscricao.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            else
            {
                var inscricao = await _context.Inscricao.Include(i => i.Atleta).Include(i => i.Periodo).Include(i => i.Class).Include(i => i.Descont)
                                     .FirstOrDefaultAsync(m => m.Id == id && m.Atleta.UtilizadorId == userId);

                if (inscricao == null)
                {
                    return RedirectToPage("./AcessDenied");
                }

                Inscricao = inscricao;
                var user = await _userManager.FindByIdAsync(Inscricao.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Inscricao.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }

            return Page();
        }
    }
}
