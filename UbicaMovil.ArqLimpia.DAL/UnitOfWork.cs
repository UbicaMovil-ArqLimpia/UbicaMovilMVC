using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UbicaMovil.ArqLimpia.EN.Interfaces;

namespace UbicaMovil.ArqLimpia.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly UbicaMovilDBContext dbContext;
        public UnitOfWork(UbicaMovilDBContext pDbContext)
        {
            dbContext = pDbContext;
        }

        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
