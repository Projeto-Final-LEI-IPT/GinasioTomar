using AppGCT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Precario
{
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public IList<Rubrica> Rubrica { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rubrica != null)
            {
                Rubrica = await _context.Rubrica.Where(i => i.IPrecario == "S")
                                                .OrderBy(i => i.OrdemPrecario)
                                                .ToListAsync();
            }
        }
    }
}
