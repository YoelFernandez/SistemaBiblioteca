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
    /// Lógica de interacción para RegistrarAsistencia.xaml
    /// </summary>
    public partial class RegistrarAsistencia : Page
    {
        public RegistrarAsistencia()
        {
            InitializeComponent();
            tb_buscarCodigoEstudiante.TextChanged += tb_buscarCodigoEstudiante_TextChanged;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dg_registros.AutoGenerateColumns = true;
            this.dg_registros.DataContext = NegEstudiante.ObtenerEstudiantes();
        }

        private void dg_registros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //para asignar los datos del registro seleccionado a los textBoxs de la la ventana VentaDetalles.xaml
            if (dg_registros.SelectedItem != null)
            {
                DataRowView view = (DataRowView)dg_registros.SelectedItem;
                tb_buscarCodigoEstudiante.Text = view.Row.ItemArray[0].ToString();
            }
        }

        private void b_registrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rpta = "";
                // tener en cuenta el order de insercion 
                // INSERTAR NUEVOS DATOS EN LA BASE DE DATOS DONDE PASAMOS COMO PARAMETRO NOMBRE, PRECIO Y STOCK.
                rpta = NegInsertar.insertar(Convert.ToInt32(tb_buscarCodigoEstudiante.Text));
                MessageBox.Show(rpta, "Seguridad", MessageBoxButton.OK, MessageBoxImage.Information);

                b_registrar.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void tb_buscarCodigoEstudiante_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Obtener el texto ingresado en el tb_codigoEstudiante
                string searchText = tb_buscarCodigoEstudiante.Text.Trim().ToLower();

                // Verificar si el texto no está vacío
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Filtrar los prestamos que coinciden con el código de estudiante ingresado
                    DataTable filteredTable = new DataTable();
                    filteredTable = ((DataTable)dg_registros.DataContext).Clone(); // Clonar la estructura de la tabla original

                    foreach (DataRow row in ((DataTable)dg_registros.DataContext).Rows)
                    {
                        // Obtener el valor de la celda en la columna 2
                        string cellValue = row.ItemArray[0].ToString().ToLower(); // Columna 2 (índice 1)

                        // Verificar si el valor de la celda contiene el texto ingresado
                        if (cellValue.Contains(searchText))
                        {
                            // Agregar la fila filtrada a la tabla
                            filteredTable.ImportRow(row);
                        }
                    }

                    // Asignar la tabla filtrada como contexto de la DataGrid
                    dg_registros.DataContext = filteredTable;
                }
                else
                {
                    // Si el texto está vacío, restaurar todos los datos
                    this.dg_registros.DataContext = NegEstudiante.ObtenerEstudiantes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
