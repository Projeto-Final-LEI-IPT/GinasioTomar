using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Inscricoes.InscricaoEpoca
{
    [Authorize(Roles = "Administrador,Ginásio,Sócio")]
    public class AcessDeniedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
