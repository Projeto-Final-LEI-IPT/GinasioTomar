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

namespace AppGCT.Pages.Gestao.Metodos
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

        public MetodoPagamento MetodoPagamento { get; set; } = default!;
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.MetodoPagamento == null)
            {
                return NotFound();
            }

            var metodopagamento = await _context.MetodoPagamento.FirstOrDefaultAsync(m => m.CodMetodo == id);
            if (metodopagamento == null)
            {
                return NotFound();
            }
            else 
            {
                MetodoPagamento = metodopagamento;
                var user = await _userManager.FindByIdAsync(MetodoPagamento.IdCriacao);
                IdCriacaoName = user?.Nome;
                var user2 = await _userManager.FindByIdAsync(MetodoPagamento.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            return Page();
        }
    }
}
