using System.Reflection;
using ImparApp.Application.Interfaces;
using ImparApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImparApp.Application.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddApplicationDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ICardService, CardService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
