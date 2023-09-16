// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using AppGCT.Outros;

namespace AppGCT.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly IEmailSender _emailSender;

        public ResendEmailConfirmationModel(UserManager<Utilizador> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Email é campo obrigatório!")]
            [EmailAddress(ErrorMessage = "Email inválido")]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Confirmação do registo enviada. Por favor, valide o seu e-mail.");
                return Page();
            }

            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError(string.Empty, "A sua conta já foi ativada. Faça login para continuar.");
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(Input.Email, "Ative o seu registo - Ginásio Clube de Tomar",
                        $"<br><b>Obrigado pelo seu registo!</b><br>" +
                        $"<br> Caro(a) Sócio(a) <b>{user.Nome}</b>,<br> " +
                        $"Para finalizar a ativação do seu registo, por favor, confirme o seu registo <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>carregando aqui</a>." +
                        $"<br><br> Este e-mail foi enviado de forma automática, por favor não responda diretamente para este endereço." +
                        $"<br>Alguma dúvida ou sugestão não hesite em contactar-nos.<br><br>" +
                        $"Com os melhores cumprimentos,<br>" +
                        $"<b>Ginásio Clube de Tomar</b>");

            ModelState.AddModelError(string.Empty, "Confirmação do registo enviada. Por favor, valide o seu e-mail.");
            return Page();
        }
    }
}
