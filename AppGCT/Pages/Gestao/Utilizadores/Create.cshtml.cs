using AppGCT.Areas.Identity.Data;
using AppGCT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppGCT.Data.AppGCTContext _context;

        public CreateModel(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager, AppGCT.Data.AppGCTContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context; 
        }

        public string Username { get; set; }
        public List<IdentityRole> Roles { get; set; }

        [BindProperty]
        public CreateUserModel Input { get; set; }

        public class CreateUserModel
        {
            [Required(ErrorMessage = "Nome é campo obrigatório!")]
            [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve conter no minimo 5 caracteres e máximo 50 caracteres!")]
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

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Username = User.FindFirstValue(ClaimTypes.Name);
            var user = await _userManager.GetUserAsync(User);
            //se é administrador pode gerar todos os tipos de utilizador (Adminitrador,Ginásio e Sócio)
            if (user != null && await _userManager.IsInRoleAsync(user, "Administrador"))
            {
                Roles = await _roleManager.Roles.OrderBy(m => m.Name).ToListAsync();
            }else
            {
                //se ginásio não pode gerar admin's nem Ginásio (apenas Sócio)
                if (user != null && await _userManager.IsInRoleAsync(user, "Ginásio"))
                {
                    Roles = await _roleManager.Roles.Where(r => r.Name != "Ginásio" && r.Name != "Administrador").ToListAsync();
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = new Utilizador {
                    UserName = Input.Email,
                    Email = Input.Email,
                    DataNascim = Input.Dtnascim,
                    Nome = Input.Nome,
                    NIF = Input.NIF,
                    Morada = Input.Morada,
                    RoleAux = Input.RoleName,
                    PhoneNumber = Input.Contato,
                    EmailConfirmed = true,
                    EstadoUtilizador = "A",
                    UltimoLogin = DateTime.MinValue,
                    DataAprovacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    IdCriacao = userId,
                    DataModificacao = DateTime.MinValue,
                    IdModificacao = " ",
                    NumSocio = " "
            };
                
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Input.RoleName);
                if (Input.RoleName == "Sócio")
                {
                    //cria registo na tabela de saldos
                    var saldo = new Saldo
                    {
                        IdSocio = user.Id,
                        MSaldo = 0
                    };
                    _context.Saldo.Add(saldo);
                    await _context.SaveChangesAsync();
                }
                return RedirectToPage("./Index");
            }

            foreach (var error in result.Errors)
            {
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            }

            Roles = await _roleManager.Roles.ToListAsync();
            return Page();
        }
    }
}

