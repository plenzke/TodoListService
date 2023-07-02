using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Todo.Application.Interfaces;

namespace Todo.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TasksDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<ITasksDbContext>(provider => provider.GetService<TasksDbContext>());

            return services;
        }
    }
}