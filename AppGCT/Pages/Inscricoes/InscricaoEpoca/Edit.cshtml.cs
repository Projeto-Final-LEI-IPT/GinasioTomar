using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppGCT.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class EditModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public EditModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["ClasseId"] = new SelectList(_context.Classe.Where(i => i.EstadoClasse == "A"), "IdClasse", "NomeClasse");

            var descontos = _context.Desconto.Where(i => i.EstadoDesconto == "A").ToList();
            descontos.Insert(0, new Desconto
            {
                CodDesconto = "",
                DescDesconto = "Seleccionar Desconto"

            });

            ViewData["CodDesconto"] = new SelectList(descontos, "CodDesconto", "DescDesconto");


            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }

            var inscricao =  await _context.Inscricao.Include(i => i.Atleta)
                                                     .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }
            Inscricao = inscricao;
            ///var UserId = Inscricao.Atleta.UtilizadorId;
            /// Gravar IdDoSocio associado ao Ginasta
            /// TODO
            /// ...............
            /// ............... Faz sentido permitir modificar o Ginasta associado a uma inscrição em Epoca ???
            ///ViewData["GinastaId"] = new SelectList(_context.Ginasta, "Id", "ID_Description");
        
        ///ViewData["GinastaId"] = new SelectList(_context.Ginasta.Where(i => i.Id == id), "Id", "ID_DescrGinasta");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Obtem EpocaId
            int epocaId = Inscricao.EpocaId;
            // Obtem CodDesconto
            string codDesconto = Inscricao.CodDesconto;
            //obtem dtinscricao
            DateTime dataDia = DateTime.Now;

             //obtem ginasta em estado ativo
            var ginasta = await _context.Ginasta
                                        .FirstOrDefaultAsync(r => r.Id == Inscricao.GinastaId && r.EstadoGinasta == "A");
            if (ginasta == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Ginasta Inativo, deverá ativar para modificar inscrição");
                await OnGetAsync(Inscricao.GinastaId);
                return Page();
            }
            //obtem rubrica
            var rubrica = await _context.Rubrica
                                        .FirstOrDefaultAsync(r => r.ClasseId == Inscricao.ClasseId && r.DescontoId == Inscricao.CodDesconto);
            if (rubrica == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Rúbrica não definida no Preçário");
                await OnGetAsync(Inscricao.GinastaId);
                return Page();
            }
            decimal valorMensalidade = rubrica.ValorUnitario ?? 0m;

            // Valida se a época existe
            var epoca = await _context.Epoca.FindAsync(epocaId);

            if (epoca == null)
            {
                ModelState.AddModelError("Inscricao.GinastaId", "Época não está definida");
                await OnGetAsync(Inscricao.GinastaId);
                return Page();
            }

                // Calcula o número de meses entre a DataInicio e DataFim da época
                int numberOfMonths = (epoca.DataFim.Year - epoca.DataInicio.Year) * 12
                    + epoca.DataFim.Month - epoca.DataInicio.Month;

                //modifica Plano Mensalidade
                for (int i = 0; i <= numberOfMonths; i++)
                {
                    DateTime dataMensalidade = epoca.DataInicio.AddMonths(i);
                    if (dataMensalidade.Date > dataDia.Date)
                    {
                        var planoMensalidade = await _context.PlanoMensalidade
                            .FirstOrDefaultAsync(p => p.GinastaId == Inscricao.GinastaId && p.EpocaId == epocaId && p.DataMensalidade == dataMensalidade);

                        if (planoMensalidade != null)
                        {
                            // Atualiza Plano
                            planoMensalidade.ValorMensalidade = valorMensalidade;
                            planoMensalidade.DataModificacao = DateTime.Now;
                            planoMensalidade.IdModificacao = User.Identity.GetUserId();
                        }
                    }
                }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Inscricao.IdModificacao = User.Identity.GetUserId(); ;
            Inscricao.DataModificacao = DateTime.Now;
                       
            _context.Attach(Inscricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoExists(Inscricao.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id = Inscricao.GinastaId });
        }

        private bool InscricaoExists(int? id)
        {
          return (_context.Inscricao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
