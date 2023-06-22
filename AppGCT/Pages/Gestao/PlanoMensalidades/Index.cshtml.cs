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
using Microsoft.AspNet.Identity;

namespace AppGCT.Pages.Inscricoes.PlanoMensalidades
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<PlanoMensalidade> PlanoMensalidade { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(int idGinasta, int idEpoca)
        {
            if (_context.PlanoMensalidade != null)
            {
                string userId = User.Identity.GetUserId();
                if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
                {
                    PlanoMensalidade = await _context.PlanoMensalidade
                                       .Include(p => p.Aluno)
                                       .Include(p => p.Epoca)
                                       .ToListAsync();
                }
                else
                {
                    var ginasta = await _context.Ginasta
                                                .Include(g => g.Socio)
                                                .FirstOrDefaultAsync(g => g.UtilizadorId == userId && g.Id == idGinasta);

                    if (ginasta != null)
                    {

                        PlanoMensalidade = await _context.PlanoMensalidade
                                      .Include(p => p.Aluno)
                                      .Include(p => p.Epoca)
                                      .Where(p => p.EpocaId == idEpoca && p.GinastaId == idGinasta)
                                      .ToListAsync();
                    }else
                    {
                        return RedirectToPage("./AcessDenied");
                    }
                }
            }
            return Page();
        }
    }
}
