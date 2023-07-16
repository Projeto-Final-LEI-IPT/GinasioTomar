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

namespace AppGCT.Pages.Gestao.Movimentos
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<Movimento> Movimento { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movimento != null)
            {
                string userId = User.Identity.GetUserId();
                if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
                {
                    Movimento = await _context.Movimento
                    .Include(m => m.Atleta)
                    .Include(m => m.FormaPagamento)
                    .Include(m => m.Socio)
                    .Include(m => m.TipoDespesa)
                    .ToListAsync();
                }
                else
                {
                    Movimento = await _context.Movimento
                    .Include(m => m.Atleta)
                    .Include(m => m.FormaPagamento)
                    .Include(m => m.Socio)
                    .Include(m => m.TipoDespesa).Where(m => m.UtilizadorId.Equals(userId))
                    .ToListAsync();
                }

            }
        }
    }
}
