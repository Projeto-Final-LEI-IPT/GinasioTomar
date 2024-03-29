using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AppGCT.Models;
using SendGrid.Helpers.Mail;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador")]
    public class DeleteModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppGCT.Data.AppGCTContext _context;
        public DeleteModel(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager,AppGCT.Data.AppGCTContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
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
                // N�o permite remo��o de Admin's e Gin�sio
                if (Utilizador.RoleAux == "Administrador" || Utilizador.RoleAux == "Gin�sio")
                {
                    TempData["ErrorMessage"] = "N�o � possivel realizar a ac��o pretendida!";
                    return RedirectToPage("./Erro");
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
            var movimentos = await _context.Movimento.Where(u => u.UtilizadorId == user.Id).FirstOrDefaultAsync();

            if (movimentos != null)
            {
                TempData["ErrorMessage"] = "Apagar S�cio n�o � possivel. J� existem Movimentos associados ao S�cio.";
                return RedirectToPage("./Erro");
            }

            var ginastas = await _context.Ginasta.Where(u => u.UtilizadorId == user.Id).FirstOrDefaultAsync();

            if (ginastas != null)
            {
                TempData["ErrorMessage"] = "Apagar S�cio n�o � possivel. J� existem Ginastas associados ao S�cio.";
                return RedirectToPage("./Erro");
            }

            try
            {      
                // OBT�M ROLES DO UTILIZADOR
                var roleNames = await _userManager.GetRolesAsync(user);

                // OBT�M ID ROLES DO UTILIZADOR
                var roleIds = roleNames.Select(name => _roleManager.Roles.FirstOrDefault(role => role.Name == name)?.Id)
                    .Where(id => id != null)
                    .ToList();
                // N�o permite remo��o de Admin's e Gin�sio
                if (Utilizador.RoleAux == "Administrador" || Utilizador.RoleAux == "Gin�sio")
                {
                    TempData["ErrorMessage"] = "N�o � possivel realizar a ac��o pretendida!";
                    return RedirectToPage("./Erro");
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
                    // Verifica se utilizador (s�cio) tem saldo 0, se sim elimina da tabela saldos
                    var saldo = await _context.Saldo.FirstOrDefaultAsync(i => i.IdSocio == user.Id);

                    if (saldo != null && saldo.MSaldo == 0)
                    {
                        _context.Saldo.Remove(saldo);
                        await _context.SaveChangesAsync();
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
