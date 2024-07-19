using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NegAdministrador
    {
        public static string login(string correo, string contrasena)
        {
            Administrador administrador = new Administrador();
            administrador.correo = correo;
            administrador.contrasena = contrasena;

            return administrador.iniciar(administrador);
        }
    }
}
