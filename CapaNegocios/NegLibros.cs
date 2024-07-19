using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NegLibros
    {
        public static DataTable ObtenerLibrosAll()
        {
            return new Libro().ObtenerLibrosAll();
        }

        public static Libro ObtenerlibroEditar(int idLibro)
        {
            Libro libro = new Libro();
            libro.ID_libro = idLibro;
            return libro.ObtnerParaEditarLibro(libro);
        }

        public static string actualizarLibros(int id_libro, string titulo, string editorial, int cantidad, string categoria, string nombre_autor, string apellido_paterno_autor, string apellido_materno_autor)
        {
            Libro libro = new Libro();

            libro.Titulo = titulo;
            libro.Editorial = editorial;
            libro.Cantidad = cantidad;
            libro.Categoria = categoria;
            libro.NombreAut = nombre_autor;
            libro.ApellidoPat = apellido_paterno_autor;
            libro.ApellidoMat = apellido_materno_autor;
            libro.ID_libro = id_libro;

            string rpta = libro.acutializarLibro(libro);

            return rpta;
        }



        public static string guardarLibro(string titulo, string editorial, int cantidad, string nombre_autor, string apellido_paterno_autor, string apellido_materno_autor, string categoria)
        {
            Libro libro = new Libro();
            libro.Titulo = titulo;
            libro.Editorial = editorial;
            libro.Cantidad = cantidad;
            libro.Categoria = categoria;
            libro.NombreAut = nombre_autor;
            libro.ApellidoPat = apellido_paterno_autor;
            libro.ApellidoMat = apellido_materno_autor;

            string rpta = libro.insertarLibro(libro);

            return rpta;
        }

        public static string eliminar(int idLibro)
        {

            Libro eliminar = new Libro();
            eliminar.ID_libro = idLibro;
            return eliminar.eliminarLibro(eliminar);


        }

    }
}
