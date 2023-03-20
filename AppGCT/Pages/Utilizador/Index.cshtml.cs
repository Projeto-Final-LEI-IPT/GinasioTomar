using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;

namespace AppGCT.Pages.Utilizador
{
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<Utilizadores> Utilizadores { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Utilizadores != null)
            {
                Utilizadores = await _context.Utilizadores.ToListAsync();
            }
        }
    }
}
