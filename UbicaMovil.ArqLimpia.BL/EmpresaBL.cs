using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UbicaMovil.ArqLimpia.BL.Interfaces;
using UbicaMovil.ArqLimpia.EN;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using UbicaMovil.ArqLimpia.BL.DTOs.EmpresaDTOs;

namespace UbicaMovil.ArqLimpia.BL
{
    public class EmpresaBL : IEmpresaBL
    {
        readonly IEmpresa _empresaDAL;
        readonly IUnitOfWork _unitWork;

        public EmpresaBL(IEmpresa empresaDAL, IUnitOfWork unitWork)
        {
            _empresaDAL = empresaDAL;
            _unitWork = unitWork;
        }

        public async Task<int> Create(EmpresaAddDTO pUser)
        {
            Empresa empresaDAL = new Empresa()
            {
                Nombre = pUser.Nombre,
                Direccion = pUser.Direccion,
                Telefono = pUser.Telefono,
                HorarioEntrada = pUser.HorarioEntrada,
                HorarioSalida = pUser.HorarioSalida,
                Latitud = pUser.Latitud,
                Longitud = pUser.Longitud,
                IdCategoria = pUser.IdCategoria
            };
            _empresaDAL.Create(empresaDAL);
            return await _unitWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            Empresa empresaEN = await _empresaDAL.GetById(Id);
            if (empresaEN.Id == Id)
            {
                _empresaDAL.Delete(empresaEN);
                return await _unitWork.SaveChangesAsync();
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
                Direccion = s.Direccion,
                Telefono = s.Telefono,
                HorarioEntrada = s.HorarioEntrada,
                HorarioSalida = s.HorarioSalida,
                Latitud = s.Latitud,
                Longitud = s.Longitud,
                IdCategoria = s.IdCategoria
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
                Direccion = empresaEN.Direccion,
                Telefono = empresaEN.Telefono,
                HorarioEntrada = empresaEN.HorarioEntrada,
                HorarioSalida = empresaEN.HorarioSalida,
                Latitud = empresaEN.Latitud,
                Longitud = empresaEN.Longitud,
                IdCategoria = empresaEN.IdCategoria

            };
        }

        public async Task<List<EmpresaSearchOutputDTO>> Search(EmpresaSearchInputDTO pUser)
        {
            List<Empresa> empresas = await _empresaDAL.Search(new Empresa { Id = pUser.Id, Nombre = pUser.Nombre });
            List<EmpresaSearchOutputDTO> list = new List<EmpresaSearchOutputDTO>();
            empresas.ForEach(s => list.Add(new EmpresaSearchOutputDTO
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Direccion = s.Direccion,
                Telefono = s.Telefono,
                HorarioEntrada = s.HorarioEntrada,
                HorarioSalida = s.HorarioSalida,
                Latitud = s.Latitud,
                Longitud = s.Longitud,
                IdCategoria = s.IdCategoria
            }));
            return list;
        }

        public async Task<int> Update(EmpresaUpdateDTO pUser)
        {
            Empresa empresaEN = await _empresaDAL.GetById(pUser.Id);
            if (empresaEN.Id == pUser.Id)
            {
                empresaEN.Nombre = pUser.Nombre;
                empresaEN.Direccion = pUser.Direccion;
                empresaEN.Telefono = pUser.Telefono;
                empresaEN.HorarioEntrada = pUser.HorarioEntrada;
                empresaEN.HorarioSalida = pUser.HorarioSalida;
                empresaEN.Latitud = pUser.Latitud;
                empresaEN.Longitud = pUser.Longitud;
                empresaEN.IdCategoria = pUser.IdCategoria;
                _empresaDAL.Update(empresaEN);
                return await _unitWork.SaveChangesAsync();
            }
            else
                return 0;
        }
    }
}
