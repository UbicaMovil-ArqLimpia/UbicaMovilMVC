using Microsoft.AspNetCore.Mvc;

using UbicaMovil.ArqLimpia.BL.DTOs.EmpresaDTOs;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using UbicaMovil.ArqLimpia.BL.Interfaces;

namespace UbicaMovil.ArqLimpia.UI.WebMVC.Controllers
{
    public class EmpresaController : Controller
    {
        readonly IEmpresaBL _BL;

        public EmpresaController(IEmpresaBL BL)
        {
            _BL = BL;
        }

        public async Task<IActionResult> Index(EmpresaSearchInputDTO input)
        {
            return View(await _BL.Search(input));
        }

        public async Task<IActionResult> Details(int id)
        {
            EmpresaGetByIdDTO getByIdDTO = await _BL.GetById(id);
            return View(getByIdDTO);
        }

        public ActionResult Create()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpresaAddDTO AddDTO)
        {
            try
            {
                int result = await _BL.Create(AddDTO);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE REGISTRO";
                    return View(AddDTO);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            EmpresaGetByIdDTO getByIdDTO = await _BL.GetById(id);
            var result = new EmpresaUpdateDTO()
            {
                Id = getByIdDTO.Id,
                Nombre = getByIdDTO.Nombre,
                Direccion = getByIdDTO.Direccion,
                Telefono = getByIdDTO.Telefono,
                HorarioEntrada = getByIdDTO.HorarioEntrada,
                HorarioSalida = getByIdDTO.HorarioSalida,
                Latitud = getByIdDTO.Latitud,
                Longitud = getByIdDTO.Longitud,
                IdCategoria = getByIdDTO.IdCategoria
            };
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmpresaUpdateDTO updateDTO)
        {
            try
            {
                int result = await _BL.Update(updateDTO);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE MODIFICO";
                    return View(updateDTO);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            EmpresaGetByIdDTO result = await _BL.GetById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, EmpresaGetByIdDTO getByIdDTO)
        {
            try
            {
                int result = await _BL.Delete(id);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE ELIMINO";
                    return View(getByIdDTO);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
