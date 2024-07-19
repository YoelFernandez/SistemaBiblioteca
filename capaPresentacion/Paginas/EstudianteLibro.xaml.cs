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
    /// Lógica de interacción para EstudianteLibro.xaml
    /// </summary>
    public partial class EstudianteLibro : Page
    {
        public EstudianteLibro()
        {
            InitializeComponent();
            tb_buscarEstudiant.TextChanged += tb_buscarEstudiant_TextChanged;
        }

        private void btn_selectLibr_Click(object sender, RoutedEventArgs e)
        {
            LibrosPrestar abrir = new LibrosPrestar();
            abrir.tb_codigoEstudiante1.Text = tb_codigoEstudi.Text;
            NavigationService?.Navigate(abrir);
        }

        private void dg_estudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dg_estudiantes.SelectedItem != null)
            {
                //para asignar los datos del registro seleccionado a los textBoxs de la la ventana VentaDetalles.xaml
                DataRowView view = (DataRowView)dg_estudiantes.SelectedItem;
                tb_codigoEstudi.Text = view.Row.ItemArray[0].ToString();
                tb_nombre.Text = view.Row.ItemArray[1].ToString();
                tb_ApellP.Text = view.Row.ItemArray[2].ToString();
                tb_ApellM.Text = view.Row.ItemArray[3].ToString();
                tb_telefono.Text = view.Row.ItemArray[4].ToString();
                btn_selectLibr.IsEnabled = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dg_estudiantes.AutoGenerateColumns = true;
            this.dg_estudiantes.DataContext = NegEstudiante.ObtenerEstudiantesComplet();
        }

        private void btn_Buscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tb_buscarEstudiant_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Obtener el texto ingresado en el tb_codigoEstudiante
            string searchText = tb_buscarEstudiant.Text.Trim().ToLower();

            // Verificar si el texto no está vacío
            if (!string.IsNullOrEmpty(searchText))
            {
                // Filtrar los prestamos que coinciden con el código de estudiante ingresado
                DataTable filteredTable = ((DataTable)dg_estudiantes.DataContext).Clone(); // Clonar la estructura de la tabla original
                 

                foreach (DataRow row in ((DataTable)dg_estudiantes.DataContext).Rows)
                {
                    // Obtener el valor de la celda en la columna 0
                    string cellValue = row.ItemArray[0].ToString().ToLower(); // Columna 2 (índice 1)

                    // Verificar si el valor de la celda contiene el texto ingresado
                    if (cellValue.Contains(searchText))
                    {
                        // Agregar la fila filtrada a la tabla
                        filteredTable.ImportRow(row);
                    }
                }

                // Asignar la tabla filtrada como contexto de la DataGrid
                dg_estudiantes.DataContext = filteredTable;
            }
            else
            {
                // Si el texto está vacío, restaurar todos los datos
                this.dg_estudiantes.DataContext = NegEstudiante.ObtenerEstudiantesComplet();
            }
        }


    }
}
