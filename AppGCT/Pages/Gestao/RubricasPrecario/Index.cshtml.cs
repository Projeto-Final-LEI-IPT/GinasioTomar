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

namespace AppGCT.Pages.Gestao.RubricasPrecario
{
    [Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<Rubrica> Rubrica { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rubrica != null)
            {
                Rubrica = await _context.Rubrica
                .Include(r => r.Discount)
                .Include(r => r.Modalidade).ToListAsync();
            }
        }
    }
}
