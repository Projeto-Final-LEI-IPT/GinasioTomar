using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Estatisticas
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class IndexMovimentosModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        public IndexMovimentosModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        // definição dataviewmodel Movimentos
        public List<DataViewModel> Movimentos { get; set; } = new List<DataViewModel>();

        public class DataViewModel
        {
            public String? NomeRubrica { get; set; }
            [Precision(18,2)]
            public decimal? ValorRubrica { get; set; }
            public int? QtdMovimentos { get; set; }
            [Precision(18, 2)]
            public decimal? TotMovimentos { get; set; }
        }
        public async Task OnGetAsync(string nomeEpoca)
        {
            //obtêm informação da época
            var epocaInfo = _context.Epoca.SingleOrDefault(i => i.NomeEpoca == nomeEpoca);

            // Obter todas as rúbricas 
            List<string?> rubricas = _context.Movimento
                .Where(i => i.DtMovimento >= epocaInfo.DataInicio && i.DtMovimento <= epocaInfo.DataFim) 
                .OrderBy(i => i.RubricaId)                                  
                .Select(i => i.RubricaId)    
                .Distinct()
                .ToList();

            //por cada rubrica formata dataviewmodel
            foreach (string rubrica in rubricas)
            {
                //obtêm informação da Rubrica
                var rubricaInfo = _context.Rubrica.SingleOrDefault(i => i.CodRubrica == rubrica);

                //count movimentos da rúbrica
                int countMov = _context.Movimento
                                    .Count(u => u.RubricaId == rubrica && u.DtMovimento >= epocaInfo.DataInicio && u.DtMovimento <= epocaInfo.DataFim);
                //obtem valor total dos movimentos da rubrica
                decimal? sumMov = _context.Movimento
                                          .Where(u => u.RubricaId == rubrica && u.DtMovimento >= epocaInfo.DataInicio && u.DtMovimento <= epocaInfo.DataFim)
                                          .Sum(u => u.ValorMovimento);
                //se rubrica é rubrica de pagamento (P) conta também os valores de desconto por trf. bancária
                if (rubricaInfo.TipoRubrica == "P")
                {
                    decimal? sumMov2 = _context.Movimento
                                          .Where(u => u.RubricaId == rubrica && u.DtMovimento >= epocaInfo.DataInicio && u.DtMovimento <= epocaInfo.DataFim)
                                          .Sum(u => u.ValorDesconto);
                    sumMov = sumMov + sumMov2;
                }

                //formata data view model
                DataViewModel modelItem = new DataViewModel();
                modelItem.NomeRubrica = rubricaInfo.CodRubrica + " - " + rubricaInfo.DescricaoRubrica;
                if (rubricaInfo.IVlrUnit == "S")
                {
                    modelItem.ValorRubrica = rubricaInfo.ValorUnitario;
                }else
                {
                    modelItem.ValorRubrica = 0;
                }
                modelItem.QtdMovimentos = countMov;
                modelItem.TotMovimentos = sumMov;
                Movimentos.Add(modelItem);
            }
        }
    }
}
