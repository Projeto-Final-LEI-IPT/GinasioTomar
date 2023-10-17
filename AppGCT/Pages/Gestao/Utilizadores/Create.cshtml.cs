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
    [Authorize(Roles = "Administrador,Gin�sio")]
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
            [Required(ErrorMessage = "Nome � campo obrigat�rio!")]
            [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve conter no minimo 5 caracteres e m�ximo 50 caracteres!")]
            [DataType(DataType.Text)]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "NIF � campo obrigat�rio!")]
            [StringLength(9, MinimumLength = 9, ErrorMessage = "NIF tem de ter 9 digitos num�ricos")]
            [RegularExpression(@"^(1\d{8}|[2-3]\d{8}|45\d{7})$", ErrorMessage = "NIF inv�lido")]
            [DataType((DataType.Text))]
            [Display(Name = "NIF")]
            public string NIF { get; set; }

            [Required(ErrorMessage = "Data Nascimento � campo obrigat�rio!")]
            [DataType(DataType.Date)]
            [Display(Name = "Dtnascim")]
            public DateTime Dtnascim { get; set; } = new DateTime(2000, 1, 1);

            [Required(ErrorMessage = "Morada � campo obrigat�rio!")]
            [StringLength(50, MinimumLength = 15, ErrorMessage = "Morada tem de ter entre 15 e 50 caracteres.")]
            [DataType(DataType.Text)]
            [Display(Name = "Morada")]
            public string Morada { get; set; }

            [Required(ErrorMessage = "C�digo Postal � campo obrigat�rio!")]
            [RegularExpression(@"^[0-9]{4}-[0-9]{3}$", ErrorMessage = "C�digo Postal deve obedecer ao seguinte crit�rio XXXX-YYY")]
            [StringLength(8)]
            [DataType((DataType.Text))]
            [Display(Name = "C�digo Postal")]
            public string CodPostal { get; set; }

            [Required(ErrorMessage = "Contacto � campo obrigat�rio!")]
            [StringLength(9, MinimumLength = 9, ErrorMessage = "Contacto tem de ter 9 digitos.")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Apenas digitos de 0 a 9 s�o permitidos")]
            [DataType(DataType.Text)]
            [Display(Name = "Contacto")]
            public string Contato { get; set; }

            [Required(ErrorMessage = "Email � campo obrigat�rio!")]
            [EmailAddress(ErrorMessage = "Email inv�lido")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password � campo obrigat�rio!")]
            [StringLength(50, ErrorMessage = "A {0} tem de ter pelo menos {2} e um m�ximo de {1} caracteres.", MinimumLength = 6)]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$",
             ErrorMessage = "Password deve conter uma letra min�scula, uma letra mai�scula, um n�mero(0 a 9) e um caracter especial.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirme Password � campo obrigat�rio!")]
            [DataType(DataType.Password)]
            [StringLength(50)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Password e Confirme Password s�o diferentes.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Tipo Utilizador � campo obrigat�rio!")]
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
            //se � administrador pode gerar todos os tipos de utilizador (Adminitrador,Gin�sio e S�cio)
            if (user != null && await _userManager.IsInRoleAsync(user, "Administrador"))
            {
                Roles = await _roleManager.Roles.OrderBy(m => m.Name).ToListAsync();
            }else
            {
                //se gin�sio n�o pode gerar admin's nem Gin�sio (apenas S�cio)
                if (user != null && await _userManager.IsInRoleAsync(user, "Gin�sio"))
                {
                    Roles = await _roleManager.Roles.Where(r => r.Name != "Gin�sio" && r.Name != "Administrador").ToListAsync();
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
                ModelState.AddModelError("Input.DtNascim", "Data de Nascimento inv�lida");
                return Page();
            }
            //valida se NIF j� est� registado mas apenas para os S�cios
            if (Input.RoleName == "S�cio")
            {
                var NIFexistente = await _context.Users.FirstOrDefaultAsync(u => u.NIF == Input.NIF && u.RoleAux == "S�cio");

                if (NIFexistente != null)
                {
                    ModelState.AddModelError("Input.NIF", "J� existe um S�cio com este NIF");
                    return Page();
                }
            }

            //valida NIF
            if (!await NIFValido(Input.NIF))
            {
                ModelState.AddModelError("Input.NIF", "NIF inv�lido");
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
                if (Input.RoleName == "S�cio")
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

