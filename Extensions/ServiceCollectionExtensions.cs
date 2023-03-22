using Microsoft.OpenApi.Models;
using ReenbitCamp_TestTask_backend.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

namespace ReenbitCamp_TestTask_backend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IBlobService, BlobService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        }

        public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.SetPreflightMaxAge(TimeSpan.FromDays(1));
                });
            });

            services.AddLogging();
            services.AddControllers();
        }

        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApi", Version = "v1" });

                opt.CustomSchemaIds(x => x.FullName);
            });
        }
    }
}
