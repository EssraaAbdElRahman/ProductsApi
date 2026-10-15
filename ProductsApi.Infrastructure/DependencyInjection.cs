using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsApi.Application.Abstractions;
using ProductsApi.Infrastructure.Persistence;
using ProductsApi.Infrastructure.Repositories;
namespace ProductsApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("Default")));

            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
