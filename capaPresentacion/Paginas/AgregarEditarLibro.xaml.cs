using CapaNegocios;
using CapaDatos;
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


namespace capaPresentacion.Paginas
{
    /// <summary>
    /// Lógica de interacción para AgregarEditarLibro.xaml
    /// </summary>
    public partial class AgregarEditarLibro : Page
    {

        public AgregarEditarLibro()
        {
            InitializeComponent();
            // Aquí puedes usar NombreLibro para establecer el texto del TextBox

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }



        private void b_guardar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string nombreLibro = tb_nombreLibro.Text;
                string editorial = tb_editorial.Text;
                int cantidad = Convert.ToInt32(tb_cantidad.Text);
                string Categoria = tb_categoria.Text;
                string nombreAutor = tb_nombreAutor.Text;
                string apellidoP = tb_apellidoP.Text;
                string apellidoM = tb_apellidoM.Text;

                string rpta = "";



                if (string.IsNullOrEmpty(tb_guardarId.Text))
                {
                    rpta = NegLibros.guardarLibro(nombreLibro, editorial, cantidad, nombreAutor, apellidoP, apellidoM, Categoria);
                    MessageBox.Show(rpta, "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    int id = Convert.ToInt32(tb_guardarId.Text);
                    rpta = NegLibros.actualizarLibros(id, nombreLibro, editorial, cantidad, Categoria, nombreAutor, apellidoP, apellidoM);
                    MessageBox.Show(rpta, "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                NavigationService?.Navigate(new Gestionar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}