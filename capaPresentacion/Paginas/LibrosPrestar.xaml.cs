using CapaDatos;
using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Lógica de interacción para LibrosPrestar.xaml
    /// </summary>
    public partial class LibrosPrestar : Page
    {

        private ObservableCollection<Prestamos2> prestamosSeleccionados;

        public LibrosPrestar()
        {
            InitializeComponent();
            prestamosSeleccionados = new ObservableCollection<Prestamos2>();
        }

        private void dg_libros_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dg_libros.SelectedItem;
            int idLibro = (int)selectedRow["CodigoLibro"];

            Prestamos2 libroSeleccionado = new Prestamos2();
            libroSeleccionado.idAdministrador = 1;
            libroSeleccionado.estado = "POR DEVOLVER";
            libroSeleccionado.idEstudiante = tb_codigoEstudiante1.Text;
            libroSeleccionado.idLibro = idLibro;
            libroSeleccionado.fechaPrestamo = DateTime.Now;

            prestamosSeleccionados.Add(libroSeleccionado);
            dg_prestamos.ItemsSource = prestamosSeleccionados;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dg_libros.AutoGenerateColumns = true;
            this.dg_libros.DataContext = NegLibros.ObtenerLibrosAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string rept = "";
            rept += NegPrestamos.Prestar(prestamosSeleccionados);
            MessageBox.Show(rept);
            rept = "";
            NavigationService?.Navigate(new EstudianteLibro());


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            prestamosSeleccionados.Clear();
            dg_prestamos.ItemsSource = null;

        }
    }
}
