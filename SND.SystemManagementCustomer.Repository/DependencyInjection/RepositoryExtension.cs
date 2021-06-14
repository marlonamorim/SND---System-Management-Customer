using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SND.SystemManagementCustomer.Repository.Interfaces;
using SND.SystemManagementCustomer.Repository.Repositories;

namespace SND.SystemManagementCustomer.Repository.DependencyInjection
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SystemManagementContext>(options =>
                options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}