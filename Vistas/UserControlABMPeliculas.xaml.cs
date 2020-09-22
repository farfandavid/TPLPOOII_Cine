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

        }

        private void cmbClases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pelicula selected1 = this.Clases.SelectedItem as Pelicula;
            clas = selected1.Peli_Clase;
        }

        private void cmbGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pelicula selected = this.Generos.SelectedItem as Pelicula;
            gen = selected.Peli_Genero;
        }
    }
}
