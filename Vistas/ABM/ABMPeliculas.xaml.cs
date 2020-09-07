using System;
using ClasesBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas.ABM {
    /// <summary>
    /// Interaction logic for ABMPeliculas.xaml
    /// </summary>
    public partial class ABMPeliculas: Page {

        Pelicula oPelicula = new Pelicula();
        public ABMPeliculas() {
            InitializeComponent();
        }

        private void btnAceptar_Click( object sender, RoutedEventArgs e ) {
            int i = 1;
            oPelicula.Peli_Codigo = i;
            oPelicula.Peli_Titulo = txtTitulo.Text;
            oPelicula.Peli_Duracion = txtDuracion.Text;
            oPelicula.Peli_Genero = txtGenero.Text;
            oPelicula.Peli_Clase = txtClase.Text;

            MessageBox.Show(oPelicula.Peli_Codigo + "\n" +
                oPelicula.Peli_Titulo + "\n" + oPelicula.Peli_Duracion + "\n" +
                oPelicula.Peli_Genero + "\n" + oPelicula.Peli_Clase);
            i++;
        }
    }
}
