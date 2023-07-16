using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbicaMovil.ArqLimpia.BL.Interfaces;
using UbicaMovil.ArqLimpia.EN;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using UbicaMovil.ArqLimpia.BL.DTOs.CategoriaDTOs;

namespace UbicaMovil.ArqLimpia.BL
{
    public class CategoriaBL : ICategoriaBL
    {
        readonly ICategoria _categoriaDAL;
        readonly IUnitOfWork _unitWork;

        public CategoriaBL(ICategoria categoriaDAL, IUnitOfWork unitWork)
        {
            _categoriaDAL = categoriaDAL;
            _unitWork = unitWork;
        }

        public async Task<int> Create(CategoriaAddDTO pUser)
        {
            Categoria categoriaDAL = new Categoria()
            {
                Nombre = pUser.Nombre
            };
            _categoriaDAL.Create(categoriaDAL);
            return await _unitWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            Categoria categoriaEN = await _categoriaDAL.GetById(Id);
            if (categoriaEN.Id == Id)
            {
                _categoriaDAL.Delete(categoriaEN);
                return await _unitWork.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<List<CategoriaGetAllDTO>> GetAll()
        {
            List<Categoria> categorias = await _categoriaDAL.GetAll();
            List<CategoriaGetAllDTO> list = new List<CategoriaGetAllDTO>();
            categorias.ForEach(s => list.Add(new CategoriaGetAllDTO
            {
                Id = s.Id,
                Nombre = s.Nombre
            }));
            return list;
        }

        public async Task<CategoriaGetByIdDTO> GetById(int Id)
        {
            Categoria categoriaEN = await _categoriaDAL.GetById(Id);
            return new CategoriaGetByIdDTO()
            {
                Id = categoriaEN.Id,
                Nombre = categoriaEN.Nombre
            };
        }

        public async Task<List<CategoriaSearchOutputDTO>> Search(CategoriaSearchInputDTO pUser)
        {
            List<Categoria> categorias = await _categoriaDAL.Search(new Categoria { Id = pUser.Id, Nombre = pUser.Nombre });
            List<CategoriaSearchOutputDTO> list = new List<CategoriaSearchOutputDTO>();
            categorias.ForEach(s => list.Add(new CategoriaSearchOutputDTO
            {
                Id = s.Id,
                Nombre = s.Nombre
            }));
            return list;
        }

        public async Task<int> Update(CategoriaUpdateDTO pUser)
        {
            Categoria categoriaEN = await _categoriaDAL.GetById(pUser.Id);
            if (categoriaEN.Id == pUser.Id)
            {
                categoriaEN.Nombre = pUser.Nombre;
                _categoriaDAL.Update(categoriaEN);
                return await _unitWork.SaveChangesAsync();
            }
            else
                return 0;
        }
    }
}
