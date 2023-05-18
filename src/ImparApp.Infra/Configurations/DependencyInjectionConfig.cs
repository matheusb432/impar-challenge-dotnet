using ImparApp.Infra.Extensions;
using ImparApp.Infra.Interfaces;
using ImparApp.Infra.Repositories;
using ImparApp.Infra.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImparApp.Infra.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddInfraConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isEnv = false
        )
        {
            if (isEnv)
            {
                services.AddEnvDatabase();
            }
            else
            {
                services.AddDatabase(configuration);
            }
            services.AddRepositories();
            services.MigrateDatabase();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPhotoRepository, PhotoRepository>();
            services.AddTransient<ICardRepository, CardRepository>();
        }

        private static void AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration
        ) =>
            services.AddDbContext<ImparContext>(
                opt =>
                    opt.UseSqlServer(
                            configuration.GetConnectionString(InfraUtils.DefaultConnectionName)
                        )
            );

        private static void AddEnvDatabase(this IServiceCollection services) =>
            services.AddDbContext<ImparContext>(
                opt =>
                    opt.UseSqlServer(ConnectionStringBuilder.BuildEnvCnnStr("ImparDB"))
            );

        private static void MigrateDatabase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<ImparContext>();

            if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
                context.Database.Migrate();
        }
    }
}
