using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using UbicaMovil.ArqLimpia.EN.Interfaces;

namespace UbicaMovil.ArqLimpia.DAL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UbicaMovilDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("conexionGQ")));

            services.AddScoped<IEmpresa, EmpresaDAL>();
            services.AddScoped<ICategoria, CategoriaDAL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
