using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CapaDatos
{
    public class Prestamos
    {
        public int idPrestamo { get; set; }
        public int idAdministrador { get; set; }
        public string estado { get; set; }
        public string idEstudiante { get; set; }
        public int idLibro { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }



        public Prestamos()
        {

        }

        public DataTable ObtenerPrestamosAll(string dato)
        {
            string rpta = "";
            DataTable dtEstudiante = new DataTable("Prestamos");
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand("sp_Prestamos", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Tipo", dato);
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


        public string actualizar(Prestamos oPrestamos)
        {
            string rpta = "";
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand("UPDATE PRESTAMO SET fecha_devolucion = getdate(), estado = 'DEVUELTO' WHERE id_estudiante =" + oPrestamos.idPrestamo, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                rpta = "Prestamo actualizado (Libro Debuelto";
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }

        public string prestar(ObservableCollection<Prestamos2> listaPrestamos)
        {
            string rpta = "";
            try
            {
                SqlConnection con = Conexion.conectar();
                con.Open();
                foreach (Prestamos2 oPrestamo in listaPrestamos)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO PRESTAMO (estado, id_estudiante, id_libro, fecha_prestamo, id_administrador)VALUES (@estado, @id_estudiante, @id_libro, Getdate(), @id_administrador)", con);
                    cmd.Parameters.AddWithValue("@estado", oPrestamo.estado);
                    cmd.Parameters.AddWithValue("@id_estudiante", oPrestamo.idEstudiante);
                    cmd.Parameters.AddWithValue("@id_libro", oPrestamo.idLibro);
                    //cmd.Parameters.AddWithValue("@fecha_devolucion", oPrestamo.FechaDevolucion);
                    cmd.Parameters.AddWithValue("@id_administrador", oPrestamo.idAdministrador);
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                rpta = "Se han realizado los préstamos correctamente";
            }
            catch (Exception ex)
            {
                rpta = "Error al realizar los préstamos: " + ex.Message;
            }
            return rpta;
        }


        public DataTable ObtenerPrestamosIntervalo(DateTime fechaIni, DateTime fechaFin)
        {
            string rpta = "";
            DataTable dtEstudiante = new DataTable("Prestamos");
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand sqlCmd = new SqlCommand("sp_intervalos", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FechaInicial", fechaIni);
                sqlCmd.Parameters.AddWithValue("@FechaFinal", fechaFin);
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
