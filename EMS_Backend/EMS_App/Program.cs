
using AzureServices;
using BusinessLogics;
using DataAccessLayer;
using EMS_App.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Utilities.ConfigService;

namespace EMS_App
{
    public class Program
    {
        public static void Main(string[] args)
        {          
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();
            builder.Services.AddBusinessServices().AddDataServices().AddAzureServices();

            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("ReactCORS", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlingMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
