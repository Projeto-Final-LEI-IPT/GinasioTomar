using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador")]
    public class DeleteModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DeleteModel(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public Utilizador Utilizador { get; set; }
        public IdentityRole Role { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Utilizador = await _userManager.FindByIdAsync(id);

            if (Utilizador != null)
            {

                var roles = await _userManager.GetRolesAsync(Utilizador);
                if (roles.Any())
                {
                    var roleId = await _roleManager.FindByNameAsync(roles.First());
                    Role = await _roleManager.FindByIdAsync(roleId.Id);
                }

            }
            else
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(Utilizador.Id);

            if (user == null)
            {
                return NotFound();
            }

            // Delete the user from the AspNetUsers table
            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{user.Id}'.");
            }

            // Get the roles to which the user belongs
            var roleNames = await _userManager.GetRolesAsync(user);

            // Get the role ids
            var roleIds = roleNames.Select(name => _roleManager.Roles.FirstOrDefault(role => role.Name == name)?.Id)
                                   .Where(id => id != null)
                                   .ToList();

            // Remove the user from all roles
            var result2 = await _userManager.RemoveFromRolesAsync(user, roleNames);

            if (!result2.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred removing user '{user.UserName}' from roles.");
            }

            // Delete the user from the AspNetUserRoles table
            foreach (var roleId in roleIds)
            {
                result = await _userManager.RemoveFromRoleAsync(user, roleId);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred removing user '{user.UserName}' from role '{roleId}'.");
                }
            }

            return RedirectToPage("./Index");
        }

    }
}
