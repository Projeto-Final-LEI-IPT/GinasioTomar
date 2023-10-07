using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Estatisticas
{
    [Authorize(Roles = "Administrador,Gin�sio")]
    public class IndexInscricoesModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        public IndexInscricoesModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }
        // defini��o dataviewmodel Inscricoes
        public List<DataViewModel> Inscricoes { get; set; } = new List<DataViewModel>();

        public class DataViewModel
        {
            public String? NomeEpoca { get; set; }
            public String? NomeGinasta { get; set; }
            public String? NomeSocio { get; set; }
            public String? NomeClasse { get; set; }
            public String? NomeDesconto { get; set; }
        }
        public async Task OnGetAsync(string nomeEpoca)
        {
            //obt�m informa��o da �poca
            var epocaInfo = _context.Epoca.SingleOrDefault(i => i.NomeEpoca == nomeEpoca);

            // Obter todas as inscri��es
            List<int?> inscricoes = _context.Inscricao
                .Where(i => i.EpocaId == epocaInfo.IdEpoca) // Filtra pela �poca
                .OrderBy(i => i.ClasseId)                   // Ordena por ClasseId
                .ThenBy(i => i.CodDesconto)                 // Em seguida, ordena por CodDesconto
                .Select(i => i.Id)                          // Seleciona o Id da inscri��o
                .ToList();

            //por cada inscri��o formata dataviewmodel
            foreach (int inscricao in inscricoes)
            {
                //obt�m informa��o da Inscri��o
                var inscricaoInfo = _context.Inscricao.SingleOrDefault(i => i.Id == inscricao);

                //obt�m informa��o Ginasta
                var ginastaInfo = _context.Ginasta.SingleOrDefault(i => i.Id == inscricaoInfo.GinastaId);

                //obt�m informa��o S�cio
                var socioInfo = _context.Users.SingleOrDefault(i => i.Id == ginastaInfo.UtilizadorId);

                //obt�m informa��o Classe
                var classeInfo = _context.Classe.SingleOrDefault(i => i.IdClasse == inscricaoInfo.ClasseId);

                //obt�m informa��o Desconto
                var descontoInfo = _context.Desconto.SingleOrDefault(i => i.CodDesconto == inscricaoInfo.CodDesconto);

                DataViewModel modelItem = new DataViewModel();
                modelItem.NomeEpoca = nomeEpoca;
                modelItem.NomeGinasta = ginastaInfo.NomeCompleto;
                modelItem.NomeSocio = socioInfo.Nome;
                modelItem.NomeClasse = classeInfo.NomeClasse;
                if (descontoInfo == null)
                {
                    modelItem.NomeDesconto = "";
                }
                else
                {
                    modelItem.NomeDesconto = descontoInfo.DescDesconto;
                }
                Inscricoes.Add(modelItem);
            }
        }
    }
}
