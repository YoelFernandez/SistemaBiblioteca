using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public class Libro
    {
        public int ID_libro { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Estado_Libro { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }
        public string NombreAut { get; set; }
        public string ApellidoMat { get; set; }
        public string ApellidoPat { get; set; }

        public Libro()
        {
        }


        public DataTable ObtenerLibrosAll()
        {
            string rpta = "";
            DataTable dtEstudiante = new DataTable("Libros");
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = "sp_ListarLibros"; // Procedimiento almacenado
                sqlCmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtEstudiante);
                con.Close();
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                dtEstudiante = null;
            }
            return dtEstudiante;
        }

        public Libro ObtnerParaEditarLibro(Libro oLibro)
        {
            Libro nuevo = new Libro();
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = "sp_ListarLibros"; // Procedimiento almacenado
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Tipo", oLibro.ID_libro);

                SqlDataReader reader = sqlCmd.ExecuteReader();

                // Verificamos si hay filas en el SqlDataReader
                if (reader.HasRows)
                {
                    // Iteramos sobre cada fila
                    while (reader.Read())
                    {
                        // Aquí debes asignar los valores del SqlDataReader a las propiedades del objeto Libro
                        nuevo.ID_libro = Convert.ToInt32(reader["CodigoLibro"]);
                        nuevo.Titulo = reader["titulo"].ToString();
                        nuevo.Editorial = reader["editorial"].ToString();
                        nuevo.Estado_Libro = reader["Estado"].ToString();
                        nuevo.Cantidad = Convert.ToInt32(reader["cantidad"]);
                        nuevo.Categoria = reader["CodigoCategoria"].ToString();
                        nuevo.NombreAut = reader["NombreAutor"].ToString();
                        nuevo.ApellidoPat = reader["ApellidoPaternoAutor"].ToString();
                        nuevo.ApellidoMat = reader["ApellidoMaternoAutor"].ToString();
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                String rpta = ex.Message;
            }
            return nuevo;
        }



        /// Editar libro
        /// 
        public string acutializarLibro(Libro libro)
        {
            string rpta = "";
            string query = "UPDATE libro SET titulo = @Titulo, " +
                "editorial = @Editorial, cantidad = @Cantidad, " +
                "categoria = @Id_categoria , nombre_autor = @Nombre_autor, " +
                "apellido_paterno = @Apellido_paterno_autor," +
                " apellido_materno = @Apellido_materno_autor" +
                " WHERE id_libro = @Id_libro";

            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    conexion.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, conexion))
                    {
                        // Agregar parámetro para el nombre de la categoría
                        sqlCommand.Parameters.AddWithValue("@Titulo", libro.Titulo);
                        sqlCommand.Parameters.AddWithValue("@Editorial", libro.Editorial);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                        sqlCommand.Parameters.AddWithValue("@Id_categoria", libro.Categoria);
                        sqlCommand.Parameters.AddWithValue("@Nombre_autor", libro.NombreAut);
                        sqlCommand.Parameters.AddWithValue("@Apellido_paterno_autor", libro.ApellidoMat);
                        sqlCommand.Parameters.AddWithValue("@Apellido_materno_autor", libro.ApellidoPat);
                        sqlCommand.Parameters.AddWithValue("@Id_libro", libro.ID_libro);

                        int filasAfectadas = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            rpta = "Libros Actualizados";

                        }
                        else
                        {
                            rpta = "Libros NO Actualizados";
                        }
                    }

                    return rpta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, no se pudo editar el libro, comunicate con el administrador " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return rpta = "";
            }
        }

        public string insertarLibro(Libro libro)
        {
            string rpta = "NNNN";
            try
            {
                using (SqlConnection conexion = Conexion.conectar())
                {
                    string query = "INSERT INTO LIBRO (titulo, editorial, fecha_carga, estado_libro, cantidad, nombre_autor, apellido_paterno, apellido_materno, categoria) " +
                                   "VALUES (@Titulo, @Editorial, GETDATE(), 'Nuevo', @Cantidad, @Nombre_autor, @Apellido_paterno, @Apellido_materno, @Categoria)";
                    SqlCommand sqlCommand = new SqlCommand(query, conexion);

                    // Agregar parámetros
                    sqlCommand.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    sqlCommand.Parameters.AddWithValue("@Editorial", libro.Editorial);
                    sqlCommand.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                    sqlCommand.Parameters.AddWithValue("@Nombre_autor", libro.NombreAut);
                    sqlCommand.Parameters.AddWithValue("@Apellido_paterno", libro.ApellidoPat);
                    sqlCommand.Parameters.AddWithValue("@Apellido_materno", libro.ApellidoMat);
                    sqlCommand.Parameters.AddWithValue("@Categoria", libro.Categoria);

                    conexion.Open();

                    int filasAfectadas = sqlCommand.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        return rpta = "Se insertó un nuevo Libro";
                    }
                    else
                    {
                        return rpta = "No se insertó el libro";
                    }
                }
            }
            catch (Exception ex)
            {
                return rpta = "Error al insertar el libro: " + ex.Message;
            }
        }

        public string eliminarLibro(Libro libro)
        {
            string rpta = "";

            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand("DELETE FROM LIBRO WHERE id_libro=" + libro.ID_libro, con);
                con.Open();
                sqlCmd.ExecuteNonQuery();

                con.Close();
                rpta = "libro eliminado";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
