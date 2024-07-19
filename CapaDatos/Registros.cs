using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Registros
    {

        public int idRegistro { get; set; }
        public int idEstudiante { get; set; }
        public int idAdministrador { get; set; }
        public decimal Precio { get; set; }
        public DateTime fecha { get; set; }


        public String insertar(Registros oRegistro)
        {
            String rpta = "";
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand("INSERT INTO REGISTRO (id_estudiante, id_administrador) VALUES(@IdEstudiante, '1')", con);
                cmd.Parameters.AddWithValue("@IdEstudiante", oRegistro.idEstudiante);
                // cmd.Parameters.AddWithValue("@IdAdministrador", oRegistro.idAdministrador);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                rpta = "Alumno registrado";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}