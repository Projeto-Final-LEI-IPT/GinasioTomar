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
using System.Data;

namespace AppGCT.Pages.Gestao.Descontos
{
    [Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        public string CodDescontoSort { get; set; }
        public string DescDescontoSort { get; set; }
        public string EstadoDescontoSort { get; set; }
        public string CurrentFilter { get; set; }
        public IList<Desconto> Desconto { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Desconto != null)
            {
                CodDescontoSort = String.IsNullOrEmpty(sortOrder) ? "coddesconto_desc" : "";
                DescDescontoSort = sortOrder == "DescDesconto" ? "descdesconto_desc" : "DescDesconto";
                EstadoDescontoSort = sortOrder == "EstadoDesconto" ? "estadodesconto_desc" : "EstadoDesconto";

                CurrentFilter = searchString;

                IQueryable<Desconto> DescontoIQ = _context.Desconto.AsQueryable();

                if (!String.IsNullOrEmpty(searchString))
                {
                    DescontoIQ = DescontoIQ.Where(s => s.DescDesconto.ToUpper().Contains(searchString.ToUpper()));
                }

                switch (sortOrder)
                {
                    case "coddesconto_desc":
                        DescontoIQ = DescontoIQ.OrderByDescending(s => s.CodDesconto);
                        break;
                    case "DescDesconto":
                        DescontoIQ = DescontoIQ.OrderBy(s => s.DescDesconto);
                        break;
                    case "descdesconto_desc":
                        DescontoIQ = DescontoIQ.OrderByDescending(s => s.DescDesconto);
                        break;
                    case "EstadoDesconto":
                        DescontoIQ = DescontoIQ.OrderBy(s => s.EstadoDesconto);
                        break;
                    case "estadodesconto_desc":
                        DescontoIQ = DescontoIQ.OrderByDescending(s => s.EstadoDesconto);
                        break;
                    default:
                        DescontoIQ = DescontoIQ.OrderBy(s => s.CodDesconto);
                        break;
                }

                Desconto = await DescontoIQ.ToListAsync();
            }
        }
    }
}
