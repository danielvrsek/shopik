using Entity;
using Entity.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shopik.Shared.Security;
using System.Text;

namespace Shopik.Server.Configurations
{
    public static class SecurityInstaller
    {
        public static void AddCustomAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ShopikDbContext>();

            ConfigureIdentityOptions(builder.Services);
            AddJwtAuthentication(builder.Services, builder.Configuration);
        }

        public static void AddCustomAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(x =>
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

        public static void AddJwtAuthentication(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configurationManager["Jwt:Issuer"],
                        ValidAudience = configurationManager["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager["Jwt:Key"]))
                    };
                });
        }
    }
}
