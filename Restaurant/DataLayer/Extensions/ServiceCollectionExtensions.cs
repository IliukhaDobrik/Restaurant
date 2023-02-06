using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IUserDishRepository, UserDishRepository>();

            return services;
        }
    }
}
