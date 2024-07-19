using capaPresentacion.Paginas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace capaPresentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b_inicio_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Content = new Inicio();

        }

        private void b_prestamos_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Content = new PrestamosHistorial();
        }

        private void b_libros_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Content = new Gestionar();
        }

        private void b_editarLibro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_prestarLibro_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Content = new EstudianteLibro();
        }

        private void b_registrar_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Content = new RegistrarAsistencia();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            framePrincipal.Content = new Inicio();

        }

        private void b_acceder_Click(object sender, RoutedEventArgs e)
        {
            framePrincipal.Content = new EvalFernandezSaldaña();
        }
    }
}
