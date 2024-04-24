using Core.Contracts.Persistence;
using Infra.Database.DatabaseContext;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration  configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SqliteDatabaseContext>(options =>
                options.UseSqlite(connectionString));

            //repository
            services.AddScoped<IToDoListRepository, ToDoListRepository>();

            return services;
        }

        
    }
}
