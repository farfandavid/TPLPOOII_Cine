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
using ClasesBase;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para UserControlABMPeliculas.xaml
    /// </summary>
<<<<<<< Updated upstream
    public partial class UserControlABMPeliculas : UserControl
    {
        List<Pelicula> listPeliculas = new List<Pelicula>();
        String gen, clas;
        int cont = 1;
        public UserControlABMPeliculas()
        {
            InitializeComponent();

            txtCod_Pel.Text = cont.ToString();


            List<Pelicula> listaClases = new List<Pelicula>();
            listaClases.Add(new Pelicula { Peli_Clase = "APTP" } );
            listaClases.Add(new Pelicula { Peli_Clase = "SAM 13" });
            listaClases.Add(new Pelicula { Peli_Clase = "SAM 16" });
            listaClases.Add(new Pelicula { Peli_Clase = "SAM 18" });

            Clases.ItemsSource = listaClases;

            List<Pelicula> listaGeneros = new List<Pelicula>();
            listaGeneros.Add(new Pelicula {Peli_Genero = "Aventura" });
            listaGeneros.Add(new Pelicula { Peli_Genero = "Comedia" });
            listaGeneros.Add(new Pelicula { Peli_Genero = "Drama" });
            listaGeneros.Add(new Pelicula { Peli_Genero = "Terror" });
            listaGeneros.Add(new Pelicula { Peli_Genero = "Ciencia Ficcion" });
            listaGeneros.Add(new Pelicula { Peli_Genero = "Guerra" });

            Generos.ItemsSource = listaGeneros;

            
        }

        private void btnAgregarPel_Click(object sender, RoutedEventArgs e)
        {
            Pelicula oPelicula = new Pelicula();
            oPelicula.Peli_Codigo = txtCod_Pel.Text;
            oPelicula.Peli_Titulo = txtTitulo_Pel.Text;
            oPelicula.Peli_Duracion = txtDuracion_Pel.Text;
            oPelicula.Peli_Genero = gen;
            oPelicula.Peli_Clase = clas;

            listPeliculas.Add(oPelicula);
            dgListadoPeliculas.ItemsSource = listPeliculas;
            dgListadoPeliculas.Items.Refresh();

            MessageBox.Show("Los datos fueron guardados con exito \nCodigo=" + txtCod_Pel.Text + "\nTitulo=" + txtTitulo_Pel.Text + "\nDuracion="
                + txtDuracion_Pel.Text + "\nGenero=" + gen + "\nClase=" + clas, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);

            cont = cont + 1;
            txtCod_Pel.Text = cont.ToString();
            txtDuracion_Pel.Clear();
            txtTitulo_Pel.Clear();
            
        }

        private void btnEliminarPel_Click(object sender, RoutedEventArgs e)
        {
=======
    public partial class UserControlABMPeliculas : UserControl {
        Pelicula pelicula = new Pelicula();
        CollectionViewSource vistaColeccionFiltrada;

        public UserControlABMPeliculas() {
            InitializeComponent();
            vistaColeccionFiltrada = Resources["filtro_peli"] as CollectionViewSource;
        }

        private void eventVistaPelicula(object sender, FilterEventArgs e)
        {
            Pelicula pelicula = e.Item as Pelicula;

            if (pelicula.Peli_Titulo.StartsWith(txtNamePelicula.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void btnAgregarPel_Click(object sender, RoutedEventArgs e) {
            if (txtTitulo_Pel.Text == "" || txtDuracion_Pel.Text == "" || cmbClases.Text == "" || cmbGeneros.Text == "")
            {
                CamposIncompletos.IsOpen = true;
            }
            else
            {
                Pelicula oPelicula = new Pelicula();
                oPelicula.Peli_Titulo = txtTitulo_Pel.Text;
                oPelicula.Peli_Duracion = txtDuracion_Pel.Text;
                oPelicula.Peli_Genero = cmbGeneros.SelectedValue.ToString();
                oPelicula.Peli_Clase = cmbClases.SelectedValue.ToString();
                try
                {
                    ABMPelicula.agregar_Pelicula(oPelicula);
                    MessageBox.Show("Los datos fueron guardados con exito \nTitulo=" + txtTitulo_Pel.Text + "\nDuracion="
                        + txtDuracion_Pel.Text + "\nGenero=" + cmbGeneros.SelectedValue.ToString() + "\nClase=" + cmbClases.SelectedValue.ToString(), "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtDuracion_Pel.Clear();
                    txtTitulo_Pel.Clear();

                    dgPeliculas.ItemsSource = ABMPelicula.traerPelicula().AsDataView();
                    pelicula = null;
                } catch {
                    PeliRepetida.IsOpen = true;
                }
            }
        }

        private void btnEliminarPel_Click(object sender, RoutedEventArgs e) {

            if (dgPeliculas.SelectedItem == null) {
                EliminarPel.IsOpen=true;
                return;
            }
               try {
                if (MessageBox.Show("Seguro quiere eliminarlo", "Importante!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ABMPelicula.eliminarPelicula(pelicula);
                    dgPeliculas.ItemsSource = ABMPelicula.traerPelicula().AsDataView();
                    vaciarCampos();
                    pelicula = null;
                }
                
                } catch {
                    CodInexistente.IsOpen=true;
                }
        }
>>>>>>> Stashed changes

        }

<<<<<<< Updated upstream
        private void cmbClases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pelicula selected1 = this.Clases.SelectedItem as Pelicula;
            clas = selected1.Peli_Clase;
=======
        private void dgPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            pelicula = new Pelicula();
            DataRowView row_selected = dgPeliculas.SelectedItem as DataRowView;
            if (row_selected != null) {
                txtTitulo_Pel.Text = row_selected[1].ToString();
                txtDuracion_Pel.Text = row_selected[4].ToString();
                cmbClases.SelectedValue = row_selected[3].ToString();
                cmbGeneros.SelectedValue = row_selected[2].ToString();
                pelicula.Peli_Codigo = int.Parse(row_selected[0].ToString());
                pelicula.Peli_Titulo = row_selected[1].ToString();
                pelicula.Peli_Duracion = row_selected[4].ToString();
                pelicula.Peli_Clase = row_selected[3].ToString();
                pelicula.Peli_Genero = row_selected[2].ToString();
            }
>>>>>>> Stashed changes
        }

        private void cmbGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pelicula selected = this.Generos.SelectedItem as Pelicula;
            gen = selected.Peli_Genero;
        }

        private void txtNamePelicula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (vistaColeccionFiltrada != null)
            {
                vistaColeccionFiltrada.Filter += eventVistaPelicula;
            }
        }
    }
}
