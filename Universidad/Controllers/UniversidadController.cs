using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class UniversidadController : Controller
    {

        public ActionResult Lista()
        {
            return View(Manager.Instance.Alumnos);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Alumno a)
        {
            Manager.Instance.AgregarAlumno(a);
            return View(a);
        }

        public ActionResult Eliminar(int? id)
        {
            var a = Manager.Instance.ObtenerEstudiante((int)id); //Se necesita castear el id a tipo INT.
            return View(a);
        }
        [HttpPost]

        public ActionResult Eliminar(int id)
        {
            Manager.Instance.EliminarEstudiante(id);
            return RedirectToAction("Lista");
        }
        public ActionResult Actualizar(int? id)
        {
            var a = Manager.Instance.ObtenerEstudiante((int)id);
            return View(a);
        }

        [HttpPost]

        public ActionResult Actualizar(int id, Alumno a)
        {
            Manager.Instance.ActualizarEstudiante(id, a);
            return RedirectToAction("Lista");
        }

        public ActionResult Maestrias(int? id)
        {
            var a = Manager.Instance.ObtenerEstudiante((int)id);
            return View(a);
        }


        public ActionResult AgregarMaestrias(int? id)
        {
            var a = Manager.Instance.ObtenerEstudiante((int)id);

            return View(a);
        }


        [HttpPost]
        public ActionResult AgregarMaestrias(int idAlumno, int idMaestria)
        {
            var a = Manager.Instance.ObtenerEstudiante(idAlumno);
            var m = Manager.Instance.ObtenerMaestria(idMaestria);

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
            var a = Manager.Instance.ObtenerEstudiante(idAlumno);
            var m = Manager.Instance.ObtenerMaestria(idMaestria);

            a.Maestrias.Remove(m);

            return RedirectToAction("Maestrias", new { id = idAlumno });
        }


    }
}