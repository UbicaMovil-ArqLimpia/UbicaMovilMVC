using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using UbicaMovil.ArqLimpia.DAL;
using UbicaMovil.ArqLimpia.EN;


namespace UbicaMovil.ArqLimpia.DAL
{
    public class CategoriaDAL : ICategoria
    {
        readonly UbicaMovilDBContext dbContext;
        public CategoriaDAL(UbicaMovilDBContext Context)
        {
            dbContext = Context;
        }

        public void Create(Categoria categoria)
        {
            dbContext.Add(categoria);
        }

        public void Delete(Categoria categoria)
        {
            dbContext.Remove(categoria);
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await dbContext.Categoria.ToListAsync();
        }

        public async Task<Categoria> GetById(int Id)
        {
            Categoria? categoria = await dbContext.Categoria.FirstOrDefaultAsync(s => s.Id == Id);
            if (categoria != null)
                return categoria;
            else
                return new Categoria();
        }

        public Task<List<Categoria>> Search(Categoria categoria)
        {
            var query = dbContext.Categoria.AsQueryable();
            if (!string.IsNullOrWhiteSpace(categoria.Name))
                query = query.Where(s => s.Name.Contains(categoria.Name));
            return query.ToListAsync();
        }

        public void Update(Categoria categoria)
        {
            dbContext.Update(categoria);
        }
    }
}
