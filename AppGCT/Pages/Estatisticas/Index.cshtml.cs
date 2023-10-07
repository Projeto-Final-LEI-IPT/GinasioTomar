using AppGCT.Models;
using Humanizer;
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

        public List<DataViewModel> utilizadores { get; set; } = new List<DataViewModel>();

        public class DataViewModel
        {
            public String? RoleAux { get; set; }
            public int? CountACT { get; set; }
            public int? CountINA { get; set; }
        }

        public List<DataViewModel2> ginastas { get; set; } = new List<DataViewModel2>();

        public class DataViewModel2
        {
            public int? CountGinACT { get; set; }
            public int? CountGinINA { get; set; }
        }

        public List<DataViewModel3> inscricoes { get; set; } = new List<DataViewModel3>();

        public class DataViewModel3
        {
            public string? NomeEpoca { get; set; }
            public int? CountInscricoes { get; set; }
        }
        public List<DataViewModel4> inscricoesdet { get; set; } = new List<DataViewModel4>();

        public class DataViewModel4
        {
            public string? NomeEpoca { get; set; }
            public string? NomeClasse { get; set; }
            public int? CountInscricoes { get; set; }
        }
        public async Task OnGetAsync()
        {
            // Obter todos os tipos de utilizadores ativos
            List<string> distinctRoleAux = _context.Users
                                                   .Where(u => u.RoleAux != null)
                                                   .Select(u => u.RoleAux)
                                                   .Distinct()
                                                   .ToList();
            //por cada tipo de utilizador obtem a quantidade de utilizadores ativos e inativos
            foreach (string roleAux in distinctRoleAux)
            {
                int count = _context.Users
                                    .Count(u => u.RoleAux == roleAux && u.EstadoUtilizador == "A");

                int count2 = _context.Users
                                    .Count(u => u.RoleAux == roleAux && u.EstadoUtilizador != "A");
            // formata dataviewmodel
                DataViewModel modelItem = new DataViewModel();
                modelItem.RoleAux = roleAux;
                modelItem.CountACT = count;
                modelItem.CountINA = count2;
                utilizadores.Add(modelItem);
            }

            //obtem quantidade de ginastas ativos e inativos
            int countG = _context.Ginasta
                                    .Count(u => u.EstadoGinasta == "A");

            int countG2 = _context.Ginasta
                                    .Count(u => u.EstadoGinasta != "A");

            // formata dataviewmodel
            DataViewModel2 model = new DataViewModel2();
            model.CountGinACT = countG;
            model.CountGinINA = countG2;
            ginastas.Add(model);


            // Obter todos as épocas
            List<string?> distinctEpoca = _context.Epoca.OrderByDescending(u => u.NomeEpoca).Select(u => u.NomeEpoca).ToList();

            //por cada época obtem o total de inscrições por Classe 
            foreach (string epoca in distinctEpoca)
            {
                int epocaid = _context.Epoca.Where(i => i.NomeEpoca == epoca)
                                                     .Select(i => i.IdEpoca).FirstOrDefault();

                int countTOT = _context.Inscricao
                                    .Count(u => u.EpocaId == epocaid);              

                // formata dataviewmodel
                DataViewModel3 modelItem = new DataViewModel3();
                modelItem.NomeEpoca = epoca;
                modelItem.CountInscricoes = countTOT;
                inscricoes.Add(modelItem);

                List<int> distinctClasseIds = _context.Inscricao
                    .Where(i => i.EpocaId == epocaid && i.ClasseId != 0) 
                    .Select(i => i.ClasseId) 
                    .Distinct() 
                    .ToList();

                foreach (int classe in distinctClasseIds)
                {
                    int countc = _context.Inscricao
                                    .Count(u => u.ClasseId == classe && u.EpocaId == epocaid);

                    string nomeClasse = _context.Classe.Where(i => i.IdClasse == classe)
                                                     .Select(i => i.NomeClasse).FirstOrDefault();

                    // formata dataviewmodel
                    DataViewModel4 modelItemClasse = new DataViewModel4();
                    modelItemClasse.NomeEpoca = epoca;
                    modelItemClasse.NomeClasse = nomeClasse;
                    modelItemClasse.CountInscricoes = countc;
                    inscricoesdet.Add(modelItemClasse);
                }
            }
        }
    }
}
   



                


