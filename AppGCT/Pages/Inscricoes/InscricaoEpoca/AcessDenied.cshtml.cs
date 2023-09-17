using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Gin�sio,S�cio")]
    public class AcessDeniedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
