// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AppGCT.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AppGCT.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
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
        [TempData]
        public string StatusMessage { get; set; }

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

            [Required(ErrorMessage = "Password atual é campo obrigatório!")]
            [StringLength(50, ErrorMessage = "A {0} tem de ter pelo menos {2} e um máximo de {1} caracteres.", MinimumLength = 6)]
            ///[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$",
            /// ErrorMessage = "Password deve conter uma letra minúscula, uma letra maiúscula, um número(0 a 9) e um caracter especial.")]
            [DataType(DataType.Password)]
            [Display(Name = "Password atual")]
            public string OldPassword { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Nova Password é campo obrigatório!")]
            [StringLength(50, ErrorMessage = "A {0} tem de ter pelo menos {2} e um máximo de {1} caracteres.", MinimumLength = 6)]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).+$",
             ErrorMessage = "Password deve conter uma letra minúscula, uma letra maiúscula, um número(0 a 9) e um caracter especial.")]
            [DataType(DataType.Password)]
            [Display(Name = "Nova Password")]
            public string NewPassword { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>

            
            
            [Required(ErrorMessage = "Nova Password é campo obrigatório!")]
            [StringLength(50)]
            [Compare("NewPassword", ErrorMessage = "A Nova Password e a Confirmação Nova Password são diferentes.")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmação Nova Password")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    if (error.Code == "PasswordMismatch")
                    {
                        ModelState.AddModelError(string.Empty, "Password atual inválida");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    } 
                }
                return Page();
            }else
            {
                //atualização de password com sucesso e atualização dos campos de histórico
                user.DataModificacao = DateTime.Now;
                user.IdModificacao = user.Id;
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("Utilizador alterou a password com sucesso");
            StatusMessage = "Password atualizada com sucesso";

            return RedirectToPage();
        }
    }
}
