// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppGCT.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly SignInManager<Utilizador> _signInManager;

        public IndexModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Display(Name = "Email")]
        public string Username { get; set; }

        [Display(Name = "Nº Sócio")]
        public string NumSocio { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
   
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

            [Phone]
            [Required(ErrorMessage = "Contacto é campo obrigatório!")]
            [StringLength(9, MinimumLength = 9, ErrorMessage = "Contacto tem de ter 9 digitos.")]
            [RegularExpression(@"^[0-9]*$", ErrorMessage = "Apenas digitos de 0 a 9 são permitidos")]
            [DataType(DataType.Text)]
            [Display(Name = "Contacto")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(Utilizador user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
            NumSocio = user.NumSocio;

            if (NumSocio.Equals(""))
            {
                NumSocio = "Não atribuído";
            }

            Input = new InputModel
            {
                Morada = user.Morada,
                CodPostal = user.CodPostal,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var phoneNumberAnt = phoneNumber;
            var moradaAnt = user.Morada;
            var codPostalAnt = user.CodPostal;

            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
                else
                {
                    //atualização de contato com sucesso e atualização dos campos de histórico
                    user.DataModificacao = DateTime.Now;
                    user.IdModificacao = user.Id;
                }

            }

            if (Input.Morada != user.Morada || Input.CodPostal != user.CodPostal)
            {
                user.Morada = Input.Morada;
                user.CodPostal = Input.CodPostal;
                //atualização de morada com sucesso e atualização dos campos de histórico
                user.DataModificacao = DateTime.Now;
                user.IdModificacao = user.Id;
            }

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            if ((Input.PhoneNumber != phoneNumberAnt) || (Input.Morada != moradaAnt) || (Input.CodPostal != codPostalAnt))
            {
                StatusMessage = "Perfil Atualizado";
            }else
            {
                StatusMessage = "Perfil sem atualizações";
            }
            return RedirectToPage();
        }
    }
}
