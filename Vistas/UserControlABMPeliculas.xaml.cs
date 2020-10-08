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
        
        int cont = 1;
        public UserControlABMPeliculas()
        {
            InitializeComponent();

            txtCod_Pel.Text = cont.ToString();


            

            
        }

        private void btnAgregarPel_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            //Pelicula oPelicula = new Pelicula();
            //oPelicula.Peli_Codigo = txtCod_Pel.Text;
            //oPelicula.Peli_Titulo = txtTitulo_Pel.Text;
            //oPelicula.Peli_Duracion = txtDuracion_Pel.Text;
            //oPelicula.Peli_Genero = gen;
            //oPelicula.Peli_Clase = clas;

            //listPeliculas.Add(oPelicula);
            //dgListadoPeliculas.ItemsSource = listPeliculas;
            //dgListadoPeliculas.Items.Refresh();

            //MessageBox.Show("Los datos fueron guardados con exito \nCodigo=" + txtCod_Pel.Text + "\nTitulo=" + txtTitulo_Pel.Text + "\nDuracion="
            //    + txtDuracion_Pel.Text + "\nGenero=" + gen + "\nClase=" + clas, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);

            //cont = cont + 1;
            //txtCod_Pel.Text = cont.ToString();
            //txtDuracion_Pel.Clear();
            //txtTitulo_Pel.Clear();
=======
            Pelicula oPelicula = new Pelicula();
            oPelicula.Peli_Codigo = txtCod_Pel.Text;
            oPelicula.Peli_Titulo = txtTitulo_Pel.Text;
            oPelicula.Peli_Duracion = txtDuracion_Pel.Text;
            oPelicula.Peli_Genero = cmbGeneros.SelectedValue.ToString();
            oPelicula.Peli_Clase = cmbClases.SelectedValue.ToString();

            listPeliculas.Add(oPelicula);
            dgListadoPeliculas.ItemsSource = listPeliculas;
            dgListadoPeliculas.Items.Refresh();

            MessageBox.Show("Los datos fueron guardados con exito \nCodigo=" + txtCod_Pel.Text + "\nTitulo=" + txtTitulo_Pel.Text + "\nDuracion="
                + txtDuracion_Pel.Text + "\nGenero=" + cmbGeneros.SelectedValue.ToString() + "\nClase=" + cmbClases.SelectedValue.ToString(), "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);

            cont = cont + 1;
            txtCod_Pel.Text = cont.ToString();
            txtDuracion_Pel.Clear();
            txtTitulo_Pel.Clear();
>>>>>>> Tp-versionMili
            
        }

        private void btnEliminarPel_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
