using Application.Common.Interfaces;
using CleanArc.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArc.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProjectConnection")));

            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
            services.AddTransient<IDataContext, DataContext>();

            return services;
        }
    }
}
