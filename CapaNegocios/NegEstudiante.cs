using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class NegEstudiante
    {
        public static DataTable ObtenerEstudiantes()
        {
            return new Estudiante().ObtenerEstudiantes();
        }

        public static DataTable ObtenerEstudiantesComplet()
        {
            return new Estudiante().ObtenerEstudiantesComplet();
        }

        public static DataTable ObtenerEstudiantesComplet2()
        {
            return new Estudiante().ObtenerEstudiantesComplet2();
        }


        public static string anadirImagenUsuario(string id_estudiante, byte[] data)
        {
            Estudiante open = new Estudiante();
            open.id = id_estudiante;
            open.Imagen = data;
            return new Estudiante().anadirImagenUsuario(open);
        }
    }
}
