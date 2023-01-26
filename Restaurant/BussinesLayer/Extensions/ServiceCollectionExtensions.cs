using BussinesLayer.Interfaces;
using BussinesLayer.Services;
using DataLayer.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBussinesLayerService(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddDatabase(connectionString);
            services.AddAutoMapper(Assembly.GetCallingAssembly(),
                               Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
