using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Gestao.Descontos
{
    [Authorize(Roles = "Administrador")]
    public class ErroModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
