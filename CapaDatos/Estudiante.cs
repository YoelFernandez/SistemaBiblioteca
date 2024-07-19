using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class Estudiante
    {

        public string id { get; set; }
        public string nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string telefono { get; set; }
        public byte[] Imagen { get; set; }

        public Estudiante(string id, string nombre, string apPaterno, string apMaterno, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            ApPaterno = apPaterno;
            ApMaterno = apMaterno;
            this.telefono = telefono;
        }

        public Estudiante()
        {
        }

        public DataTable ObtenerEstudiantes()
        {
            string rpta = "";
            DataTable dtEstudiante = new DataTable("Estudiantes");
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = "sp_Estudiantes_all"; // Procedimiento almacenado
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


        public DataTable ObtenerEstudiantesComplet()
        {
            string rpta = "";
            DataTable dtEstudiante = new DataTable("Estudiantes");
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = "sp_Estudiante_all"; // Procedimiento almacenado
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

        public string anadirImagenUsuario(Estudiante oEstudiante)
        {
            string rpta = "";
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand("UPDATE ESTUDIANTE SET IMAGEN = @IMAGEN WHERE id_estudiante =" + oEstudiante.id, con);
                cmd.Parameters.AddWithValue("@IMAGEN", oEstudiante.Imagen);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                rpta = "Imagen actualizada (CORRECTO)";
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }


















        public DataTable ObtenerEstudiantesComplet2()
        {
            string rpta = "";
            DataTable dtEstudiante = new DataTable("Estudiantes");
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = "sp_Estudiante_all2"; // Procedimiento almacenado
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
    }
}
