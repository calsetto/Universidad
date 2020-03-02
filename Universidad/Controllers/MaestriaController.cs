using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Universidad.Controllers
{
    public class MaestriaController : Controller
    {
        public ActionResult Lista()
        {
            return View(Universidad.Models.Manager.Instance.Maestrias);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Universidad.Models.Maestria m)
        {
            if (ModelState.IsValid)
            {
                Universidad.Models.Manager.Instance.AgregarMaestria(m);
                return RedirectToAction("List");
            }
            return View(m);
        }

        public ActionResult Eliminar(int? id)
        {
            var maestria = Universidad.Models.Manager.Instance.ObtenerMaestria((int)id);
            return View(maestria);
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            Universidad.Models.Manager.Instance.EliminarMaestria(id);
            return RedirectToAction("List");
        }

        public ActionResult Actualizar(int? id)
        {
            var m = Universidad.Models.Manager.Instance.ObtenerMaestria((int)id);

            return View(m);
        }

        [HttpPost]
        public ActionResult Actualizar(Universidad.Models.Maestria n, int id)
        {

            Universidad.Models.Manager.Instance.ActualizarMaestria(id, n);
            return RedirectToAction("List");
        }

        public ActionResult Docentes(int? id)
        {
            var m = Universidad.Models.Manager.Instance.ObtenerMaestria((int)id);

            return View(m);
        }

        public ActionResult AgregarDocente(int? id)
        {

            var maestria = Universidad.Models.Manager.Instance.ObtenerMaestria((int)id);
            return View(maestria);
        }

        
    }
}