using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.ComponentModel;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class EditModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditModel(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public string Username { get; set; }
        public List<IdentityRole> Roles { get; set; }

        [BindProperty]
        public EditUserModel Input { get; set; }

        public class EditUserModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [RegularExpression(@"^[0-9]*$"), Required, StringLength(9, MinimumLength = 9)]
            [DataType(DataType.Text)]
            [Display(Name = "NIF")]
            public string NIF { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Dtnascim")]
            public DateTime Dtnascim { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 15)]
            [DataType(DataType.Text)]
            [Display(Name = "Morada")]
            public string Morada { get; set; }

            [RegularExpression(@"^[0-9]*$"), Required, StringLength(9, MinimumLength = 9)]
            [DataType(DataType.Text)]
            [Display(Name = "Contato")]
            public string Contato { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [ReadOnly(true)]
            [Display(Name = "Role")]
            public string RoleName { get; set; }

            [Display(Name = "Id")]
            public string Id { get; set; }
            [Display(Name = "Número Sócio")]
            public string NumSocio { get; set; }
            [Display(Name = "Estado Ginasta")]
            public string Estado { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Username = User.FindFirstValue(ClaimTypes.Name);

            Input = new EditUserModel
            {
                Nome = user.Nome,
                NIF = user.NIF,
                Dtnascim = user.DataNascim,
                Morada = user.Morada,
                Contato = user.PhoneNumber,
                Email = user.Email,
                Id = user.Id,
                NumSocio = user.NumSocio,
                Estado = user.EstadoUtilizador,
                RoleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Input.RoleName"); // Remove validação para o campo RoleName que não é editavel

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Input.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.Nome = Input.Nome;
            user.NIF = Input.NIF;
            user.DataNascim = Input.Dtnascim;
            user.Morada = Input.Morada;
            user.PhoneNumber = Input.Contato;
            user.DataModificacao = DateTime.Now;
            user.NumSocio = Input.NumSocio;
            user.EstadoUtilizador = Input.Estado;

            if (Input.Estado == "A")
            {
                await _userManager.SetLockoutEnabledAsync(user, false);
            }
            else
            {
                await _userManager.SetLockoutEnabledAsync(user, true);
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(100));
            }
            var userId = _userManager.GetUserId(User);
            user.IdModificacao = userId;
           
            var email = user.Email;
            if (email != Input.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{user.Nome}'.");
                }
                else
                {
                    user.NormalizedUserName = Input.Email;
                    user.UserName = Input.Email;
                    user.EmailConfirmed = true;
                }
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred updating user with ID '{user.Nome}'.");
            }

            return RedirectToPage("Index");
        }
    }
}



