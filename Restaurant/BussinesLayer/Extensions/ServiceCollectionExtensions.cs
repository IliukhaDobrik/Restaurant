using BussinesLayer.Helpers.EmailSenders;
using BussinesLayer.Helpers.EmailSenders.Interfaces;
using BussinesLayer.Interfaces;
using BussinesLayer.Services;
using DataLayer.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BussinesLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBussinesLayerService(this IServiceCollection services, string connectionString)
        {
            services.AddDatabase(connectionString);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDishService, UserDishService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddAutoMapper(Assembly.GetCallingAssembly(),
                                   Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
