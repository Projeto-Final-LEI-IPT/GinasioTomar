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
