using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universidad.Models
{
    public class Maestria
    {

        public int IDmaestria { get; set; }
        public string Nombre { get; set; }
        public int duracion { get; set; }

        private List<Profesor> docentes = new List<Profesor>();

        public List<Profesor> Docentes
        {
            get
            {
                if (docentes.Count != 0)
                {
                    for (int i = 0; i < docentes.Count; i++)
                    {
                        foreach (Profesor docente in Manager.Instance.Docentes)
                        {
                            if (docentes[i].IDempleado == docente.IDempleado)
                            {
                                docentes[i] = docente;
                            }
                        }
                    }
                }
                return docentes;
            }
        }

    }
}