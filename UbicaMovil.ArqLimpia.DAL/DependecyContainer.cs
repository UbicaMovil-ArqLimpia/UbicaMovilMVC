using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using UbicaMovil.ArqLimpia.EN;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using Microsoft.Extensions.Options;

namespace UbicaMovil.ArqLimpia.DAL
{
    public class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UbicaMovilDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("conexionGQ")));

            services.AddScoped<IEmpresa, EmpresaDAL>();
            return services;
        }
    }
