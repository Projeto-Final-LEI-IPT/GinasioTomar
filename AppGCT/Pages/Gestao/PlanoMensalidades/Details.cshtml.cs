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

namespace AppGCT.Pages.Inscricoes.PlanoMensalidades
{
    [Authorize(Roles = "Administrador")]
    public class DetailsModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public DetailsModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public PlanoMensalidade PlanoMensalidade { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PlanoMensalidade == null)
            {
                return NotFound();
            }

            var planomensalidade = await _context.PlanoMensalidade.Include(i => i.Aluno)
                                                                  .Include(i => i.Epoca)
                                                                  .FirstOrDefaultAsync(m => m.IdPlanoM == id);
            if (planomensalidade == null)
            {
                return NotFound();
            }
            else 
            {
                PlanoMensalidade = planomensalidade;
                var user = await _userManager.FindByIdAsync(PlanoMensalidade.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(PlanoMensalidade.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }
    }
}
