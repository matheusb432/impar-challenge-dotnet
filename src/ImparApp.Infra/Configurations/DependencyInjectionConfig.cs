using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImparApp.Infra.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddRepositories();
            services.MigrateDatabase();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPhotoRepository, PhotoRepository>();
            services.AddTransient<ICardRepository, CardRepository>();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
            // TODo replace by static class prop
            => services.AddDbContext<ImparContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

        private static void MigrateDatabase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<ImparContext>();
            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
                context.Database.Migrate();
        }
    }
}
