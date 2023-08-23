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
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace AppGCT.Pages.Gestao.Movimentos
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
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public Movimento Movimento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movimento == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimento.Include(i => i.Socio)
                                                    .Include(i => i.Atleta)
                                                    .Include(i => i.TipoDespesa)
                                                    .Include(i => i.FormaPagamento)
                                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (movimento == null)
            {
                return NotFound();
            }
            else
            {
                Movimento = movimento;
                var user = await _userManager.FindByIdAsync(Movimento.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(Movimento.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }
    }
}
