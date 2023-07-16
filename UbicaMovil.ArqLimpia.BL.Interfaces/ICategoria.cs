using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbicaMovil.ArqLimpia.BL.DTOs.CategoriaDTOs;

namespace UbicaMovil.ArqLimpia.BL.Interfaces
{
    public interface ICategoriaBL
    {
        Task<int> Create(CategoriaAddDTO pCategoria);
        Task<int> Update(CategoriaUpdateDTO pCategoria);
        Task<int> Delete(int id);
        Task<CategoriaGetByIdDTO> GetById(int id);
        Task<List<CategoriaGetAllDTO>> GetAll();
        Task<List<CategoriaSearchOutputDTO>> Search(CategoriaSearchInputDTO pCategoria);
    }
}
