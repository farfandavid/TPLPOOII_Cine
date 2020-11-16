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
using System.ComponentModel;
using System.Collections.Specialized;

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlListadoProyeccion.xaml
    /// </summary>
    public partial class UserControlListadoProyeccion : UserControl, INotifyCollectionChanged, INotifyPropertyChanged {
        Proyeccion proyeccion;
        CollectionViewSource vistaColeccionFiltrada;

        CollectionView vista;
        ObservableCollection<Proyeccion> listaProy;

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public UserControlListadoProyeccion() {
            InitializeComponent();
            vistaColeccionFiltrada = Resources["VISTA_PROY"] as CollectionViewSource;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            trailer.LoadedBehavior = MediaState.Manual;
            llenar_vista();
            cargarImg();
            cargarVid();


        }
        private void llenar_vista() {


            (FindResource("LIST_PROY") as ObjectDataProvider).Refresh();
            //this.Resources["LIST_PROY"] = abmp.traer_viewProy();
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["LIST_PROY"];
            listaProy = odp.Data as ObservableCollection<Proyeccion>;
            vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);


            //canvas_content.DataContext = abmpr.traer_viewProy();
            //vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);
        }

        private void cargarImg() {

            if (vistaColeccionFiltrada != null) {
                if (vistaColeccionFiltrada.View.CurrentPosition != -1) {

                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.StreamSource = System.IO.File.OpenRead(listaProy[vistaColeccionFiltrada.View.CurrentPosition].Pelicula.Peli_Imagen);
                    bi3.EndInit();
                    PeliImg.Source = bi3;
                }
            }
            //if (vistaColeccionFiltrada.View.CurrentPosition != -1) {

            //    BitmapImage bi3 = new BitmapImage();
            //    bi3.BeginInit();
            //    bi3.StreamSource = System.IO.File.OpenRead(listaP[vistaColeccionFiltrada.View.CurrentPosition].Pelicula.Peli_Imagen);
            //    bi3.EndInit();
            //    PeliImg.Source = bi3;
            //}
        }

        private void cargarVid() {
            if (vistaColeccionFiltrada != null) {
                if (vistaColeccionFiltrada.View.CurrentPosition != -1) {
                    string videoPath = System.IO.File.OpenRead(listaProy[vistaColeccionFiltrada.View.CurrentPosition].Pelicula.Peli_Trailer).Name.ToString();
                    trailer.Source = new Uri(videoPath);
                }
            }
            //if (vistaColeccionFiltrada.View.CurrentPosition != -1) {
            //    string videoPath = System.IO.File.OpenRead(listaP[vistaColeccionFiltrada.View.CurrentPosition].Pelicula.Peli_Trailer).Name.ToString();
            //    trailer.Source = new Uri(videoPath);
            //}
        }
        private void eventVistaPelicula_Filter(object sender, FilterEventArgs e) {
            proyeccion = new Proyeccion();

            proyeccion = e.Item as Proyeccion;

            if (txtProy_Fecha.Text != "") {
                if (proyeccion.Proy_Fecha == DateTime.Parse(txtProy_Fecha.Text)
                    && proyeccion.Pelicula.Peli_Titulo.StartsWith(txtBuscar.Text, StringComparison.CurrentCultureIgnoreCase)) {
                    e.Accepted = true;

                } else {
                    e.Accepted = false;
                }
            } else {
                if (proyeccion.Pelicula.Peli_Titulo.StartsWith(txtBuscar.Text, StringComparison.CurrentCultureIgnoreCase)) {
                    e.Accepted = true;
                } else {
                    e.Accepted = false;
                }
            }
        }
        private void eventVistaPeliculaSiete_Filter(object sender, FilterEventArgs e) {
            proyeccion = new Proyeccion();

            proyeccion = e.Item as Proyeccion;


            if (proyeccion.Proy_Fecha >= DateTime.Now.Date && proyeccion.Proy_Fecha < DateTime.Now.Date.AddDays(8)) {
                e.Accepted = true;

            } else {
                e.Accepted = false;
            }


        }

        private void eventVistaPeliculaSiete_FilterLlenar(object sender, FilterEventArgs e) {
            proyeccion = new Proyeccion();

            proyeccion = e.Item as Proyeccion;

            if (proyeccion.Pelicula.Peli_Titulo.StartsWith(txtBuscar.Text, StringComparison.CurrentCultureIgnoreCase)) {
                e.Accepted = true;
            } else {
                e.Accepted = false;
            }

        }

        //DashBoard Botones
        private void btnIrPrimero_Click(object sender, RoutedEventArgs e) {
            vista.MoveCurrentToFirst();
            cargarImg();
            cargarVid();

        }

        private void btnIrAtras_Click(object sender, RoutedEventArgs e) {
            vista.MoveCurrentToPrevious();
            if (vista.IsCurrentBeforeFirst) {
                vista.MoveCurrentToLast();
            }
            cargarImg();
            cargarVid();

        }

        private void btnIrSiguiente_Click(object sender, RoutedEventArgs e) {
            vista.MoveCurrentToNext();
            if (vista.IsCurrentAfterLast) {
                vista.MoveCurrentToFirst();
            }
            cargarImg();
            cargarVid();

        }

        private void btnIrUltimo_Click(object sender, RoutedEventArgs e) {
            vista.MoveCurrentToLast();
            cargarImg();
            cargarVid();

        }
        //--------------------------
        private void btnPlay_Click(object sender, RoutedEventArgs e) {
            trailer.Play();
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e) {
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
                vistaColeccionFiltrada.Filter += eventVistaPelicula_Filter;


            }
        }
        private void txtProy_Fecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e) {
            if (vistaColeccionFiltrada != null) {
                vistaColeccionFiltrada.Filter += eventVistaPelicula_Filter;
            }
        }

        private void btnDias_Click(object sender, RoutedEventArgs e) {
            if (vistaColeccionFiltrada != null) {
                vistaColeccionFiltrada.Filter += eventVistaPeliculaSiete_Filter;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName = null) {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e) {
            ABMProyeccion abmp = new ABMProyeccion();
            vistaColeccionFiltrada.Source = abmp.traer_viewProy();
        }
    }
}
