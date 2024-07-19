using CapaNegocios;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Gestionar.xaml
    /// </summary>
    public partial class Gestionar : Page
    {
        public Gestionar()
        {
            InitializeComponent();
            // tb_buscarLibroCodigo.TextChanged += tb_buscarLibroCodigo_TextChanged;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dg_libros.AutoGenerateColumns = true;
            this.dg_libros.DataContext = NegLibros.ObtenerLibrosAll();
        }

        private void b_editarLibro_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (dg_libros.SelectedItem != null)
                {
                    DataRowView view = (DataRowView)dg_libros.SelectedItem;
                    AgregarEditarLibro agregarEditarLibro = new AgregarEditarLibro();
                    agregarEditarLibro.tb_guardarId.Text = view.Row.ItemArray[0].ToString();
                    agregarEditarLibro.tb_nombreLibro.Text = view.Row.ItemArray[1].ToString();
                    agregarEditarLibro.tb_editorial.Text = view.Row.ItemArray[2].ToString();
                    agregarEditarLibro.tb_cantidad.Text = view.Row.ItemArray[5].ToString();
                    agregarEditarLibro.tb_categoria.Text = view.Row.ItemArray[6].ToString();
                    agregarEditarLibro.tb_nombreAutor.Text = view.Row.ItemArray[7].ToString();
                    agregarEditarLibro.tb_apellidoP.Text = view.Row.ItemArray[8].ToString();
                    agregarEditarLibro.tb_apellidoM.Text = view.Row.ItemArray[1].ToString();

                    NavigationService?.Navigate(agregarEditarLibro);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dg_libros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_libros.SelectedItem != null)
            {
                DataRowView view = (DataRowView)dg_libros.SelectedItem;
                tb_buscarLibroCodigo.Text = view.Row.ItemArray[0].ToString();
            }
        }

        private void b_nuevoLibro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AgregarEditarLibro());
        }

        private void b_eliminarLibro_Click(object sender, RoutedEventArgs e)
        {
            String rpta = "";
            rpta += NegLibros.eliminar(Convert.ToInt32(tb_buscarLibroCodigo.Text));
            MessageBox.Show(rpta, "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            this.dg_libros.DataContext = NegLibros.ObtenerLibrosAll();
        }

        private void tb_buscarLibroCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {

            //// Obtener el texto ingresado en el tb_codigoEstudiante
            //string searchText = tb_buscarLibroCodigo.Text.Trim().ToLower();

            //// Verificar si el texto no está vacío
            //if (!string.IsNullOrEmpty(searchText))
            //{
            //    // Filtrar los prestamos que coinciden con el código de estudiante ingresado
            //    DataTable filteredTable = new DataTable();
            //    filteredTable = ((DataTable)dg_libros.DataContext).Clone(); // Clonar la estructura de la tabla original

            //    foreach (DataRow row in ((DataTable)dg_libros.DataContext).Rows)
            //    {
            //        // Obtener el valor de la celda en la columna 3
            //        string cellValue = row.ItemArray[0].ToString().ToLower(); // Columna 2 (índice 1)

            //        // Verificar si el valor de la celda contiene el texto ingresado
            //        if (cellValue.Contains(searchText))
            //        {
            //            // Agregar la fila filtrada a la tabla
            //            filteredTable.ImportRow(row);
            //        }
            //    }

            //    // Asignar la tabla filtrada como contexto de la DataGrid
            //    dg_libros.DataContext = filteredTable;
            //}
            //else
            //{
            //    // Si el texto está vacío, restaurar todos los datos
            //    this.dg_libros.DataContext = NegPrestamos.ObtenerPrestamosAll("Todos");
            //}

        }
    }
}
