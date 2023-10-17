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
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        private async Task<bool> NIFValido(string nif)
        {
            if (string.IsNullOrEmpty(nif) || nif.Length != 9 || !Regex.IsMatch(nif, @"^\d{9}$"))
            {
                return false;
            }

            int[] weight = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int sum = 0;

            for (int i = 0; i < 8; i++)
            {
                sum += (nif[i] - '0') * weight[i];
            }

            int checkDigit = 11 - (sum % 11);
            if (checkDigit >= 10)
            {
                checkDigit = 0;
            }

            return (checkDigit == nif[8] - '0');
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

            [Required(ErrorMessage = "NIF é campo obrigatório!")]
            [StringLength(9, MinimumLength = 9, ErrorMessage = "NIF tem de ter 9 digitos numéricos")]
            [RegularExpression(@"^(1\d{8}|[2-3]\d{8}|45\d{7})$", ErrorMessage = "NIF inválido")]
            [DataType((DataType.Text))]
            [Display(Name = "NIF")]
            public string NIF { get; set; }

            [Required(ErrorMessage = "Data Nascimento é campo obrigatório!")]
            [DataType(DataType.Date)]
            [Display(Name = "Dtnascim")]
            public DateTime Dtnascim { get; set; } = new DateTime(2000, 1, 1);

            [Required(ErrorMessage = "Morada é campo obrigatório!")]
            [StringLength(50, MinimumLength = 15, ErrorMessage = "Morada tem de ter entre 15 e 50 caracteres.")]
            [DataType(DataType.Text)]
            [Display(Name = "Morada")]
            public string Morada { get; set; }

            [Required(ErrorMessage = "Código Postal é campo obrigatório!")]
            [RegularExpression(@"^[0-9]{4}-[0-9]{3}$", ErrorMessage = "Código Postal deve obedecer ao seguinte critério XXXX-YYY")]
            [StringLength(8)]
            [DataType((DataType.Text))]
            [Display(Name = "Código Postal")]
            public string CodPostal { get; set; }

            [Required(ErrorMessage = "Contacto é campo obrigatório!")]
            [StringLength(9, MinimumLength = 9, ErrorMessage = "Contacto tem de ter 9 digitos.")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Apenas digitos de 0 a 9 são permitidos")]
            [DataType(DataType.Text)]
            [Display(Name = "Contacto")]
            public string Contato { get; set; }

            [Required(ErrorMessage = "Email é campo obrigatório!")]
            [EmailAddress(ErrorMessage = "Email inválido")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password é campo obrigatório!")]
            [StringLength(50, ErrorMessage = "A {0} tem de ter pelo menos {2} e um máximo de {1} caracteres.", MinimumLength = 6)]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$",
             ErrorMessage = "Password deve conter uma letra minúscula, uma letra maiúscula, um número(0 a 9) e um caracter especial.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirme Password é campo obrigatório!")]
            [DataType(DataType.Password)]
            [StringLength(50)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Password e Confirme Password são diferentes.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Tipo Utilizador é campo obrigatório!")]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Input = new CreateUserModel
            {
                Dtnascim = new DateTime(DateTime.Now.Year, 1, 1)
            };
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
            Roles = await _roleManager.Roles.ToListAsync();
            //valida data nascimento
            var dataDia = DateTime.Now;
            if (Input.Dtnascim >= dataDia)
            {
                ModelState.AddModelError("Input.DtNascim", "Data de Nascimento inválida");
                return Page();
            }
            //valida se NIF já está registado mas apenas para os Sócios
            if (Input.RoleName == "Sócio")
            {
                var NIFexistente = await _context.Users.FirstOrDefaultAsync(u => u.NIF == Input.NIF && u.RoleAux == "Sócio");

                if (NIFexistente != null)
                {
                    ModelState.AddModelError("Input.NIF", "Já existe um Sócio com este NIF");
                    return Page();
                }
            }

            //valida NIF
            if (!await NIFValido(Input.NIF))
            {
                ModelState.AddModelError("Input.NIF", "NIF inválido");
                return Page();
            }

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = new Utilizador {
                    UserName = Input.Email,
                    Email = Input.Email,
                    DataNascim = Input.Dtnascim,
                    Nome = Input.Nome,
                    NIF = Input.NIF,
                    RoleAux = Input.RoleName,
                    Morada = Input.Morada,
                    CodPostal = Input.CodPostal,
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
            return Page();
        }
    }
}

