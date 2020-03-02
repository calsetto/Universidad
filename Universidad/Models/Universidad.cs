using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universidad.Models
{
    public class Universidad
    {

        public int IDuniversidad { get; set; }
        public string Nombre { get; set; }

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