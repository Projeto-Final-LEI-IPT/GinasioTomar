using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Gestao.Movimentos
{
    [Authorize(Roles = "S�cio")]
    public class AcessDeniedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
