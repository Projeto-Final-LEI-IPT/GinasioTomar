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

        public async Task OnGetAsync()
        {
            if (_context.PlanoMensalidade != null)
            {
                PlanoMensalidade = await _context.PlanoMensalidade
                .Include(p => p.Aluno)
                .Include(p => p.Epoca).ToListAsync();
            }
        }
    }
}
