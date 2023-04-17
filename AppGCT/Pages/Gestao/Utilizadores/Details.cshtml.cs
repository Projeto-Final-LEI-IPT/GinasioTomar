using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador")]
    public class DetailsModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DetailsModel(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public Utilizador User { get; set; }
        public IdentityRole Role { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            User = await _userManager.FindByIdAsync(Id);

            if (User != null)
            {
                var roles = await _userManager.GetRolesAsync(User);
                var roleId = await _roleManager.FindByNameAsync(roles.First());
                Role = await _roleManager.FindByIdAsync(roleId.Id);
            }
            else
            {
                return NotFound();
            }
            return Page();
        }
    }
}
