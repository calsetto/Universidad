using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Universidad.Controllers
{
    public class ProfesorController : Controller
    {
        public ActionResult Lista()
        {
            return View(Universidad.Models.Manager.Instance.Docentes);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ProfesorController d)
        {
            Universidad.Models.Manager.Instance.AgregarDocente(d);
            return View(d);
        }

        public ActionResult Eliminar(int? id)
        {
            var d = Universidad.Models.Manager.Instance.ObtenerDocente((int)id); //Se necesita castear el id a tipo INT.
            return View(d);
        }
        [HttpPost]

        public ActionResult Eliminar(int id)
        {
            Universidad.Models.Manager.Instance.EliminarDocente(id);
            return RedirectToAction("Lista");
        }
        public ActionResult Actualizar(int? id)
        {
            var d = Universidad.Models.Manager.Instance.ObtenerDocente((int)id);
            return View(d);
        }

        [HttpPost]

        public ActionResult Actualizar(int id, ProfesorController d)
        {
            Universidad.Models.Manager.Instance.ActualizarDocente(id, d);
            return RedirectToAction("Lista");
        }

        public ActionResult Maestrias(int? id)
        {
            var d = Universidad.Models.Manager.Instance.ObtenerDocente((int)id);
            return View(d);
        }


        public ActionResult AgregarMaestrias(int? id)
        {
            var d = Universidad.Models.Manager.Instance.ObtenerDocente((int)id);

            return View(d);
        }
        [HttpPost]
        public ActionResult AgregarMaestrias(int idDocente, int idMaestria)
        {
            var d = Universidad.Models.Manager.Instance.ObtenerDocente(idDocente);
            var m = Universidad.Models.Manager.Instance.ObtenerMaestria(idMaestria);

            if (d != null)
            {
                if (!d.Maestrias.Contains(m))
                {
                    m.Docentes.Add(d);
                    d.Maestrias.Add(m);
                    return RedirectToAction("Maestrias", new { id = idDocente });
                }
                else
                {
                    ViewBag.error = $"La maestria {m.Nombre} con el ID {m.IDmaestria} ya esta siendo impartida por {d.Nombre}";
                }
            }
            return View(m);
        }

       
    }
}