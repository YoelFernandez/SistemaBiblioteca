using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Categoria()
        {
        }

        public Categoria(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Categoria(string nombre)
        {
            this.nombre = nombre;
        }

        public static List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                using (SqlConnection con = Conexion.conectar())
                {
                    SqlCommand sqlCmd = new SqlCommand("SELECT nombre FROM CATEGORIA ORDER BY id_categoria", con);
                    con.Open();
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria();
                        categoria.nombre = reader["nombre"].ToString();
                        categorias.Add(categoria);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return categorias;
        }
        //CODIGO CON LA BASE DE DATOS
        public List<string> listarCategorias()
        {
            string query = "SELECT * FROM categoria";


            List<string> categorias = new List<string>();
            SqlConnection conexion = Conexion.conectar();
            conexion.Open();

            using (SqlCommand sqlCommand = new SqlCommand(query, conexion))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        string nombreCategoria = sqlDataReader.GetString(1);
                        categorias.Add(nombreCategoria);
                    }
                }
            }
            conexion.Close();
            return categorias;
        }


        //Listar las categorias  para poder crear un nuevo libro
        public List<Categoria> listarCategoriasLibros()
        {
            string query = "SELECT * FROM categoria";


            List<Categoria> categorias = new List<Categoria>();
            SqlConnection conexion = Conexion.conectar();
            conexion.Open();

            using (SqlCommand sqlCommand = new SqlCommand(query, conexion))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        int id_categoria = sqlDataReader.GetInt32(0);
                        string nombreCategoria = sqlDataReader.GetString(1);
                        categorias.Add(new Categoria(id_categoria, nombreCategoria));
                    }
                }
            }
            conexion.Close();
            return categorias;
        }
        //Crear nueva categoria
        public bool crearNuevaCategoria(Categoria categoria)
        {
            string query = "INSERT INTO categoria (nombre) VALUES (@Nombre)";

            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    conexion.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, conexion))
                    {
                        // Agregar parámetro para el nombre de la categoría
                        sqlCommand.Parameters.AddWithValue("@Nombre", categoria.nombre);

                        // Ejecutar la consulta
                        int filasAfectadas = sqlCommand.ExecuteNonQuery();

                        // Verificar si se insertó correctamente
                        if (filasAfectadas > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente, por ejemplo, mostrar un mensaje de error
                MessageBox.Show("Error al crear nueva categoría: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}