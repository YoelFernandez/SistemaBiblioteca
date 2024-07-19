using CapaDatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NegPrestamos
    {
        public static DataTable ObtenerPrestamosAll(string dato)
        {
            return new Prestamos().ObtenerPrestamosAll(dato);
        }

        public static string actualizar(int idPrestamo)
        {
            Prestamos prestamo = new Prestamos();
            prestamo.idPrestamo = idPrestamo;
            return prestamo.actualizar(prestamo);
        }

        public static string Prestar(ObservableCollection<Prestamos2> listaPrestamos)
        {
            return new Prestamos ().prestar(listaPrestamos);
        }
    }
}
