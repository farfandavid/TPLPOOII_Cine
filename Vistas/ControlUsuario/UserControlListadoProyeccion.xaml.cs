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
        CollectionView vista;
        ObservableCollection<Proyeccion> listaProy;
        CollectionViewSource vistaColeccionFiltrada;
        Proyeccion proyeccion;
        List<Proyeccion> listaP = new List<Proyeccion>();
        public UserControlListadoProyeccion()
        {
            InitializeComponent();
            vistaColeccionFiltrada = Resources["VISTA_PROY"] as CollectionViewSource;
        }

       



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
            if (vistaColeccionFiltrada.View.CurrentPosition != -1) {
                
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.StreamSource = System.IO.File.OpenRead(listaP[vistaColeccionFiltrada.View.CurrentPosition].Pelicula.Peli_Imagen);
                bi3.EndInit();
                PeliImg.Source = bi3;
            }

        }

        private void cargarVid() {
            if (vistaColeccionFiltrada.View.CurrentPosition != -1) {
                string videoPath = System.IO.File.OpenRead(listaP[vistaColeccionFiltrada.View.CurrentPosition].Pelicula.Peli_Trailer).Name.ToString();
                trailer.Source = new Uri(videoPath);
            }
        }
        private void eventVistaPelicula_Filter(object sender, FilterEventArgs e)
        {
            proyeccion = new Proyeccion();
            
            proyeccion = e.Item as Proyeccion;
        
            if (txtProy_Fecha.Text != "") {
                if (proyeccion.Proy_Fecha == DateTime.Parse(txtProy_Fecha.Text)
                    && proyeccion.Pelicula.Peli_Titulo.StartsWith(txtBuscar.Text, StringComparison.CurrentCultureIgnoreCase)) {
                    e.Accepted = true;
                    listaP.Add(proyeccion);
                    
                } else {
                    e.Accepted = false;
                }
            }else {
                if (proyeccion.Pelicula.Peli_Titulo.StartsWith(txtBuscar.Text, StringComparison.CurrentCultureIgnoreCase)) {
                    e.Accepted = true;
                    listaP.Add(proyeccion);
                } else {
                    e.Accepted = false;
                }
            }
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

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e) {

            if (vistaColeccionFiltrada != null) {
                listaP = new List<Proyeccion>();
                vistaColeccionFiltrada.Filter += eventVistaPelicula_Filter;
                
               
            }
        }
        private void txtProy_Fecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            if (vistaColeccionFiltrada != null) {
                vistaColeccionFiltrada.Filter += eventVistaPelicula_Filter;
            }
        }

        private void btnDias_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
