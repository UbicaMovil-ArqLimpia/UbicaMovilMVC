using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbicaMovil.ArqLimpia.BL.DTOs;
using UbicaMovil.ArqLimpia.BL.DTOs.EmpresaDTOs;

namespace UbicaMovil.ArqLimpia.BL.Interfaces
{
    public interface IEmpresaBL
    {
        Task<int> Create(EmpresaAddDTO pEmpresa);
        Task<int> Update(EmpresaUpdateDTO pEmpresa);
        Task<int> Delete(int id);
        Task<EmpresaGetByIdDTO> GetById(int id);
        Task<List<EmpresaGetAllDTO>> GetAll();
        Task<List<EmpresaSearchOutputDTO>> Search(EmpresaSearchInputDTO pEmpresa);
    }
}
