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
using System.Collections.ObjectModel;
using ClasesBase.TrabajarABM;
using ClasesBase;

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlListadoProyeccion.xaml
    /// </summary>
    public partial class UserControlListadoProyeccion : UserControl
    {
        public UserControlListadoProyeccion()
        {
            InitializeComponent();
        }

        CollectionView vista;
        ObservableCollection<Proyeccion> listaProy;
        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            trailer.LoadedBehavior = MediaState.Manual;
            //agregar los source de los videos xd
            //trailer.Source = new Uri(@"", UriKind.Relative);
            
            llenar_vista();
            cargarImg();
            cargarVid();

            
        }
        private void llenar_vista() {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_PROY"];
            listaProy = odp.Data as ObservableCollection<Proyeccion>;
            vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);
            vista.MoveCurrentToFirst();

        }

        private void cargarImg() {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.StreamSource = System.IO.File.OpenRead(listaProy[vista.CurrentPosition].Pelicula.Peli_Imagen);
            bi3.EndInit();
            PeliImg.Source = bi3;
        }

        private void cargarVid() {
            string videoPath = System.IO.File.OpenRead(listaProy[vista.CurrentPosition].Pelicula.Peli_Trailer).Name.ToString();
            trailer.Source = new Uri(videoPath);
        }
        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        {

        }
        private void txtRol_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //DashBoard Botones
        private void btnIrPrimero_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToFirst();
            cargarImg();
            cargarVid();
        }

        private void btnIrAtras_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToPrevious();
            if (vista.IsCurrentBeforeFirst) {
                vista.MoveCurrentToLast();
            }
            cargarImg();
            cargarVid();
        }

        private void btnIrSiguiente_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToNext();
            if (vista.IsCurrentAfterLast) {
                vista.MoveCurrentToFirst();
            }
            cargarImg();
            cargarVid();
        }

        private void btnIrUltimo_Click(object sender, RoutedEventArgs e)
        {
            vista.MoveCurrentToLast();
            cargarImg();
            cargarVid();
        }
        //--------------------------
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            trailer.Play();
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(listaProy[vista.CurrentPosition].Pelicula.Peli_Imagen);
            trailer.Stop();
        }

        private void listUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            vista.MoveCurrentToPosition(listProyecion.SelectedIndex);
            cargarImg();
            cargarVid();
        }
    }
}
