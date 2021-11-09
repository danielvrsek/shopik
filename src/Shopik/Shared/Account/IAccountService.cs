namespace Shopik.Shared.Account
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterFormDto registerForm);

        Task<bool> LoginAsync(LoginFormDto loginRequest);

        Task LogoutAsync();
    }
}
