using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador,Gin�sio")]
    public class ErrorModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
