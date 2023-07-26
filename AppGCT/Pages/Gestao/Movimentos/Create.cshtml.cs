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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace AppGCT.Pages.Gestao.Movimentos
{
    [IgnoreAntiforgeryToken]
    [Authorize(Roles = "Administrador,Ginásio")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public CreateModel(AppGCT.Data.AppGCTContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private async Task<bool> ValidaMovimento()
        {
            if (_context.Movimento == null || Movimento == null)
            {
                return false;
            }

            // Se tipo de rubrica é pagamento, o numero da fatura tem de estar preenchido (não pode ser null)
            var tipoRubrica = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().TipoRubrica;
            if (tipoRubrica == "P" && Movimento.NumFatura == null)
            {
                ModelState.AddModelError("Movimento.NumFatura", "Número de fatura é obrigatório");
                return false;
            }

            if (Movimento.NumFatura != null) { 
            // Valida se o NumFatura já existe na BD

                //if (await _context.Movimento.AnyAsync(e => e.NumFatura == Movimento.NumFatura))
                //{
                //    ModelState.AddModelError("Movimento.NumFatura", "Já existe um movimento com número fatura igual");
                //    return false;
                //}

            }

            // Se tipo de rubrica é devolução, o numero de nota de crédito tem de estar preenchido (não pode ser null)
            tipoRubrica = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().TipoRubrica;
            if(tipoRubrica == "D" && Movimento.NumNotaCredito == null)
            {
                ModelState.AddModelError("Movimento.NumNotaCredito", "Número nota crédito é obrigatório");
                return false;
            }

            if (Movimento.NumNotaCredito != null)
            {
                // Valida se o NumNotaCredito já existe na BD
                //if (await _context.Movimento.AnyAsync(e => e.NumNotaCredito == Movimento.NumNotaCredito))
                //{
                //    ModelState.AddModelError("Movimento.NumNotaCredito", "Já existe um movimento com número nota crédito igual");
                //    return false;
                //}
            }

            // Validações se Rubrica não estiver preenchida
            if (Movimento.RubricaId.Equals(null))
            {

                    ModelState.AddModelError("Movimento.RubricaId", "Rúbrica é um campo obrigatório");
                    return false;
            }
            else
            {
                // Validação do preenchimento do Ginasta, para Rúbricas do Ginasta (mensalidade, seguros, ... )
                switch ("G")
                {
                    case "G":
                        if (Movimento.AtletaMovimentoId.Equals(null))
                        {
                            ModelState.AddModelError("Movimento.AtletaMovimentoId", "Ginasta é um campo obrigatório");
                            return false;
                        }
                        break;
                }
            }

            // Validações se Valor Movimento é superior a zero
            if (Movimento.ValorMovimento <= 0)
            {
 
                    ModelState.AddModelError("Movimento.ValorMovimento", "Valor movimento tem de ser superior a 0,00€");
                    return false;
                
            }

            return true;
        }

        public async Task<IActionResult> OnGet()
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
            
            List<string> userIdsInRole;
            //obtem lista de utilizadores associados ao role se role != null
            userIdsInRole = (await _userManager.GetUsersInRoleAsync("Sócio"))
                                               .Select(u => u.Id)
                                               .ToList();
            await _context.SaveChangesAsync();

            // preenche dropdown Sócios para filtro
            var socios = _context.Utilizador.Where(i => i.EstadoUtilizador == "A" &&
                                                   userIdsInRole.Contains(i.Id) && i.NumSocio != null && i.NumSocio != "")
                                                    .ToList();
            
            ViewData["UtilizadorId"] = new SelectList(socios, "Id", "ID_Description");
            var rubricas = _context.Rubrica.ToList();
            rubricas.Insert(0, new Rubrica
            {
                CodRubrica = "",
                DescricaoRubrica = "Seleccionar Rúbrica"

            });
            ViewData["RubricaId"] = new SelectList(rubricas, "CodRubrica", "ID_DescriptionRubrica");

            return Page();
        }

        [BindProperty]
        public Movimento Movimento { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var saldoAux = 0;
            var tipoMov = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().TipoRubrica;
            switch (tipoMov)
            {
                case "G":
                case "S":
                    Movimento.ValorMovimento = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().ValorUnitario;
                    Movimento.ValorDesconto = 0;
                    saldoAux = (int)(Movimento.ValorMovimento * -1) + (int)Movimento.ValorDesconto;
                    break;
                case "P":
                    Movimento.ValorDesconto = 0;
                    Movimento.Atleta = null;
                    saldoAux = (int)(Movimento.ValorMovimento * 1);
                    break;
                case "D":
                    Movimento.ValorDesconto = 0;
                    saldoAux = (int)(Movimento.ValorMovimento * 1);
                    break;
            }

            if (!ModelState.IsValid || _context.Movimento == null || Movimento == null)
            {
                return Page();
            }
            var flag = await ValidaMovimento();
            await _context.SaveChangesAsync();
            if (!flag)
            {
                //faz refresh das dropdown's

                OnGet();
                return Page();
            }

            // Aceder à descrição da rubrica e gravá-la no movimento que se está a criar.
            //   Isto previne que, se no futuro a descrição da Rubrica for alterado, o Movimento fica com a Desrição da Rubrica que estava na tabela no
            //  momento da criação do Movimento
            Movimento.DesRubrica = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().DescricaoRubrica;

            Movimento.DataCriacao = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.Name);
            Movimento.IdCriacao = userId;
            Movimento.DataModificacao = DateTime.MinValue;
            Movimento.IdModificacao = "";
            var idSoc = Movimento.UtilizadorId;
            var saldoAnt = _context.Saldo.Where(i => i.IdSocio == idSoc).FirstOrDefault().MSaldo;
            Movimento.MSaldo = saldoAnt + saldoAux;

            Movimento.Observacoes = "";

            // Atualiza Saldo do Sócio na tabela Saldos
            var saldoObj = _context.Saldo.FirstOrDefault(s => s.IdSocio == idSoc);

            if (saldoObj != null)
            {
                // Step 3: Modify the properties you want to update
                saldoObj.MSaldo = Movimento.MSaldo;

                // Step 4: Save the changes back to the database
                _context.Saldo.Update(saldoObj);
                
            }


            _context.Movimento.Add(Movimento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public JsonResult OnGetRandomNumber(string selectedValue)
        {
            var tipoMov = _context.Rubrica.Where(i => i.CodRubrica == selectedValue).FirstOrDefault().TipoRubrica;
            var montante = _context.Rubrica.Where(i => i.CodRubrica == selectedValue).FirstOrDefault().ValorUnitario;
            

            return new JsonResult(new
            {
                items = new[] {
                    new {tipoRubrica = tipoMov , valor = montante}
                    }
            });

            //return new JsonResult(new
            //{
            //    valor = tipoMov,
            //    valorUnitario = montante
            //});
        }
    }
}
