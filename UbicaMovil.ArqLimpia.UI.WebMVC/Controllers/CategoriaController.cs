using Microsoft.AspNetCore.Mvc;

using UbicaMovil.ArqLimpia.BL.DTOs.CategoriaDTOs;
using UbicaMovil.ArqLimpia.EN.Interfaces;
using UbicaMovil.ArqLimpia.BL.Interfaces;

namespace UbicaMovil.ArqLimpia.UI.WebMVC.Controllers
{
    public class CategoriaController : Controller
    {
        readonly ICategoriaBL _BL;

        public CategoriaController(ICategoriaBL BL)
        {
            _BL = BL;
        }

        public async Task<IActionResult> Index(CategoriaSearchInputDTO inputDTO)
        {
            var list = await _BL.Search(inputDTO);
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            CategoriaGetByIdDTO getByIdDTO = await _BL.GetById(id);
            return View(getByIdDTO);
        }

        public ActionResult Create()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaAddDTO AddDTO)
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
            CategoriaGetByIdDTO getByIdDTO = await _BL.GetById(id);
            var result = new CategoriaUpdateDTO()
            {
                Id = getByIdDTO.Id,
                Nombre = getByIdDTO.Nombre
            };
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoriaUpdateDTO updateDTO)
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
            CategoriaGetByIdDTO result = await _BL.GetById(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CategoriaGetByIdDTO getByIdDTO)
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
