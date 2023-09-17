using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Pages.Gestao.Tarefas
{
    [Authorize(Roles = "Administrador,Gin�sio")]
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
            // Mostrar v�rias parametriza��es em falta
            await consultaParametrizoesPendentes();

            // Consultar todos os S�cios Ativos
            var sociosAtivos = await _context.Users.Where(i => i.EstadoUtilizador == "A").ToListAsync();
            foreach (var socioAtivo in sociosAtivos)
            {
                // Por cada S�cio sem N�mero de S�cio Atribu�do, � mostrado um item na lista a informar para
                // ATRIBUIR N�MERO DE S�CIO
                if(   socioAtivo.NumSocio.Trim() == "" 
                   && socioAtivo.RoleAux         != "Administrador" 
                   && socioAtivo.RoleAux         != "Gin�sio") 
                {
                    DataViewModel model = new DataViewModel();
                    model.Socio = socioAtivo.Nome;
                    model.Ginasta = "N/A";
                    model.DescrTarefa = "Atribuir n�mero de s�cio";
                    Tarefas.Add(model);
                }

                // Consultar Ginastas Ativos para o S�cio em tratamento
                var ginastasAtivos = await _context.Ginasta.Where(i => i.UtilizadorId == socioAtivo.Id &&
                                                                       i.EstadoGinasta == "A"
                                                                 ).ToListAsync();
                foreach (var ginastaAtivo in ginastasAtivos)
                {
                    // Por cada Ginasta Ativo, Consultar as suas Inscri��es
                    var inscricoesEpocas = await _context.Inscricao.Where(i => i.GinastaId == ginastaAtivo.Id).ToListAsync();
                    // Por cada Inscri��o, Consultar se a Epoca respetiva se encontra ATIVA
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
                                model.DescrTarefa = "Verificar documenta��o obrigat�ria da inscri��o do ginasta na �poca " + nomeEpoca;
                                Tarefas.Add(model);
                            }
                        }
                    }
                }


            }

            //obt�m apenas rubricas de pre��rio p�blico associadas a classes
           // Tarefas = new[] {
             //       new {Socio = "S�cioTeste", Ginasta = "GinastaTeste", DescrTarefa = "Descri��o de teste"}
               //     };

        }
        private async Task<bool> consultaParametrizoesPendentes()
        {
            //obtem rubrica pass�vel de gerar movimento de Quota ( Ativa e do Tipo Socio)
            var rubrica = await _context.Rubrica
                                        .AnyAsync(r => r.TipoRubrica == "S" &&
                                                       r.EstadoRubrica == "A");
            if (!rubrica)
            {
                DataViewModel model = new DataViewModel();
                model.Socio = "Gest�o";
                model.Ginasta = "Gin�sio";
                model.DescrTarefa = "Considere que n�o existe nenhuma r�brica de quotas ativa";
                Tarefas.Add(model);
                return false;
            }
            return true;
        }
    }
}
