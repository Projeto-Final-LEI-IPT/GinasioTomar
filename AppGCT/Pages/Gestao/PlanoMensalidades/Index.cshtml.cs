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
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public int IdEpoca { get; set; }

        [BindProperty(SupportsGet = true)]
        public int IdGinasta { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ILancado { get; set; }

        public IList<PlanoMensalidade> PlanoMensalidade { get; set; } = default!;

        public SelectList EpocaList { get; set; }

        public SelectList GinastaList { get; set; }
        public SelectList LancadoList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? idGinasta, int? idEpoca, string? iLancado, string IInscricao)
        {
            if (idGinasta.HasValue || idEpoca.HasValue)
            {
                IdGinasta = idGinasta.Value;
                IdEpoca = idEpoca.Value;
                ILancado = iLancado;
            }

            if (_context.PlanoMensalidade != null)
            {
                string userId = User.Identity.GetUserId();
                if (User.IsInRole("Administrador") || User.IsInRole("Ginásio"))
                {
                    // preenche dropdown Épocas para filtro
                    var epocas = _context.Epoca.Where(i => i.EstadoEpoca == "A" || i.EstadoEpoca == "F").ToList();
                    epocas.Insert(0, new Epoca
                    {
                        IdEpoca = 0,
                        NomeEpoca = "Seleccionar Época"
                    });

                    EpocaList = new SelectList(epocas, "IdEpoca", "NomeEpoca");

                    // alimenta dropdown Ginasta para filtro
                    var ginastas = _context.Ginasta.Where(i => i.EstadoGinasta == "A").ToList();
                    ginastas.Insert(0, new Ginasta
                    {
                        Id = 0,
                        NomeCompleto = "Seleccionar Ginasta"
                    });

                    GinastaList = new SelectList(ginastas, "Id", "NomeCompleto");

                    // preenche dropdown Lançado para filtro
                    var Ilancado = new List<SelectListItem>();
                    Ilancado.Insert(0, new SelectListItem { Value = null, Text = "Lançado?" });
                    Ilancado.Insert(1, new SelectListItem { Value = "S", Text = "Sim" });
                    Ilancado.Insert(2, new SelectListItem { Value = "N", Text = "Não" });

                    LancadoList = new SelectList(Ilancado, "Value", "Text");

                    //Se veio direto de uma inscrição ou filtro
                    if (IInscricao == "S")
                    {
                        PlanoMensalidade = await _context.PlanoMensalidade
                                            .Include(p => p.Aluno)
                                            .Include(p => p.Epoca)
                                            .Where(p => p.EpocaId == IdEpoca && p.GinastaId == IdGinasta)
                                            .ToListAsync();
                    }
                    else
                    //Se acedeu diretamente à area de Planos
                    {
                        if ((idGinasta != null && idGinasta != 0) && idEpoca != null)
                        {
                            PlanoMensalidade = await _context.PlanoMensalidade
                                            .Include(p => p.Aluno)
                                            .Include(p => p.Epoca)
                                            .Where(p => p.EpocaId == IdEpoca && p.GinastaId == IdGinasta)
                                            .ToListAsync();
                        }
                        else
                        {
                            if (iLancado != null && idEpoca != null)
                            {
                                PlanoMensalidade = await _context.PlanoMensalidade
                                            .Include(p => p.Aluno)
                                            .Include(p => p.Epoca)
                                            .Where(p => p.EpocaId == IdEpoca && p.ILancado == ILancado)
                                            .OrderBy(p => p.DataMensalidade)
                                            .ToListAsync();
                            }
                            else
                            {
                                PlanoMensalidade = await _context.PlanoMensalidade
                                                                           .Include(p => p.Aluno)
                                                                           .Include(p => p.Epoca)
                                                                           .ToListAsync();
                            }
                        }    
                    }
                }
                else
                {
                    var ginasta = await _context.Ginasta
                                                .Include(g => g.Socio)
                                                .FirstOrDefaultAsync(g => g.UtilizadorId == userId && g.Id == IdGinasta);

                    if (ginasta != null)
                    {

                        PlanoMensalidade = await _context.PlanoMensalidade
                                      .Include(p => p.Aluno)
                                      .Include(p => p.Epoca)
                                      .Where(p => p.EpocaId == IdEpoca && p.GinastaId == IdGinasta)
                                      .ToListAsync();
                    }
                    else
                    {
                        return RedirectToPage("./AcessDenied");
                    }
                }
            }
            return Page();
        }
    }
}