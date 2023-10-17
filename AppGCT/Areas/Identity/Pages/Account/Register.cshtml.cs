// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using AppGCT.Outros;
using AppGCT.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace AppGCT.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly UserManager<Utilizador> _userManager;
        private readonly IUserStore<Utilizador> _userStore;
        private readonly IUserEmailStore<Utilizador> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly AppGCT.Data.AppGCTContext _context;

        public RegisterModel(
            UserManager<Utilizador> userManager,
            IUserStore<Utilizador> userStore,
            SignInManager<Utilizador> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            AppGCT.Data.AppGCTContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _emailSender = emailSender;
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

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Nome Completo é campo obrigatório!")]
            [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome Completo tem de ter minimo 5 e máximo 50 caracteres")]
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

            [Required(ErrorMessage = "Código Postal é campo obrigatório!")]
            [RegularExpression(@"^[0-9]{4}-[0-9]{3}$", ErrorMessage = "Código Postal deve obedecer ao seguinte critério XXXX-YYY")]
            [StringLength(8)]
            [DataType((DataType.Text))]
            [Display(Name = "Código Postal")]
            public string CodPostal { get; set; }

            [Required(ErrorMessage = "Contacto é campo obrigatório!")]
            [StringLength(9, MinimumLength =9, ErrorMessage = "Contacto tem de ter 9 digitos.")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Apenas digitos de 0 a 9 são permitidos")]
            [DataType(DataType.Text)]
            [Display(Name = "Contacto")]
            public string Contato { get; set; }

            [Required(ErrorMessage = "Email é campo obrigatório!")]
            [EmailAddress(ErrorMessage = "Email inválido")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Password é campo obrigatório!")]
            [StringLength(50, ErrorMessage = "A {0} tem de ter pelo menos {2} e um máximo de {1} caracteres.", MinimumLength = 6)]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$",
             ErrorMessage = "Password deve conter uma letra minúscula, uma letra maiúscula, um número(0 a 9) e um caracter especial.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [StringLength(50)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Password e Confirme Password são diferentes.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var dataDia = DateTime.Now;
            //valida data nascimento
            if (Input.Dtnascim >= dataDia)
            {
                ModelState.AddModelError("Input.DtNascim", "Data de Nascimento inválida");
                return Page();
            }
            //valida se NIF já está registado
            var NIFexistente = await _context.Users.FirstOrDefaultAsync(u => u.NIF == Input.NIF && u.RoleAux == "Sócio");

            if (NIFexistente != null)
            {
                ModelState.AddModelError("Input.NIF", "Já existe um Sócio com este NIF");
                return Page();
            }
            //valida NIF
            if (!await NIFValido(Input.NIF))
            {
                ModelState.AddModelError("Input.NIF", "NIF inválido");
                return Page();
            }

            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.Nome = Input.Nome;
                user.NIF = Input.NIF;
                user.DataNascim = Input.Dtnascim;
                user.Morada = Input.Morada;
                user.CodPostal = Input.CodPostal;
                user.PhoneNumber = Input.Contato;
                user.RoleAux = "Sócio";
                // REGISTA UTILIZADOR COMO 'P-PRÉ ATIVO'
                user.EstadoUtilizador = "P";
                user.UltimoLogin = DateTime.MinValue;
                user.DataAprovacao = DateTime.MinValue;
                user.DataCriacao = DateTime.Now;
                user.IdCriacao = user.Id;
                user.DataModificacao = DateTime.MinValue;
                user.IdModificacao = "";
                user.NumSocio = " ";



                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    var defaultrole = _roleManager.FindByNameAsync("Sócio").Result;

                    if (defaultrole != null)
                    {
                        IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
                    }
                    var userId = await _userManager.GetUserIdAsync(user);
                    //cria registo na tabela de saldos
                    var saldo = new Saldo
                    {
                        IdSocio = userId,
                        MSaldo = 0
                    };
                    _context.Saldo.Add(saldo);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Ative o seu registo - Ginásio Clube de Tomar",
                        $"<br><b>Obrigado pelo seu registo!</b><br>" +
                        $"<br> Caro(a) Sócio(a) <b>{Input.Nome}</b>,<br> " +
                        $"Para finalizar a ativação do seu registo, por favor, confirme o seu registo <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>carregando aqui</a>." +
                        $"<br><br> Este e-mail foi enviado de forma automática, por favor não responda diretamente para este endereço." +
                        $"<br>Alguma dúvida ou sugestão não hesite em contactar-nos.<br><br>" +
                        $"Com os melhores cumprimentos,<br>" +
                        $"<b>Ginásio Clube de Tomar</b>");

                    await _context.SaveChangesAsync();

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private Utilizador CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Utilizador>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Utilizador)}'. " +
                    $"Ensure that '{nameof(Utilizador)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<Utilizador> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Utilizador>)_userStore;
        }
    }
}
