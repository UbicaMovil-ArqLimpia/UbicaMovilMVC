using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UbicaMovil.ArqLimpia.DAL;
using UbicaMovil.ArqLimpia.BL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace UbicaMovil.ArqLimpia.IcC
{
    public class DependecyContainer
    {
        public static IServiceCollection AddProyectDEpendecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependecies(configuration);
            services.AddBLDependecies();
            return services;
        }
    }
}
