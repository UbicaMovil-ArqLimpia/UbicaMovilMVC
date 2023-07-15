using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using UbicaMovil.ArqLimpia.EN;

namespace UbicaMovil.ArqLimpia.DAL
{
    public class UbicaMovilDBContext : DbContext
    {
        internal readonly object Empresa;

        public UbicaMovilDBContext(DbContextOptions<UbicaMovilDBContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
    }
}
