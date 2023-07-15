using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbicaMovil.ArqLimpia.BL.Interfaces;
using UbicaMovil.ArqLimpia.EN;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using UbicaMovil.ArqLimpia.BL.DTOs.EmpreaDTOs;

namespace UbicaMovil.ArqLimpia.BL
{
    public class CategoriaBL : ICategoria
    {
        readonly ICategoria _categoriaDAL;
        readonly IUnitOfWork _unitOfWork;

        public CategoriaBL(ICategoria categoriaDAL, IUnitOfWork unitOfWork)
        {
            _categoriaDAL = categoriaDAL;
            _unitOfWork = unitOfWork;
        }

        public void Create(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Delete(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<List<Categoria>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Categoria>> Search(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
