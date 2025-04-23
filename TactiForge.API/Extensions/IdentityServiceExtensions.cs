using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TactiForge.API.Helper;
using TactiForge.API.Setting;
using TactiForge.Core.Identity;
using TactiForge.Repository.Data.Context;

namespace TactiForge.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDbContext>();

            services.Configure<JwtOptions>(configuration.GetSection("JWT"));
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            //services.AddSingleton(provider =>
            //{
            //    var jwtOptions = provider.GetRequiredService<IOptions<JwtOptions>>().Value;
            //    var optionsSetup = new JwtBearerOptionsSetup(Options.Create(jwtOptions));
            //    return optionsSetup.CreateTokenValidationParameters();
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>{

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!))
                };
            });

            return services;
        }
    }
}
