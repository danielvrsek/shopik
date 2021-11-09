using Entity.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopik.Shared.Account;

namespace Shopik.Server.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromForm] LoginFormDto loginRequest, string returnUrl)
        {
            var result = await signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, loginRequest.RememberMe, true);

            if (result.Succeeded)
            {
                returnUrl = returnUrl ?? "/";

                return Redirect("~" + returnUrl);
            }

            return Redirect("~/login");
        }

        [HttpGet("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            await signInManager.SignOutAsync();

            return Redirect("~/");
        }
    }
}
