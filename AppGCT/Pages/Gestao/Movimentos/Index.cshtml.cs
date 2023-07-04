using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Gestao.Movimentos
{
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
                Movimento = await _context.Movimento
                .Include(m => m.Atleta)
                .Include(m => m.FormaPagamento)
                .Include(m => m.Socio)
                .Include(m => m.TipoDespesa).ToListAsync();
            }
        }
    }
}
