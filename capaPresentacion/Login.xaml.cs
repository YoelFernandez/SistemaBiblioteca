using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace capaPresentacion
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rpta = NegAdministrador.login(tb_correo.Text.Trim().ToUpper(), p_contrasena.Password);
                // MessageBox.Show(rpta, "Seguridad", MessageBoxButton.OK, MessageBoxImage.Information);

                if (rpta == "Bienvenido")
                {
                    MainWindow abir = new MainWindow();
                    abir.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
