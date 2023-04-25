using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNet.Identity;

namespace AppGCT.Pages.Inscricoes.Ginastas
{
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<Ginasta> Ginasta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ginasta != null)
            {
                string userId = User.Identity.GetUserId();
                if (User.IsInRole("Administrador"))
                {
                    Ginasta = await _context.Ginasta
                    .Include(g => g.Socio).ToListAsync();
                }
                else
                {
                    Ginasta = await _context.Ginasta
                        .Where(g => g.UtilizadorId.Equals(userId))
                    .Include(g => g.Socio).ToListAsync();
                }
            }
        }
    }
}
