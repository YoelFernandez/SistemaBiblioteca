using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class Prestamos2
    {
        public int idAdministrador { get; set; }
        public string estado { get; set; }
        public string idEstudiante { get; set; }
        public int idLibro { get; set; }
        public DateTime fechaPrestamo { get; set; }

        public Prestamos2()
        {
        }
    }
}
