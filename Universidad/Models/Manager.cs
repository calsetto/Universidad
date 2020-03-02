﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universidad.Models
{
    public class Manager
    {

        public static readonly Manager Instance = new Manager();
        private Manager() { }

        public List<Alumno> Alumnos { get; } = new List<Alumno>();
        public List<Profesor> Docentes { get; } = new List<Profesor>();
        public List<Maestria> Maestrias { get; } = new List<Maestria>();
        public List<Universidad> Universidades { get; } = new List<Universidad>();


        public void AgregarMaestria(Maestria maestria)
        {
            var id = Maestrias.Count > 0 ? Maestrias.Max(s => s.IDmaestria) + 1 : 0;
            maestria.IDmaestria = id;
            Maestrias.Add(maestria);
        }

        public Maestria ObtenerMaestria(int id)
        {
            return Maestrias.FirstOrDefault(m => m.IDmaestria == id);
        }

        public void ActualizarMaestria(int id, Maestria maestria)
        {
            int index = Maestrias.FindIndex(s => s.IDmaestria == id);
            maestria.IDmaestria = id;
            Maestrias[index] = maestria;
        }

        public void EliminarMaestria(int id)
        {
            Maestrias.Remove(ObtenerMaestria(id));
        }


        public void AgregarAlumno(Alumno alumno)
        {
            var id = Alumnos.Count > 0 ? Alumnos.Max(s => s.Boleta) + 1 : 0;
            alumno.Boleta = id;
            Alumnos.Add(alumno);
        }

        public Alumno ObtenerEstudiante(int id)
        {
            return Alumnos.FirstOrDefault(m => m.Boleta == id);
        }


        public void ActualizarEstudiante(int index, Alumno alumno)
        {
            int id = Alumnos.FindIndex(s => s.Boleta == index);
            alumno.Boleta = id;
            Alumnos[id] = alumno;
        }

        public void EliminarEstudiante(int id)
        {
            Alumnos.Remove(ObtenerEstudiante(id));
        }


        public void AgregarDocente(Profesor docente)
        {
            var id = Docentes.Count > 0 ? Docentes.Max(s => s.IDempleado) + 1 : 0;
            docente.IDempleado = id;
            Docentes.Add(docente);
        }

        public Profesor ObtenerDocente(int id)
        {
            return Docentes.FirstOrDefault(m => m.IDempleado == id);
        }

        public void ActualizarDocente(int index, Profesor docente)
        {
            int id = Docentes.FindIndex(s => s.IDempleado == index);
            docente.IDempleado = id;
            Docentes[id] = docente;
        }

        public void EliminarDocente(int id)
        {
            Docentes.Remove(ObtenerDocente(id));
        }


        public void AgregarUniversidad(Universidad uni)
        {
            var id = Universidades.Count > 0 ? Universidades.Max(s => s.IDuniversidad) + 1 : 0;
            uni.IDuniversidad = id;
            Universidades.Add(uni);
        }

        public Universidad ObtenerUniversidad(int id)
        {
            return Universidades.FirstOrDefault(m => m.IDuniversidad == id);
        }

        public void ActualizarUniversidad(int index, Universidad uni)
        {
            int id = Universidades.FindIndex(s => s.IDuniversidad == index);
            uni.IDuniversidad = id;
            Universidades[id] = uni;
        }

        public void EliminarUniversidad(int id)
        {
            Universidades.Remove(ObtenerUniversidad(id));
        }


        public bool DocenteMaestriaDepen(int id)
        {
            foreach (var item in Maestrias)
            {
                foreach (var docente in item.Docentes)
                {
                    if (docente.IDempleado == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MaestriaDocenteDepen(int id)
        {
            foreach (var item in Docentes)
            {
                foreach (var maestria in item.Maestrias)
                {
                    if (maestria.IDmaestria == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UniversidadDocenteDepen(int id)
        {
            foreach (var item in Universidades)
            {
                foreach (var docente in Docentes)
                {
                    if (docente.IDempleado == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MaestriaAlumnoDepen(int id)
        {
            foreach (var item in Alumnos)
            {
                foreach (var maestria in item.Maestrias)
                {
                    if (maestria.IDmaestria == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool DocenteUniversidadDepen(int id)
        {
            foreach (var item in Docentes)
            {
                foreach (var universidad in item.Universidades)
                {
                    if (universidad.IDuniversidad == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}