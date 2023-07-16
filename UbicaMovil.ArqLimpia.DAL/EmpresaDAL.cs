using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UbicaMovil.ArqLimpia.DAL;
using UbicaMovil.ArqLimpia.EN;
using UbicaMovil.ArqLimpia.EN.Interfaces;

namespace UbicaMovil.ArqLimpia.DAL
{
    public class EmpresaDAL : IEmpresa
    {
        readonly UbicaMovilDBContext dbContext;
        public EmpresaDAL(UbicaMovilDBContext Context)
        {
            dbContext = Context;
        }

        public void Create(Empresa emperesa)
        {
            dbContext.Add(emperesa);
        }

        public void Delete(Empresa emperesa)
        {
            dbContext.Remove(emperesa);
        }

        public async Task<List<Empresa>> GetAll()
        {
            return await dbContext.Empresas.ToListAsync();
        }

        public async Task<Empresa> GetById(int Id)
        {
            Empresa? empresa = await dbContext.Empresas.FirstOrDefaultAsync(s => s.Id == Id);
            if (empresa != null)
                return empresa;
            else
                return new Empresa();
        }

        public Task<List<Empresa>> Search(Empresa emperesa)
        {
            var query = dbContext.Empresas.AsQueryable();
            if (!string.IsNullOrWhiteSpace(emperesa.Nombre))
                query = query.Where(s => s.Nombre.Contains(emperesa.Nombre));
            if (!string.IsNullOrWhiteSpace(emperesa.Direccion))
                query = query.Where(s => s.Direccion.Contains(emperesa.Direccion));
            return query.ToListAsync();
        }

        public void Update(Empresa emperesa)
        {
            dbContext.Update(emperesa);
        }
    }
}
