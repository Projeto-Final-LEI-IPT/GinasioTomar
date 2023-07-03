using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppGCT.Data;
using AppGCT.Models;
using System.Security.Claims;
using System.Collections;

namespace AppGCT.Pages.Gestao.Movimentos
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
        var atletas = _context.Ginasta.ToList();
        atletas.Insert(0, new Ginasta
        {
            NomeCompleto = "Seleccionar Ginasta"

        });
        ViewData["AtletaMovimentoId"] = new SelectList(atletas, "Id", "NomeCompleto");
        var metodos = _context.MetodoPagamento.ToList();
        metodos.Insert(0, new MetodoPagamento
        {
            CodMetodo  = "",
            DescMetodo = "Seleccionar Método"

        });
        ViewData["MetodoPagamentoId"] = new SelectList(metodos, "CodMetodo", "DescMetodo");
        ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "ID_Description");
        ViewData["RubricaId"] = new SelectList(_context.Rubrica, "CodRubrica", "ID_DescriptionRubrica");
            return Page();
        }

        [BindProperty]
        public Movimento Movimento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
// Aceder à descrição da rubrica e gravá-la no movimento que se está a criar.
//   Isto previne que, se no futuro a descrição da Rubrica for alterado, o Movimento fica com a Desrição da Rubrica que estava na tabela no
//  momento da criação do Movimento
            Movimento.DesRubrica = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().DescricaoRubrica;

            if (!ModelState.IsValid || _context.Movimento == null || Movimento == null)
            {
                return Page();
            }


            Movimento.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            Movimento.IdCriacao = userId;
            Movimento.DataModificacao = DateTime.MinValue;
            Movimento.IdModificacao = "";

            _context.Movimento.Add(Movimento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public JsonResult OnGetRandomNumber(string selectedValue)
        {
            var tipoMov = _context.Rubrica.Where(i => i.CodRubrica == selectedValue).FirstOrDefault().TipoMovimento;
            
            
            
            return new JsonResult(new
            {
                valor = tipoMov
            });
        }
    }
}
