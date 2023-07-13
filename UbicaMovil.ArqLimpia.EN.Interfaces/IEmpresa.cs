using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbicaMovil.ArqLimpia.EN.Interfaces
{
    public interface IEmpresa
    {
        public void Create(Empresa emperesa);
        public void Update(Empresa emperesa);
        public void Delete(Empresa emperesa);
        public Task<List<Empresa>> Search(Empresa emperesa);
        public Task<Empresa> GetById(int Id);
        public Task<List<Empresa>> GetAll();
    }
}
