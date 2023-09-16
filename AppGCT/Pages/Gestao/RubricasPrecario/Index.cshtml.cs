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
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [BindProperty(SupportsGet = true)]
        public int IdClasse { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CodDesconto { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Estado { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TipoMov { get; set; }
        [BindProperty(SupportsGet = true)]
        public string IPrecario { get; set; }
        [BindProperty(SupportsGet = true)]
        public string IVlrunit { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ICobInsc { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }
        public IList<Rubrica> Rubrica { get;set; } = default!;

        public SelectList ClasseList { get; set; }
        public SelectList DescontoList { get; set; }
        public SelectList EstadoList { get; set; }
        public SelectList TipoMovList { get; set; }
        public SelectList IPrecarioList { get; set; }
        public SelectList IVlrunitList { get; set; }
        public SelectList ICobInscList { get; set; }

        public async Task<IActionResult> OnGetAsync(string? searchString,int? idClasse, string? codDesconto, string? estado, 
                                                    string? tipomov, string? iprecario, string? ivlrunit, string? icobinsc)
        {
            if (searchString != null || idClasse.HasValue || codDesconto != null || estado != null 
                                     || tipomov != null || iprecario != null || ivlrunit != null || icobinsc != null) 
            {
                CurrentFilter = searchString;
                IdClasse = idClasse.Value;
                CodDesconto = codDesconto;
                Estado = estado;
                TipoMov = tipomov;
                IPrecario = iprecario;
                IVlrunit = ivlrunit;
                ICobInsc = icobinsc;
            }
            // preenche dropdown Classe para filtro
            var classes = _context.Classe.Where(i => i.EstadoClasse == "A").ToList();
            classes.Insert(0, new Classe
            {
                IdClasse = 0,
                NomeClasse = "Classe?"
            });

            ClasseList = new SelectList(classes, "IdClasse", "NomeClasse");

            // preenche dropdown Desconto para filtro
            var descontos = _context.Desconto.Where(i => i.EstadoDesconto == "A").ToList();
            descontos.Insert(0, new Desconto
            {
                CodDesconto = null,
                DescDesconto = "Desconto?"
            });

            DescontoList = new SelectList(descontos, "CodDesconto", "DescDesconto");

            // preenche dropdown Estado para filtro
            var estados = new List<SelectListItem>();
            estados.Insert(0, new SelectListItem { Value = null, Text = "Estado?" });
            estados.Insert(1, new SelectListItem { Value = "A", Text = "Ativo" });
            estados.Insert(2, new SelectListItem { Value = "I", Text = "Inativo" });

            EstadoList = new SelectList(estados, "Value", "Text");

            // preenche dropdown tipoMovimento para filtro
            var tipomovs = new List<SelectListItem>();
            tipomovs.Insert(0, new SelectListItem { Value = null, Text = "Tipo Mov.?" });
            tipomovs.Insert(1, new SelectListItem { Value = "C", Text = "Crédito" });
            tipomovs.Insert(2, new SelectListItem { Value = "D", Text = "Débito" });

            TipoMovList = new SelectList(tipomovs, "Value", "Text");

            // preenche dropdown IPrecario para filtro
            var iprecarios = new List<SelectListItem>();
            iprecarios.Insert(0, new SelectListItem { Value = null, Text = "Preç. Púb.?" });
            iprecarios.Insert(1, new SelectListItem { Value = "S", Text = "Sim" });
            iprecarios.Insert(2, new SelectListItem { Value = "N", Text = "Não" });

            IPrecarioList = new SelectList(iprecarios, "Value", "Text");

            // preenche dropdown IVlrunit para filtro
            var ivlrunits = new List<SelectListItem>();
            ivlrunits.Insert(0, new SelectListItem { Value = null, Text = "Vlr unit.?" });
            ivlrunits.Insert(1, new SelectListItem { Value = "S", Text = "Sim" });
            ivlrunits.Insert(2, new SelectListItem { Value = "N", Text = "Não" });

            IVlrunitList = new SelectList(ivlrunits, "Value", "Text");

            // preenche dropdown Icobinsc para filtro
            var icobinscs = new List<SelectListItem>();
            icobinscs.Insert(0, new SelectListItem { Value = null, Text = "Cob. Insc.?" });
            icobinscs.Insert(1, new SelectListItem { Value = "S", Text = "Sim" });
            icobinscs.Insert(2, new SelectListItem { Value = "N", Text = "Não" });

            ICobInscList = new SelectList(icobinscs, "Value", "Text");

            if (_context.Rubrica != null)
            {
                //filtro por descrubrica e codrubrica e local treino
                if (searchString != null)
                {
                    Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade)
                             .Where(p => p.CodRubrica.ToUpper().Contains(searchString.ToUpper())
                                      || p.DescricaoRubrica.ToUpper().Contains(searchString.ToUpper())
                                      || p.LocalTreino.ToUpper().Contains(searchString.ToUpper()))
                             .ToListAsync();
                }
                else
                //filtro por classe
                if (idClasse != null && idClasse != 0)
                {
                    Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade)
                             .Where(p => p.ClasseId == idClasse)
                             .ToListAsync();
                }else
                //filtro por desconto
                if (codDesconto != null)
                {
                    Rubrica = await _context.Rubrica
                            .Include(r => r.Discount)
                            .Include(r => r.Modalidade)
                            .Where(p => p.DescontoId == codDesconto)
                            .ToListAsync();
                }else
                //filtro por estado
                 if (estado != null)
                 {
                     Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade)
                             .Where(p => p.EstadoRubrica == estado)
                             .ToListAsync();
                 }else
                 //filtro por tipomov
                 if (tipomov != null)
                 {
                     Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade)
                             .Where(p => p.TipoMovimento == tipomov)
                             .ToListAsync();
                 }else
                 //filtro por iprecario
                 if (iprecario != null)
                 {
                     Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade)
                             .Where(p => p.IPrecario == iprecario)
                             .ToListAsync();
                 }else
                 //filtro por ivlrunit
                 if (ivlrunit != null)
                 {
                     Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade)
                             .Where(p => p.IVlrUnit == ivlrunit)
                             .ToListAsync();
                 }else
                 //filtro por icobinsc
                 if (icobinsc != null)
                 {
                     Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade)
                             .Where(p => p.IPagInscricao == icobinsc)
                             .ToListAsync();
                 }
                 else
                 {
                     Rubrica = await _context.Rubrica
                             .Include(r => r.Discount)
                             .Include(r => r.Modalidade).ToListAsync();
                 }  
            }
            return Page();
        }
    }
}
