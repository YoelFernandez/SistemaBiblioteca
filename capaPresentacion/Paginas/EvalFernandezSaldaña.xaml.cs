using CapaNegocios;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Lógica de interacción para EvalFernandezSaldaña.xaml
    /// </summary>
    public partial class EvalFernandezSaldaña : Page
    {
        public EvalFernandezSaldaña()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.dg_evalu.AutoGenerateColumns = true;
            this.dg_evalu.DataContext = NegEstudiante.ObtenerEstudiantesComplet2();
        }

        byte[] data;
        private bool imagenSubida = false;
        private void subir(object sender, RoutedEventArgs e)
        {
            string id = tb_codigo.Text;
            string rpta;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
                rpta = NegEstudiante.anadirImagenUsuario(id, data);
                MessageBox.Show(rpta);
            }
            imagenSubida = true;
        }

        private void dg_evalu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_evalu.SelectedItem != null)
            {
                DataRowView view = (DataRowView)dg_evalu.SelectedItem;
                tb_codigo.Text = view.Row.ItemArray[0].ToString();

                byte[] bytesImagen = (byte[])view.Row.ItemArray[5];

                // Convertir el arreglo de bytes a un BitmapImage
                BitmapImage imagenBitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(bytesImagen))
                {
                    stream.Position = 0;
                    imagenBitmap.BeginInit();
                    imagenBitmap.CacheOption = BitmapCacheOption.OnLoad;
                    imagenBitmap.StreamSource = stream;
                    imagenBitmap.EndInit();
                }

                //Asignar la imagen al control Image
                imagen2.Source = imagenBitmap;
            }
        }
    }
}


