using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using DataLayer.Triggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseTriggers(triggersOption =>
                {
                    triggersOption.AddTrigger<PlaceReservationsTrigger>();
                });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IUserDishRepository, UserDishRepository>();

            return services;
        }
    }
}
