using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {

        public static string conex = "Data Source=.;Initial Catalog=sistemaBiblioteca;Integrated Security=True";
        public static SqlConnection conectar()
        {
            return new SqlConnection(conex);
        }
    }
}
