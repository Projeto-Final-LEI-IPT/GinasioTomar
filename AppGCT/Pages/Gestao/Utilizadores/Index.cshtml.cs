using System.Collections.Generic;
using System.Threading.Tasks;
using AppGCT.Areas.Identity.Data;
using AppGCT.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class IndexModel : PageModel
    {
        private readonly AppGCT.Data.AppGCTContext _context;
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager, AppGCT.Data.AppGCTContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public string NomeCompletoSort { get; set; }
        public string TipoUtilizadorSort { get; set; }
        public string NumSocioSort { get; set; }
        public string EstadoUtilizadorSort { get; set; }
        public string ContactoSort { get; set; }
        public string EmailSort { get; set; }
        public string CurrentFilter { get; set; }
        public List<Utilizador> Users { get; set; } = new List<Utilizador>();

        private async Task<List<string>> GetUserRoleNames(Utilizador user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NomeCompletoSort = string.IsNullOrEmpty(sortOrder) ? "nomecompleto_desc" : "";
            TipoUtilizadorSort = sortOrder == "TipoUtilizador" ? "tipoutilizador_desc" : "TipoUtilizador";
            NumSocioSort = sortOrder == "NumSocio" ? "numsocio_desc" : "NumSocio";
            EstadoUtilizadorSort = sortOrder == "EstadoUtilizador" ? "estadoutilizador_desc" : "EstadoUtilizador";
            ContactoSort = sortOrder == "Contacto" ? "contacto_desc" : "Contacto";
            EmailSort = sortOrder == "Email" ? "email_desc" : "Email";

            CurrentFilter = searchString;

            IQueryable<Utilizador> UserIQ = _context.Utilizador.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                if (User.IsInRole("Administrador")) // Mostra todos os utilizadores do sistema
                {
                    // valida se existe um rolename com a search string
                    var role = await _roleManager.FindByNameAsync(searchString);
                    List<string> userIdsInRole;
                    //obtem lista de utilizadores associados ao role se role != null
                    if (role != null)
                    {
                        userIdsInRole = (await _userManager.GetUsersInRoleAsync(role.Name))
                            .Select(u => u.Id)
                            .ToList();
                    }
                    else
                    {
                        userIdsInRole = new List<string>();
                    }

                    UserIQ = UserIQ.Where(user => user.Nome.ToUpper().Contains(searchString.ToUpper())
                           || user.NumSocio.ToUpper().Contains(searchString.ToUpper())
                           || user.PhoneNumber.ToUpper().Contains(searchString.ToUpper())
                           || user.Email.ToUpper().Contains(searchString.ToUpper())
                           || userIdsInRole.Contains(user.Id));

                }
                else if (User.IsInRole("Ginásio")) // Mostra todos excepto administradores
                {
                    // valida se existe um rolename com a search string
                    var role = await _roleManager.FindByNameAsync(searchString);
                    List<string> userIdsInRole;
                    //obtem lista de utilizadores associados ao role se role != null
                    if (role != null)
                    {
                        userIdsInRole = (await _userManager.GetUsersInRoleAsync(role.Name))
                            .Select(u => u.Id)
                            .ToList();
                    }
                    else
                    {
                        userIdsInRole = new List<string>();
                    }

                    UserIQ = UserIQ.Where(user => (user.Nome.ToUpper().Contains(searchString.ToUpper())
                            || user.NumSocio.ToUpper().Contains(searchString.ToUpper())
                            || user.PhoneNumber.ToUpper().Contains(searchString.ToUpper())
                            || user.Email.ToUpper().Contains(searchString.ToUpper())
                            || userIdsInRole.Contains(user.Id)));
                }
            }

            switch (sortOrder)
            {
                case "nomecompleto_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.Nome);
                    break;
                case "TipoUtilizador":
                    UserIQ = UserIQ.OrderBy(s => s.RoleAux);
                    break;
                case "tipoutilizador_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.RoleAux);
                    break;
                case "NumSocio":
                    UserIQ = UserIQ.OrderBy(s => s.NumSocio);
                    break;
                case "numsocio_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.NumSocio);
                    break;
                case "EstadoUtilizador":
                    UserIQ = UserIQ.OrderBy(s => s.EstadoUtilizador);
                    break;
                case "estadoutilizador_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.EstadoUtilizador);
                    break;
                case "Contacto":
                    UserIQ = UserIQ.OrderBy(s => s.PhoneNumber);
                    break;
                case "contacto_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.PhoneNumber);
                    break;
                case "Email":
                    UserIQ = UserIQ.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.Email);
                    break;
                default:
                    UserIQ = UserIQ.OrderBy(s => s.Nome);
                    break;
            }
            if (User.IsInRole("Ginásio"))
            {
                //exclui os user's com role "Administrador"
                var role2 = await _roleManager.FindByNameAsync("Administrador");
                var userIdsToExclude = (await _userManager.GetUsersInRoleAsync(role2.Name)).Select(u => u.Id).ToList();
                UserIQ = UserIQ.Where(user => !userIdsToExclude.Contains(user.Id));
            }
                
            Users = await UserIQ.ToListAsync();
        }
    }
}