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
using Microsoft.Data.SqlClient;

namespace AppGCT.Pages.Gestao.Metodos
{
    [Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        public string CodMetodoSort { get; set; }
        public string DescMetodoSort { get; set; }
        public string ValorDescontoSort { get; set; }
        public string EstadoMetodoSort { get; set; }
        public string CurrentFilter { get; set; }
        public IList<MetodoPagamento> MetodoPagamento { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.MetodoPagamento != null)
            {
                CodMetodoSort = String.IsNullOrEmpty(sortOrder) ? "codmetodo_desc" : "";
                DescMetodoSort = sortOrder == "DescMetodo" ? "descmetodo_desc" : "DescMetodo";
                ValorDescontoSort = sortOrder == "ValorDesconto" ? "valordesconto_desc" : "ValorDesconto";
                EstadoMetodoSort = sortOrder == "EstadoMetodo" ? "estadometodo_desc" : "EstadoMetodo";

                CurrentFilter = searchString;

                IQueryable<MetodoPagamento> MetodoIQ = _context.MetodoPagamento.AsQueryable();

                if (!String.IsNullOrEmpty(searchString))
                {
                    MetodoIQ = MetodoIQ.Where(s => s.DescMetodo.ToUpper().Contains(searchString.ToUpper()));
                }

                switch (sortOrder)
                {
                    case "codmetodo_desc":
                        MetodoIQ = MetodoIQ.OrderByDescending(s => s.CodMetodo);
                        break;
                    case "DescMetodo":
                        MetodoIQ = MetodoIQ.OrderBy(s => s.DescMetodo);
                        break;
                    case "descmetodo_desc":
                        MetodoIQ = MetodoIQ.OrderByDescending(s => s.DescMetodo);
                        break;
                    case "ValorDesconto":
                        MetodoIQ = MetodoIQ.OrderBy(s => s.ValorDesconto);
                        break;
                    case "valordesconto_desc":
                        MetodoIQ = MetodoIQ.OrderByDescending(s => s.ValorDesconto);
                        break;
                    case "EstadoMetodo":
                        MetodoIQ = MetodoIQ.OrderBy(s => s.EstadoMetodo);
                        break;
                    case "estadometodo_desc":
                        MetodoIQ = MetodoIQ.OrderByDescending(s => s.EstadoMetodo);
                        break;
                    default:
                        MetodoIQ = MetodoIQ.OrderBy(s => s.CodMetodo);
                        break;
                }

                MetodoPagamento = await MetodoIQ.ToListAsync();
            }
        }
    }
}
