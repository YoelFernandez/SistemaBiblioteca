using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NegEvaluacion
    {
        public static DataTable ObtenerPrestamosIntervalo(DateTime fechaIni, DateTime fechaFIn)
        {
           
            return new Prestamos().ObtenerPrestamosIntervalo(fechaIni, fechaFIn);
            
        }
    }
}
