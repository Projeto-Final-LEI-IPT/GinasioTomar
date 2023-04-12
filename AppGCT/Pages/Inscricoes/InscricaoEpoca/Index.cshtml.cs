using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<Inscricao> Inscricao { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inscricao != null)
            {
                Inscricao = await _context.Inscricao
                .Include(i => i.Atleta).ToListAsync();
            }
        }
    }
}
