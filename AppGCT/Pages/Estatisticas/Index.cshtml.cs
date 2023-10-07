using Humanizer;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;

namespace AppGCT.Pages.Estatisticas
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        // definição dataviewmodel Utilizadores
        public List<DataViewModel> Utilizadores { get; set; } = new List<DataViewModel>();

        public class DataViewModel
        {
            public String? RoleAux { get; set; }
            public int? CountACT { get; set; }
            public int? CountINA { get; set; }
        }

        // definição dataviewmodel Ginastas
        public List<DataViewModel2> Ginastas { get; set; } = new List<DataViewModel2>();

        public class DataViewModel2
        {
            public int? CountGinACT { get; set; }
            public int? CountGinINA { get; set; }
        }
        // definição dataviewmodel Inscrições
        public List<DataViewModel3> Inscricoes { get; set; } = new List<DataViewModel3>();

        public class DataViewModel3
        {
            public string? NomeEpoca { get; set; }
            public string? EstadoEpoca { get; set; }
            public int? CountInscricoes { get; set; }
        }
        // definição dataviewmodel Movimentos
        public List<DataViewModel4> Movimentos { get; set; } = new List<DataViewModel4>();

        public class DataViewModel4
        {
            public string? NomeEpoca { get; set; }
            [Precision(18, 2)]
            public Decimal? SaldoDebitos { get; set; }
            [Precision(18, 2)]
            public Decimal? SaldoCreditos { get; set; }
            [Precision(18, 2)]
            public Decimal? SaldoFinal { get; set; }
            
        }
        public async Task OnGetAsync()
        {
            // Obter todos os tipos de utilizadores de sistema (Administrador, Ginásio e Sócio)
            List<string> distinctRoleAux = _context.Users
                                                   .Where(u => u.RoleAux != null)
                                                   .Select(u => u.RoleAux)
                                                   .Distinct()
                                                   .ToList();

            //por cada tipo de utilizador obtem a quantidade de utilizadores ativos e inativos
            foreach (string roleAux in distinctRoleAux)
            {
                //count utilizadores ativos
                int count = _context.Users
                                    .Count(u => u.RoleAux == roleAux && u.EstadoUtilizador == "A");
                //count utilizadores inaativos
                int count2 = _context.Users
                                    .Count(u => u.RoleAux == roleAux && u.EstadoUtilizador != "A");
            // formata dataviewmodel Utilizadores
                DataViewModel modelItem = new DataViewModel();
                modelItem.RoleAux = roleAux;
                modelItem.CountACT = count;
                modelItem.CountINA = count2;
                Utilizadores.Add(modelItem);
            }

            //obtem quantidade de ginastas ativos 
            int countG = _context.Ginasta
                                    .Count(u => u.EstadoGinasta == "A");

            //obtem quantidade de ginastas inativos
            int countG2 = _context.Ginasta
                                    .Count(u => u.EstadoGinasta != "A");

            // formata dataviewmodel Ginastas
            DataViewModel2 model = new DataViewModel2();
            model.CountGinACT = countG;
            model.CountGinINA = countG2;
            Ginastas.Add(model);

            // Obter Nome de todas as épocas
            List<string?> distinctEpoca = _context.Epoca.OrderByDescending(u => u.NomeEpoca).Select(u => u.NomeEpoca).ToList();

            //por cada época obtem calcula total de inscrições e movimentos
            foreach (string epoca in distinctEpoca)
            {
                //obtêm IdEpoca com base no NomeEpoca
                int epocaid = _context.Epoca.Where(i => i.NomeEpoca == epoca)
                                                     .Select(i => i.IdEpoca).FirstOrDefault();
                //obtêm informação da época
                var epocaInfo = _context.Epoca.SingleOrDefault(i => i.NomeEpoca == epoca);

                //obtêm total de inscrições para a época
                int countTOT = _context.Inscricao
                                    .Count(u => u.EpocaId == epocaInfo.IdEpoca);              

                // formata dataviewmodel Inscricoes
                DataViewModel3 modelItem = new DataViewModel3();
                modelItem.NomeEpoca = epoca;
                modelItem.EstadoEpoca = epocaInfo.StatusDescription;
                modelItem.CountInscricoes = countTOT;
                Inscricoes.Add(modelItem);

                //obtem os movimentos a Débito entre a DataInicio e DataFim da época
                decimal? saldoDEB = _context.Movimento
                                            .Where(m => m.DtMovimento >= epocaInfo.DataInicio && m.DtMovimento <= epocaInfo.DataFim)
                                            .Join(
                                                _context.Rubrica.Where(r => r.TipoMovimento == "D"),
                                                mov => mov.RubricaId,
                                                rub => rub.CodRubrica,
                                                (mov, rub) => mov.ValorMovimento
                                            )
                                            .Sum();
                //passa o valor a negativo (registamos na tabela de movimentos o valor sem sinal)
                saldoDEB = saldoDEB * (-1);

                //obtem os movimentos a Crédito entre a DataInicio e DataFim da época
                decimal? saldoCred = _context.Movimento
                                            .Where(m => m.DtMovimento >= epocaInfo.DataInicio && m.DtMovimento <= epocaInfo.DataFim)
                                            .Join(
                                                _context.Rubrica.Where(r => r.TipoMovimento == "C"),
                                                mov => mov.RubricaId,
                                                rub => rub.CodRubrica,
                                                (mov, rub) => mov.ValorMovimento
                                            )
                                            .Sum();

                //obtem os movimentos a Crédito (Bónus por trf.bancária) entre a DataInicio e DataFim da época
                decimal? saldoCredBonus = _context.Movimento
                                            .Where(m => m.DtMovimento >= epocaInfo.DataInicio && m.DtMovimento <= epocaInfo.DataFim)
                                            .Join(
                                                _context.Rubrica.Where(r => r.TipoMovimento == "C"),
                                                mov => mov.RubricaId,
                                                rub => rub.CodRubrica,
                                                (mov, rub) => mov.ValorDesconto
                                            )
                                            .Sum();
                //soma os valores a crédito
                decimal? saldocredfinal = saldoCred + saldoCredBonus;

                //apura saldo final da época (débitos + créditos)
                decimal? saldofinal = saldoDEB + saldocredfinal;

                // formata dataviewmodel movimentos
                DataViewModel4 modelItemMov = new DataViewModel4();
                modelItemMov.NomeEpoca = epoca;
                modelItemMov.SaldoDebitos = saldoDEB;
                modelItemMov.SaldoCreditos = saldocredfinal;
                modelItemMov.SaldoFinal = saldofinal;
                Movimentos.Add(modelItemMov);
                
            }
        }
    }
}
   



                


