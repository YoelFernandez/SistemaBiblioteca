using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NegInsertar
    {
        public static string insertar(int idEstudiante)
        {
            Registros registro = new Registros();
            registro.idEstudiante = idEstudiante;
            return registro.insertar(registro);
        }
    }
}
