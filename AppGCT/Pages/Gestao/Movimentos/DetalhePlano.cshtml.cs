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
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail;

namespace AppGCT.Pages.Gestao.Movimentos
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class DetathePlanoModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public DetathePlanoModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public Movimento Movimento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id.Equals(null) || _context.Movimento == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimento.Include(i => i.Socio)
                                        .Include(i => i.Atleta)
                                        .Include(i => i.TipoDespesa)
                                        .Include(i => i.FormaPagamento)
                                        .FirstOrDefaultAsync(m => m.Id.Equals(id));



            // Só o Sócio a quem pertence o Movimento é que pode consultar o movimento
            if (User.IsInRole("Sócio"))
            {
                string userId = User.Identity.GetUserId();
                if (userId != movimento.UtilizadorId)
                {
                    return RedirectToPage("./AcessDenied");
                }
            }

            if (movimento == null)
            {
                return NotFound();
            }
            else
            {
                Movimento = movimento;
                var user = _context.Users.Where(i => i.Id == Movimento.IdCriacao);
                IdCriacaoName = user?.FirstOrDefault().Nome;
                var user2 = _context.Users.Where(i => i.Id == Movimento.IdModificacao);
                if (!user2.IsNullOrEmpty()) { 
                IdModificacaoName = user2.FirstOrDefault().Nome;
                }
            }
            return Page();
        }
    }
}
