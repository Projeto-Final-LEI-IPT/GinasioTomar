using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Pages.Gestao.PlanoMensalidades
{
    [Authorize(Roles = "S�cio")]
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
