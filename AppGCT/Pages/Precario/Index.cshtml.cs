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
        public IList<Rubrica> Rubrica2 { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rubrica != null)
            {
                //obtêm apenas rubricas de preçário público associadas a classes
                Rubrica = await _context.Rubrica.Where(i => i.IPrecario == "S" && i.ClasseId != null)
                                                .Include(r => r.Modalidade)
                                                .OrderBy(i => i.OrdemPrecario)
                                                .ToListAsync();
                //obtêm outras rubricas de preçário público sem classe associada
                Rubrica2 = await _context.Rubrica.Where(i => i.IPrecario == "S" && i.ClasseId == null)
                                                .Include(r => r.Modalidade)
                                                .OrderBy(i => i.OrdemPrecario)
                                                .ToListAsync();
            }

        }
    }
}
