using AppGCT.Areas.Identity.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Gestao.CobrancaMensalidades
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<Epoca> Epoca { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Epoca != null)
            {
                var currentdate = DateTime.Now;
                //obtem época em vigor
                Epoca = await _context.Epoca.Where(m => m.DataInicio <= currentdate && m.DataFim >= currentdate)
                                    .ToListAsync();
            }
        }
    }
}
