using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Estatisticas
{
    [Authorize(Roles = "Administrador,Gin�sio")]
    public class IndexMovimentosModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
