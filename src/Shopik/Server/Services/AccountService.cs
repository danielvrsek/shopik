using Entity.Security;
using Microsoft.AspNetCore.Identity;
using Shopik.Shared.Account;
using Shopik.Shared.Account.Common;

namespace Shopik.Server.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task RegisterAsync(RegisterFormDto registerForm)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = registerForm.Email,
                Email = registerForm.Email,
            };

            IdentityResult result = await userManager.CreateAsync(user, registerForm.Password);
            CheckIdentityResult("Failed to create user with errors: ", result);
        }

        public async Task<bool> LoginAsync(LoginFormDto loginForm)
        {
            var result = await signInManager.PasswordSignInAsync(loginForm.Username, loginForm.Password, loginForm.RememberMe, true);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public Task LogoutAsync()
        {
            return signInManager.SignOutAsync();
        }

        private static void CheckIdentityResult(string error, IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new IdentityValidationException(error, result.Errors.Select(x => new IdentityValidationError
                {
                    Code = x.Code,
                    Description = x.Description
                }).ToArray());
            }
        }
    }
}
