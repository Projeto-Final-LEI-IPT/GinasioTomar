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

            [Display(Name = "Role")]
            public string RoleName { get; set; }
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
                RoleName = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Input.Id);
            if (user == null)
            {
                return NotFound();
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Administrador");
            var isGym = await _userManager.IsInRoleAsync(user, "Ginásio");

            if (!isAdmin && !isGym)
            {
                return Forbid();
            }

            if (isGym && !User.IsInRole("Administrador"))
            {
                return Forbid();
            }

            user.Nome = Input.Nome;
            user.NIF = Input.NIF;
            user.DataNascim = Input.Dtnascim;
            user.Morada = Input.Morada;
            user.PhoneNumber = Input.Contato;

            var email = user.Email;
            if (email != Input.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            var role = await _roleManager.FindByIdAsync(Input.RoleId);
            if (role == null)
            {
                throw new InvalidOperationException($"Unexpected error occurred finding role with ID '{Input.RoleId}'.");
            }

            var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            if (!removeRolesResult.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred removing roles for user with ID '{user.Id}'.");
            }

            var addRolesResult = await _userManager.AddToRoleAsync(user, role.Name);
            if (!addRolesResult.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred adding role '{role.Name}' to user with ID '{user.Id}'.");
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred updating user with ID '{user.Id}'.");
            }

            return RedirectToPage("./Index");
        }
    }
}



