using Entity;
using Entity.Security;
using Microsoft.AspNetCore.Identity;
using Shopik.Shared.Security;

namespace Shopik.Server.Configurations
{
    public static class SecurityInstaller
    {
        public static void AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ShopikDbContext>();

            services.ConfigureIdentityOptions();
            services.AddCookieAuthentication();
        }

        public static void AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(x =>
            {
                x.AddPolicy(SecurityPolicy.User, policy => policy.RequireAuthenticatedUser());
                x.AddPolicy(SecurityPolicy.Administrator, policy => policy.RequireRole(UserRoles.Administrator));
            });
        }

        public static void ConfigureIdentityOptions(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
        }

        public static void AddCookieAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.Name = "UserLoginCookie";
                    config.LoginPath = "/login";
                });
        }
    }
}
