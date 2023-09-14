using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public string IdCriacaoName { get; set; }
        public string IdModificacaoName { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Utilizador = await _userManager.FindByIdAsync(id);
            var currentUser = await _userManager.GetUserAsync(User);

            if (Utilizador != null)
            {
                // Se for o "Administrador" devolve erro;
                if (Utilizador.UserName == "admin@localhost" || Utilizador.Id == currentUser.Id)
                {
                    return RedirectToPage("./Error");
                }
                else
                {
                    var user = await _userManager.FindByIdAsync(Utilizador.IdCriacao);
                    IdCriacaoName = user?.Nome;
                    var user2 = await _userManager.FindByIdAsync(Utilizador.IdModificacao);
                    IdModificacaoName = user2?.Nome;

                    var roles = await _userManager.GetRolesAsync(Utilizador);
                    if (roles.Any())
                    {
                        var roleId = await _roleManager.FindByNameAsync(roles.First());
                        Role = await _roleManager.FindByIdAsync(roleId.Id);
                    }
                    else
                    {
                        Role = new IdentityRole("N/A");
                    }
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

            try
            {      
                // OBTÊM ROLES DO UTILIZADOR
                var roleNames = await _userManager.GetRolesAsync(user);

                // OBTÊM ID ROLES DO UTILIZADOR
                var roleIds = roleNames.Select(name => _roleManager.Roles.FirstOrDefault(role => role.Name == name)?.Id)
                    .Where(id => id != null)
                    .ToList();
                // Se for o "Administrador" devolve erro
                if (user.UserName == "admin@localhost")
                {
                    return RedirectToPage("./Error");
                }
                else
                {
                    // REMOVE UTILIZADOR DOS ROLES ASSOCIADOS (SE EXISTIREM)
                    if (roleIds.Any())
                    {
                        var result = await _userManager.RemoveFromRolesAsync(user, roleNames);

                        if (!result.Succeeded)
                        {
                            throw new InvalidOperationException($"Unexpected error occurred removing user '{user.UserName}' from roles.");
                        }
                    }

                    // APAGA UTILIZADOR DA TABELA ASPNETUSERS
                    var result2 = await _userManager.DeleteAsync(user);

                    if (!result2.Succeeded)
                    {
                        throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{user.Id}'.");
                    }

                    return RedirectToPage("./Index");
                }
                
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // ATUALIZA O SECURITY STAMP E VOLTA A TENTAR
                await _userManager.UpdateSecurityStampAsync(user);
                return await OnPostAsync();
            }
        }
    }
}
