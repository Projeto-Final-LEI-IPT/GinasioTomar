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
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using SendGrid.Helpers.Mail;

namespace AppGCT.Pages.Gestao.Utilizadores
{
    [Authorize(Roles = "Administrador,Ginásio")]
    public class EditModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppGCT.Data.AppGCTContext _context;

        public EditModel(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager, Data.AppGCTContext context)
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
        public EditUserModel Input { get; set; }

        public class EditUserModel
        {
            [Required(ErrorMessage = "Nome é campo obrigatório!")]
            [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve conter no minimo 5 caracteres e máximo 50 caracteres!")]
            [DataType(DataType.Text)]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "NIF é campo obrigatório!")]
            [StringLength(9, MinimumLength = 9, ErrorMessage = "NIF tem de ter 9 digitos numéricos.")]
            [RegularExpression(@"^(1\d{8}|[2-3]\d{8}|45\d{7})$", ErrorMessage = "NIF inválido.")]
            [DataType((DataType.Text))]
            [Display(Name = "NIF")]
            public string NIF { get; set; }

            [Required(ErrorMessage = "Data Nascimento é campo obrigatório!")]
            [DataType(DataType.Date)]
            [Display(Name = "Dtnascim")]
            public DateTime Dtnascim { get; set; }

            [Required(ErrorMessage = "Morada é campo obrigatório!")]
            [StringLength(50, MinimumLength = 15, ErrorMessage = "Morada tem de ter entre 15 e 50 caracteres.")]
            [DataType(DataType.Text)]
            [Display(Name = "Morada")]
            public string Morada { get; set; }

            [Required(ErrorMessage = "Contacto é campo obrigatório!")]
            [StringLength(9, MinimumLength = 9, ErrorMessage = "Contacto tem de ter 9 digitos.")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Apenas digitos de 0 a 9 são permitidos")]
            [DataType(DataType.Text)]
            [Display(Name = "Contacto")]
            public string Contato { get; set; }

            [Required(ErrorMessage = "Código Postal é campo obrigatório!")]
            [RegularExpression(@"^[0-9]{4}-[0-9]{3}$", ErrorMessage = "Código Postal deve obedecer ao seguinte critério XXXX-YYY")]
            [StringLength(8)]
            [DataType((DataType.Text))]
            [Display(Name = "Código Postal")]
            public string CodPostal { get; set; }

            [Required(ErrorMessage = "Email é campo obrigatório!")]
            [EmailAddress(ErrorMessage = "Email inválido")]
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
                CodPostal = user.CodPostal,
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
            ModelState.Remove("Input.NumSocio"); // Remove validação para o campo RoleName que não é editavel

            var dataDia = DateTime.Now;
            //data nascimento superior a 1900
            if (Input.Dtnascim.Year < 1900)
            {
                ModelState.AddModelError("Input.DtNascim", "Data Nascimento(ano) tem de ser superior ou igual a 1900");
                return Page();
            }
            //valida data nascimento
            if (Input.Dtnascim >= dataDia)
            {
                ModelState.AddModelError("Input.DtNascim", "Data de Nascimento inválida");
                return Page();
            }

            //valida se NIF já está registado mas apenas para os Sócios
            if (Input.RoleName == "Sócio")
            {
                var NIFexistente = await _context.Users.FirstOrDefaultAsync(u => u.NIF == Input.NIF && u.Id != Input.Id && u.RoleAux == "Sócio");

                if (NIFexistente != null)
                {
                    ModelState.AddModelError("Input.NIF", "Já existe um Sócio com este NIF");
                    return Page();
                }
            }

            //valida NIF
            if (!await NIFValido(Input.NIF))
            {
                ModelState.AddModelError("Input.NIF", "NIF inválido.");
                return Page();
            }

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
            user.CodPostal = Input.CodPostal;
            user.PhoneNumber = Input.Contato;
            user.DataModificacao = DateTime.Now;
            if (Input.NumSocio != null)
            {
                // valida se tem letras no número sócio
                bool temLetras = Input.NumSocio.Any(char.IsLetter);

                if (temLetras)
                {
                    user.NumSocio = "";
                }
                else
                {
                    //valida se o Número de Sócio já está atribuido
                    var existeNumSocio = _userManager.Users.Any(u => u.NumSocio == Input.NumSocio && u.Id != Input.Id);

                    if (existeNumSocio)
                    {
                        ModelState.AddModelError("Input.NumSocio", "Número de Sócio já registado");
                        return Page();
                    }
                    else
                    {
                        //retira os espaços da string
                        user.NumSocio = Input.NumSocio.TrimStart();
                    }  
                }   
            }
            else
            {
                user.NumSocio = "";
            }

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
                //valida se e-mail já atribuido
                var existeEmail = _userManager.Users.Any(u => u.Email == Input.Email && u.Id != Input.Id);
                if(existeEmail)
                {
                    ModelState.AddModelError("Input.Email", "Email já se encontra registado!");
                    return Page();
                }
                else
                {
                    var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                    if (!setEmailResult.Succeeded)
                    {
                        ModelState.AddModelError("Input.Email", "Erro a alterar Email!");
                        return Page();
                    }
                    else
                    {
                        user.NormalizedUserName = Input.Email;
                        user.UserName = Input.Email;
                        user.EmailConfirmed = true;
                    }
                }
                
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        ModelState.AddModelError("Input.Email", "Email já se encontra registado!");
                        return Page();
                    }
                    else
                    {
                        ModelState.AddModelError("Input.Email", error.Description);
                        return Page();
                    }
                }
                //throw new InvalidOperationException($"Unexpected error occurred updating user with ID '{user.Nome}'.");
            }

            return RedirectToPage("./Index");
        }
    }
}



