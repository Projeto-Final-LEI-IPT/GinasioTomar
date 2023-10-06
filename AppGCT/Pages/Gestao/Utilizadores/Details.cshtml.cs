using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using AppGCT.Models;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador,Ginásio")]
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
        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            User = await _userManager.FindByIdAsync(Id);

            if (User != null)
            {
                var roles = await _userManager.GetRolesAsync(User);
                var roleId = await _roleManager.FindByNameAsync(roles.First());
                Role = await _roleManager.FindByIdAsync(roleId.Id);
                if (User.IdCriacao == "SEED")
                {
                    IdCriacaoName = "SEED INICIAL";
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(User.IdCriacao);
                    IdCriacaoName = user?.Nome;
                }
                
                var user2 = await _userManager.FindByIdAsync(User.IdModificacao);
                IdModificacaoName = user2?.Nome;
            }
            else
            {
                return NotFound();
            }
            return Page();
        }
    }
}
