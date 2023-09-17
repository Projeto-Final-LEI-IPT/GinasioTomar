using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Gestao.Tarefas
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;

        public IndexModel(AppGCT.Data.AppGCTContext context)
        {
            _context = context;
        }

        public List<DataViewModel> Tarefas { get; set; } = new List<DataViewModel>();

        public class DataViewModel
        {
            public String? Socio { get; set; }
            public String? Ginasta { get; set; }
            public String? DescrTarefa { get;set;}
        }

        public async Task OnGetAsync()
        {
            // Mostrar várias parametrizações em falta
            await consultaParametrizoesPendentes();

            // Consultar todos os Sócios Ativos
            var sociosAtivos = await _context.Users.Where(i => i.EstadoUtilizador == "A").ToListAsync();
            foreach (var socioAtivo in sociosAtivos)
            {
                // Por cada Sócio sem Número de Sócio Atribuído, é mostrado um item na lista a informar para
                // ATRIBUIR NÚMERO DE SÓCIO
                if(   socioAtivo.NumSocio.Trim() == "" 
                   && socioAtivo.RoleAux         != "Administrador" 
                   && socioAtivo.RoleAux         != "Ginásio") 
                {
                    DataViewModel model = new DataViewModel();
                    model.Socio = socioAtivo.Nome;
                    model.Ginasta = "N/A";
                    model.DescrTarefa = "Atribuir número de sócio";
                    Tarefas.Add(model);
                }

                // Consultar Ginastas Ativos para o Sócio em tratamento
                var ginastasAtivos = await _context.Ginasta.Where(i => i.UtilizadorId == socioAtivo.Id &&
                                                                       i.EstadoGinasta == "A"
                                                                 ).ToListAsync();
                foreach (var ginastaAtivo in ginastasAtivos)
                {
                    // Por cada Ginasta Ativo, Consultar as suas Inscrições
                    var inscricoesEpocas = await _context.Inscricao.Where(i => i.GinastaId == ginastaAtivo.Id).ToListAsync();
                    // Por cada Inscrição, Consultar se a Epoca respetiva se encontra ATIVA
                    foreach (var inscricaoEpoca in inscricoesEpocas)
                    {
                        var nomeEpoca = _context.Epoca.Where(i => i.IdEpoca == inscricaoEpoca.EpocaId).FirstOrDefault().NomeEpoca;
                        var estadoEpoca = _context.Epoca.Where(i => i.IdEpoca == inscricaoEpoca.EpocaId).FirstOrDefault().EstadoEpoca;
                        if (estadoEpoca == "A")
                        {
                            if(inscricaoEpoca.ILeituraObrig   == "N" ||
                               inscricaoEpoca.IPagamInscricao == "N" ||
                               inscricaoEpoca.IFicFGP         == "N" ||
                               inscricaoEpoca.IExamMed        == "N" || 
                               inscricaoEpoca.IFicFGP         == "N" ||
                               inscricaoEpoca.ISeguro         == "N")
                            {
                                DataViewModel model = new DataViewModel();
                                model.Socio       = socioAtivo.Nome;
                                model.Ginasta     = ginastaAtivo.NomeCompleto;
                                model.DescrTarefa = "Verificar documentação obrigatória da inscrição do ginasta na época " + nomeEpoca;
                                Tarefas.Add(model);
                            }
                        }
                    }
                }


            }

            //obtêm apenas rubricas de preçário público associadas a classes
           // Tarefas = new[] {
             //       new {Socio = "SócioTeste", Ginasta = "GinastaTeste", DescrTarefa = "Descrição de teste"}
               //     };

        }
        private async Task<bool> consultaParametrizoesPendentes()
        {
            //obtem rubrica passível de gerar movimento de Quota ( Ativa e do Tipo Socio)
            var rubrica = await _context.Rubrica
                                        .AnyAsync(r => r.TipoRubrica == "S" &&
                                                       r.EstadoRubrica == "A");
            if (!rubrica)
            {
                DataViewModel model = new DataViewModel();
                model.Socio = "Gestão";
                model.Ginasta = "Ginásio";
                model.DescrTarefa = "Considere que não existe nenhuma rúbrica de quotas ativa";
                Tarefas.Add(model);
                return false;
            }
            return true;
        }
    }
}
