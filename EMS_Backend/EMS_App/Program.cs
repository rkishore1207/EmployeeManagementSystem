
using AzureServices;
using BusinessLogics;
using DataAccessLayer;
using EMS_App.Middlewares;
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlingMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
