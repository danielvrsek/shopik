namespace Shopik.Shared.Account
{
    public class LoginFormDto
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
