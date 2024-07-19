using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Administrador
    {
        public int idAdministrador { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }

        public DateTime fecha_acceso { get; set; }
        public string correo { get; set; }

        public string contrasena { get; set; }

        public Administrador(int idAdministrador, string nombre, string apellido_paterno, string apellido_materno, DateTime fecha_acceso, string correo, string contrasena)
        {
            this.idAdministrador = idAdministrador;
            this.nombre = nombre;
            this.apellido_paterno = apellido_paterno;
            this.apellido_materno = apellido_materno;
            this.fecha_acceso = fecha_acceso;
            this.correo = correo;
            this.contrasena = contrasena;
        }
        public Administrador()
        {
        }


        public string iniciar(Administrador oAdministrador)
        {
            string rpta = "";
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ADMINISTRADOR WHERE correo = @usuario AND contrasena = @Contrasena", con);
                cmd.Parameters.AddWithValue("@Usuario", oAdministrador.correo);
                cmd.Parameters.AddWithValue("@Contrasena", oAdministrador.contrasena);
                con.Open();
                cmd.ExecuteNonQuery();

                int resultado = (int)cmd.ExecuteScalar();

                if (resultado > 0)
                {
                    rpta = "Bienvenido";
                }
                else
                {
                    rpta = "No ere bienvenido";
                }
                con.Close();

            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
