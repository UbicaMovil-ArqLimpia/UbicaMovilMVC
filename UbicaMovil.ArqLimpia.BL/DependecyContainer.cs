using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using UbicaMovil.ArqLimpia.BL.Interfaces;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using UbicaMovil.ArqLimpia.EN;

namespace UbicaMovil.ArqLimpia.BL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services)
        {
            services.AddTransient<IEmpresaBL, EmpresaBL>();

            return services;
        }
    }
}
