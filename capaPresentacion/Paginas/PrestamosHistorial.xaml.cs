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
    /// Lógica de interacción para PrestamosHistorial.xaml
    /// </summary>
    public partial class PrestamosHistorial : Page
    {
        public PrestamosHistorial()
        {
            InitializeComponent();
            tb_codigoEstudiante.TextChanged += tb_codigoEstudiante_TextChanged;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dg_prestamos.AutoGenerateColumns = true;
            this.dg_prestamos.DataContext = NegPrestamos.ObtenerPrestamosAll("Todos");
        }

        private void dg_prestamos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (dg_prestamos.SelectedItem != null)
            {
                DataRowView view = (DataRowView)dg_prestamos.SelectedItem;
                tb_codigoEstudiante.Text = view.Row.ItemArray[3].ToString();
                b_devolver.IsEnabled = true;
            }
        }



        private void cb_devueltosN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (0 == cb_devueltosN.SelectedIndex)
                {
                    // Traer todos los prestamos que tienen fecha de devolucion
                    this.dg_prestamos.DataContext = NegPrestamos.ObtenerPrestamosAll("Devueltos");

                }
                else
                {
                    // traer todos los prestamos que no tienen fecha devolucion
                    this.dg_prestamos.DataContext = NegPrestamos.ObtenerPrestamosAll("NoDevueltos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_codigoEstudiante_TextChanged(object sender, TextChangedEventArgs e)
        {

            // Obtener el texto ingresado en el tb_codigoEstudiante
            string searchText = tb_codigoEstudiante.Text.Trim().ToLower();

            // Verificar si el texto no está vacío
            if (!string.IsNullOrEmpty(searchText))
            {
                // Filtrar los prestamos que coinciden con el código de estudiante ingresado
                DataTable filteredTable = ((DataTable)dg_prestamos.DataContext).Clone(); // Clonar la estructura de la tabla original
                

                foreach (DataRow row in ((DataTable)dg_prestamos.DataContext).Rows)
                {
                    // Obtener el valor de la celda en la columna 3
                    string cellValue = row.ItemArray[3].ToString().ToLower(); // Columna 2 (índice 1)

                    // Verificar si el valor de la celda contiene el texto ingresado
                    if (cellValue.Contains(searchText))
                    {
                        // Agregar la fila filtrada a la tabla
                        filteredTable.ImportRow(row);
                    }
                }

                // Asignar la tabla filtrada como contexto de la DataGrid
                dg_prestamos.DataContext = filteredTable;
            }
            else
            {
                // Si el texto está vacío, restaurar todos los datos
                this.dg_prestamos.DataContext = NegPrestamos.ObtenerPrestamosAll("Todos");
            }
        }

        private void b_devolver_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string validar = "";
                if (dg_prestamos.SelectedItem != null)
                {
                    DataRowView view = (DataRowView)dg_prestamos.SelectedItem;
                    validar = view.Row.ItemArray[6].ToString();
                }

                if (!string.IsNullOrEmpty(tb_codigoEstudiante.Text) && validar == "") // lo de vacio en validar representa que la fechadevolucion no esta registrada
                {
                    string rpta = NegPrestamos.actualizar(Convert.ToInt32(tb_codigoEstudiante.Text));
                    MessageBox.Show(rpta, "Seguridad", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.dg_prestamos.DataContext = NegPrestamos.ObtenerPrestamosAll("Todos");
                }
                else
                {
                    MessageBox.Show("No se puede devolver un Libro Devuelto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
