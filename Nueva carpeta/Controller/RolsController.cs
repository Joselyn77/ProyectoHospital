using appHospital.Data.Repository.IRepository;
using appHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace appHospital.Areas.admin.Controllers
{
    [Area("admin")]
    public class RolsController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public RolsController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Rol.Add(rol);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(rol);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Rol rol = new Rol();
            rol = _contenedorTrabajo.Rol.Get(id);
            if (rol == null)
            {
                return NotFound();

            }
            return View(rol);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rol rol)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Rol.Update(rol);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Rol.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Rol.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando rol" });
            }
            _contenedorTrabajo.Rol.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la rol" });
        }
        #endregion
    }
}
