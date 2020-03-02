using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Universidad.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult Lista()
        {
            return View(Universidad.Models.Manager.Instance.Alumnos);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Universidad.Models.Alumno a)
        {
            Universidad.Models.Manager.Instance.AgregarAlumno(a);
            return View(a);
        }

        public ActionResult Eliminar(int? id)
        {
            var a = Universidad.Models.Manager.Instance.ObtenerEstudiante((int)id);
            return View(a);
        }
        [HttpPost]

        public ActionResult Eliminar(int id)
        {
            Universidad.Models.Manager.Instance.EliminarEstudiante(id);
            return RedirectToAction("Lista");
        }
        public ActionResult Actualizar(int? id)
        {
            var a = Universidad.Models.Manager.Instance.ObtenerEstudiante((int)id);
            return View(a);
        }

        [HttpPost]

        public ActionResult Actualizar(int id, Universidad.Models.Alumno a)
        {
            Universidad.Models.Manager.Instance.ActualizarEstudiante(id, a);
            return RedirectToAction("Lista");
        }

        public ActionResult Maestrias(int? id)
        {
            var a = Universidad.Models.Manager.Instance.ObtenerEstudiante((int)id);
            return View(a);
        }


        public ActionResult AgregarMaestrias(int? id)
        {
            var a = Universidad.Models.Manager.Instance.ObtenerEstudiante((int)id);

            return View(a);
        }

        [HttpPost]
        public ActionResult AgregarMaestrias(int idAlumno, int idMaestria)
        {
            var a = Universidad.Models.Manager.Instance.ObtenerEstudiante(idAlumno);
            var m = Universidad.Models.Manager.Instance.ObtenerMaestria(idMaestria);

            if (m != null)
            {
                if (!a.Maestrias.Contains(m))
                {
                    a.Maestrias.Add(m);
                    return RedirectToAction("Maestrias", new { id = idAlumno });
                }
                else
                {
                    ViewBag.error = $"El estudiante{a.Nombre} con el CURP {a.CURP} ya se encuentra cursando la maestria {a.Maestrias}";
                }
            }
            return View(a);
        }

        [HttpPost]
        public ActionResult EliminarMaestria(int idAlumno, int idMaestria)
        {
            var a = Universidad.Models.Manager.Instance.ObtenerEstudiante(idAlumno);
            var m = Universidad.Models.Manager.Instance.ObtenerMaestria(idMaestria);

            a.Maestrias.Remove(m);

            return RedirectToAction("Maestrias", new { id = idAlumno });
        }

    }
}