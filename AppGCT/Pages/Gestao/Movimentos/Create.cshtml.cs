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
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace AppGCT.Pages.Gestao.Movimentos
{
    [IgnoreAntiforgeryToken]
    [Authorize(Roles = "Administrador,Ginásio")]
    public class CreateModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        private async Task<bool> ValidaMovimento(string? tipoRub, int? atletaIdentifier, string? socioIdentifier)
        {
            if (_context.Movimento == null || Movimento == null)
            {
                return false;
            }
            // Só é possível criar Movimento para a DATA ATUAL
            if (Movimento.DtMovimento != DateTime.Today)
            {
                ModelState.AddModelError("Movimento.DtMovimento", "Data de Movimento deve ser a data atual");
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
                if (await _context.Movimento.AnyAsync(e => e.NumFatura == Movimento.NumFatura))
                {
                    ModelState.AddModelError("Movimento.NumFatura", "Já existe um movimento com número fatura igual");
                    return false;
                }
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
                if (await _context.Movimento.AnyAsync(e => e.NumNotaCredito == Movimento.NumNotaCredito))
                {
                    ModelState.AddModelError("Movimento.NumNotaCredito", "Já existe um movimento com número nota crédito igual");
                    return false;
                }
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
                switch (tipoRub)
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
            var rubricaObjetoCompleto = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault();
 // Se a rubrica tem um desconto, é do tipo Ginasta, e se o valor unitário associado é ZERO ou NULL
  // deixamos criar o movimento
            if (!(rubricaObjetoCompleto.DescontoId == null) && tipoRubrica == "G" &&
                 ((rubricaObjetoCompleto.IVlrUnit == "S" && rubricaObjetoCompleto.ValorUnitario == 0)    ||
                  (rubricaObjetoCompleto.IVlrUnit == "N" && rubricaObjetoCompleto.ValorUnitario == null) ||
                  (rubricaObjetoCompleto.IVlrUnit == "N" && rubricaObjetoCompleto.ValorUnitario == 0) ||
                  (rubricaObjetoCompleto.IVlrUnit == "S" && rubricaObjetoCompleto.ValorUnitario == null)   )
               )
            {
               // Se entra aqui estamos a inserir um movimento de mensalidade sem Valor Unitario Associado,
               // pelo que temos de permitir criar movimento
            }
            else
            {
                // Validações se Valor Movimento é superior a zero
                if (Movimento.ValorMovimento <= 0)
                {

                    ModelState.AddModelError("Movimento.ValorMovimento", "Valor movimento tem de ser superior a 0,00€");
                    return false;

                }
            }

            // Validações se Valor Desconto é igual ou inferior ao valor paramentrizado no Método de Pagamento
            // apenas se deve validar qu7ando a rubrica é de pagamento, pois se não for, a avriavés descontoAux será populada com NULL, dando erro o IF
            if (tipoRub == "P")
            {
                var descontoAux = _context.MetodoPagamento.Where(i => i.CodMetodo == Movimento.MetodoPagamentoId).FirstOrDefault().ValorDesconto;
                if (Movimento.ValorDesconto > descontoAux)
                {

                    ModelState.AddModelError("Movimento.ValorDesconto", "Valor desconto deve ser igual ou inferior ao parametrizado no método de pagamento");
                    return false;
                }
            }

            // Validações se Atleta não é selecionado
            if (atletaIdentifier == 0)
            {

                ModelState.AddModelError("Movimento.AtletaMovimentoId", "Preenchimento de Ginasta obrigatório");
                return false;

            }

            if (atletaIdentifier != 0 && !atletaIdentifier.Equals(null))
            {
                var socioRight = _context.Ginasta.Where(i => i.Id == atletaIdentifier).FirstOrDefault().UtilizadorId;
                if(socioRight != socioIdentifier)
                {
                    ModelState.AddModelError("Movimento.AtletaMovimentoId", "O ginasta deve estar associado ao sócio selecionado");
                    return false;
                }
            }

            // Lançamento de movimentos de mensalidades só pode acontecer durante o periodo da epoca e se o ginasta 
            // tiver inscrição valida para classe associada à mensalidade;
            if( tipoRub == "G")
            {
                var epoca = 0;
                try
                {
                    epoca = _context.Epoca.Where(i => i.DataInicio <= Movimento.DtMovimento &&
                                                      i.DataFim >= Movimento.DtMovimento &&
                                                      i.EstadoEpoca == "A").FirstOrDefault().IdEpoca;
                }
                catch (NullReferenceException ex) // <- this 'ex' correctly contains the exception
                {
                    ModelState.AddModelError("Movimento.RubricaId", "Não existe época ativa na data atual");
                    return false;
                }
                catch (Exception ex) // <- this 'ex' correctly contains the exception
                {
                    ModelState.AddModelError("Movimento.RubricaId", "Algo não correu como esperado. Contacte a Informática");
                    return false;
                }

                var classeMovimento = 0;
                try
                {
                    // Consultar CLASSE para ir verificar se a INSCRICAO do ATLETA é referente a essa CLASSE
                    classeMovimento = (int)_context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().ClasseId;
                }
                catch (InvalidOperationException ex) // <- this 'ex' correctly contains the exception
                {
                    ModelState.AddModelError("Movimento.RubricaId", "A Rúbrica selecionada não tem classe associada");
                    return false;
                }
                catch (Exception ex) // <- this 'ex' correctly contains the exception
                {
                    ModelState.AddModelError("Movimento.RubricaId", "Algo não correu como esperado. Contacte a Informática");
                    return false;
                }
                // Verifica se existe Inscrição para o conjunto selecionado (Ginasta/Epoca/Classe)
                try
                {
                    var inscricaoEpoca = _context.Inscricao.Where(i => i.GinastaId == atletaIdentifier &&
                               i.EpocaId == epoca &&
                               i.ClasseId == classeMovimento).First();
                }
                catch (InvalidOperationException ex) // <- this 'ex' correctly contains the exception
                {
                    ModelState.AddModelError("Movimento.AtletaMovimentoId", "Atleta selecionado não está inscrito na " +
                        "época em vigor");
                    return false;
                }
                catch (Exception ex) // <- this 'ex' correctly contains the exception
                {
                    ModelState.AddModelError("Movimento.AtletaMovimentoId", "Algo não correu como esperado. Contacte a Informática");
                    return false;
                }
            }

            return true;
        }

        public IActionResult OnGet()
        {
            var atletas = _context.Ginasta.Include(m => m.Socio).ToList();
            atletas.Insert(0, new Ginasta
            {
                NomeCompleto = "Seleccionar Ginasta"

            });
            ViewData["AtletaMovimentoId"] = new SelectList(atletas, "Id", "ID_DescrGinastaSocio");
            var metodos = _context.MetodoPagamento.Where(m => m.EstadoMetodo == "A").ToList();
            metodos.Insert(0, new MetodoPagamento
            {
                CodMetodo  = "",
                DescMetodo = "Seleccionar Método"
                

            });
            ViewData["MetodoPagamentoId"] = new SelectList(metodos, "CodMetodo", "DescMetodo");

            // preenche dropdown Sócios para filtro
            var socios = _context.Utilizador.Where(i => i.EstadoUtilizador == "A" &&
                                                   i.RoleAux == "Sócio")
                                                    .ToList();

            ViewData["UtilizadorId"] = new SelectList(socios, "Id", "ID_Description");
            var rubricas = _context.Rubrica.Where(i => i.EstadoRubrica == "A").ToList();
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
            Guid IdMovimento = Guid.NewGuid();
            
            var saldoAux = 0.0;
            var tipoRub = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().TipoRubrica;
            switch (tipoRub)
            {
                case "G":
                case "S":
                    Movimento.ValorMovimento = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().ValorUnitario ?? 0m;
                    Movimento.ValorDesconto = 0;
                    saldoAux = (double)(Movimento.ValorMovimento) * -1.0;
                    break;
                case "P":
                    if (!Movimento.ValorDesconto.HasValue)
                    {
                        Movimento.ValorDesconto = 0;
                    }
                    Movimento.Atleta = null;
                    saldoAux = (double)(Movimento.ValorMovimento) * 1.0 + (double)Movimento.ValorDesconto;
                    break;
                case "D":
                    Movimento.ValorDesconto = 0;
                    saldoAux = (double)(Movimento.ValorMovimento) * 1.0;
                    break;
                case "R":
                    var tipoMov = _context.Rubrica.Where(i => i.CodRubrica == Movimento.RubricaId).FirstOrDefault().TipoMovimento;
                    Movimento.ValorDesconto = 0;
                    switch (tipoMov)
                    {
                        case "D":
                            saldoAux = (double)(Movimento.ValorMovimento) * -1.0;
                            break;
                        case "C":
                            saldoAux = (double)(Movimento.ValorMovimento) * 1.0;
                            break;
                    } 
                    break;
            }
            Movimento.Id = IdMovimento;

            if (!ModelState.IsValid || _context.Movimento == null || Movimento == null)
            {
                return Page();
            }

            var atletaIdentifier = Movimento.AtletaMovimentoId;
            var socioIdentifier = Movimento.UtilizadorId;

            if (!await ValidaMovimento(tipoRub, atletaIdentifier, socioIdentifier))
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
            Movimento.DtMovimento = DateTime.Now;
            // obtem User ID logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Movimento.IdCriacao = userId;
            Movimento.DataModificacao = DateTime.MinValue;
            Movimento.IdModificacao = "";

            var idSoc = Movimento.UtilizadorId;
            var saldoAnt = (double)_context.Saldo.Where(i => i.IdSocio == idSoc).FirstOrDefault().MSaldo;
            Movimento.MSaldo = (decimal?)(saldoAnt + saldoAux);

            if (Movimento.Observacoes.IsNullOrEmpty())
            {
                Movimento.Observacoes = "";
            }

            // Atualiza Saldo do Sócio na tabela Saldos
            var saldoObj = _context.Saldo.FirstOrDefault(s => s.IdSocio == idSoc);

            if (saldoObj != null)
            {
                // Step 3: Modify the properties you want to update
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

        public JsonResult OnGetDesconto(string selectedValue)
        {
            var valorDesconto = _context.MetodoPagamento.Where(i => i.CodMetodo == selectedValue).FirstOrDefault().ValorDesconto;

            return new JsonResult(new
            {
                items = new[] {
                    new {desconto = valorDesconto}
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
