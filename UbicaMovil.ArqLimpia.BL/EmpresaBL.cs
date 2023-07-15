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
    public class EmpresaBL : IEmpresaBL
    {
        readonly IEmpresa _empresaDAL;
        readonly IUnitOfWork _unitOfWork;

        public EmpresaBL(IEmpresaBL empresaDAL, IUnitOfWork unitOfWork)
        {
            _empresaDAL = empresaDAL;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(EmpresaAddDTO empresa)
        {
            Empresa empresaDAL = new Empresa()
            {
                Id = empresa.Id,
                Nombre = empresa.Nombre,
                Direccion = empresa.Direccion,
                Telefono = empresa.Telefono,
                HoraEntrada = empresa.HoraEntrada,
                HoraSalida = empresa.HoraSalida,
                Latitud = empresa.Latitud,
                Longitud = empresa.Longitud,
                IdCategoria = empresa.IdCategoria,
            };

            _empresaDAL.Create(empresaDAL);
            return await _unitOfWork.SaveChangesAsync();

        }

        public async Task<int>Delete(int Id)
        {
            Empresa empresaEN = await _empresaDAL.GetById(Id);
            if (empresaEN.Id == Id)
            {
                _empresaDAL.Delete(empresaEN);
                return await _unitOfWork.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<List<EmpresaGetAllDTO>> GetAll()
        {
            List<Empresa> empresas = await _empresaDAL.GetAll();
            List<EmpresaGetAllDTO> list = new List<EmpresaGetAllDTO>();
            empresas.ForEach(s => list.Add(new EmpresaGetAllDTO
            {
                Id = s.Id,
                Nombre = s.Nombre,
            }));
            return list;
        }

        public async Task<EmpresaGetByIdDTO> GetById(int Id)
        {
            Empresa empresaEN = await _empresaDAL.GetById(Id);
            return new EmpresaGetByIdDTO()
            {
                Id = empresaEN.Id,
                Nombre = empresaEN.Nombre,

            };
        }

        public async Task<List<EmpresaSearchOutputDTO>> Search(EmpresaSearchInputDTO empresa)
        {
            List<Empresa> empresa = await _empresaDAL.Search(new Empresa { Id = empresa.Id, Nombre = empresa.Name });
            List<EmpresaSearchOutputDTO> list = new List<EmpresaSearchOutputDTO>();
            empresa.ForEach(s => list.Add(new EmpresaSearchOutputDTO
            {
                Id = s.Id,
                Nombre = s.Nombre
            })); ;
            return list;
        }

        public async Task<int> Update(EmpresaUpdateDTO empresa)
        {
            Empresa empresaEN = await _empresaDAL.GetById(empresa.Id);
            if (empresaEN.Id == empresa.Id)
            {
                empresaEN.Nombre = empresa.Nombre;
                _empresaDAL.Update(empresaEN);
                return await _unitOfWork.SaveChangesAsync();
            }
            else
                return 0;
        }
    }
}
