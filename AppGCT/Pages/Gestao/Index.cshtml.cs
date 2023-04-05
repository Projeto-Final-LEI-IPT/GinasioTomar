using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Ginasio
{
    [Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
