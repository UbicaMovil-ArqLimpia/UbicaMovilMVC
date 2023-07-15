using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicaMovil.ArqLimpia.EN.Interfaces
{
    public interface ICategoria
    {
        public void Create(Categoria categoria);
        public void Update(Categoria categoria);
        public void Delete(Categoria categoria);
        public Task<List<Categoria>> Search(Categoria categoria);
        public Task<Categoria> GetById(int Id);
        public Task<List<Categoria>> GetAll();
    }
}
