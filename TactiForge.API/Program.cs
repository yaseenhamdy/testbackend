using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
//using OrdersMicroservice.API.Middlewares;
using TactiForge.API.Exceptions;
using TactiForge.API.Extensions;
using TactiForge.API.Helper;
using TactiForge.API.Setting;
using TactiForge.Core.Identity;
using TactiForge.Core.Interfaces;
using TactiForge.Core.Services;
using TactiForge.Repository.Data.Context;
using TactiForge.Repository.Data.DataSeeding;
using TactiForge.Repository.Repositories;
using TactiForge.Services.Services;

namespace TactiForge.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register FifaDbContext with dependency injection
            builder.Services.AddDbContext<Fifa24DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<UsersDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("identityconnection"));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITokenService, TokenServices>();
            builder.Services.AddTransient<IMailSettings, EmailSettings>();
            builder.Services.Configure<MailSetting>(builder.Configuration.GetSection("MailSetting"));

            builder.Services.AddIdentityService(builder.Configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    }
                );
            });


            var app = builder.Build();
            //app.UseExceptionHandlingMiddleware();

            app.UseCors("AllowAllOrigins");

            #region Update Database
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var userContext = services.GetRequiredService<UsersDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await userContext.Database.MigrateAsync();

                await UserSeeding.SeedUserAsync(userManager);
                // await S3Uploader.UploadFolderToS3Async();  
                //await ImageSeeding.Run(services);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error in Updating Database");
            }
            #endregion









            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();


            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
