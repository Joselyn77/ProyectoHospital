using appHospital.Data.Repository.IRepository;
using appHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace appHospital.Areas.admin.Controllers
{

    [Area("admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
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
            ViewBag.Roles = _contenedorTrabajo.Rol.GetAll(); // Obtener todos los roles de la base de datos
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Usuario.Add(usuario);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Usuario usuario = new Usuario();
            usuario = _contenedorTrabajo.Usuario.Get(id);
            if (usuario == null)
            {
                return NotFound();

            }
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Usuario.Update(usuario);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Usuario.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Usuario.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando usuario" });
            }
            _contenedorTrabajo.Usuario.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la usuario" });
        }
        #endregion
    }
}
