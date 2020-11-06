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
using System.Reflection;
using ClasesBase;
using ClasesBase.TrabajarABM;
using System.Data;

namespace Vistas {
    /// <summary>
    /// Lógica de interacción para UserControlABMPeliculas.xaml
    /// </summary>
    public partial class UserControlABMPeliculas : UserControl {
        List<Pelicula> listPeliculas = new List<Pelicula>();
        Pelicula pelicula = new Pelicula();
        
        public UserControlABMPeliculas() {
            InitializeComponent();
            
             





        }

        private void btnAgregarPel_Click(object sender, RoutedEventArgs e) {
            Pelicula oPelicula = new Pelicula();
            oPelicula.Peli_Titulo = txtTitulo_Pel.Text;
            oPelicula.Peli_Duracion = txtDuracion_Pel.Text;
            oPelicula.Peli_Genero = cmbGeneros.SelectedValue.ToString();
            oPelicula.Peli_Clase = cmbClases.SelectedValue.ToString();

            ABMPelicula.agregar_Pelicula(oPelicula);
            dgPeliculas.ItemsSource = ABMPelicula.traerPelicula().AsDataView();

            MessageBox.Show("Los datos fueron guardados con exito \nCodigo=" + txtCod_Pel.Text + "\nTitulo=" + txtTitulo_Pel.Text + "\nDuracion="
                + txtDuracion_Pel.Text + "\nGenero=" + cmbGeneros.SelectedValue.ToString() + "\nClase=" + cmbClases.SelectedValue.ToString(), "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);


            vaciarCampos();

        }

        private void btnEliminarPel_Click(object sender, RoutedEventArgs e) {

            if (dgPeliculas.SelectedItem == null) {
                EliminarPel.IsOpen=true;
                return;
            } else {
                //int numero;
                //Int32.TryParse(txtCli_Dni.Text, out numero);
                //ocliente.Cli_DNI = numero.ToString();
                //ocliente.Cli_Nombre = txtCli_Nombre.Text;
                //ocliente.Cli_Apellido = txtCli_Apellido.Text;
                //ocliente.Cli_Telefono = txtCli_Telefono.Text;
                //ocliente.Cli_Email = txtCli_Email.Text;
                //ABMCliente.eliminar_cliente(ocliente);
                try {
                    ABMPelicula.eliminarPelicula(pelicula);
                    dgPeliculas.ItemsSource = ABMPelicula.traerPelicula().AsDataView();
                    vaciarCampos();
                    pelicula = null;
                } catch {
                    CodInexistente.IsOpen=true;
                }

            }
        }

        private void btnModificalPel_Click(object sender, RoutedEventArgs e) {
            if (dgPeliculas.SelectedItem == null) {
                EliminarPel.IsOpen = true;
            } else {
                try {
                    pelicula.Peli_Titulo = txtTitulo_Pel.Text;
                    pelicula.Peli_Duracion = txtDuracion_Pel.Text;
                    pelicula.Peli_Clase = cmbClases.SelectedValue.ToString();
                    pelicula.Peli_Genero = cmbGeneros.SelectedValue.ToString();

                    ABMPelicula.editarPelicula(pelicula);
                    dgPeliculas.ItemsSource = ABMPelicula.traerPelicula().AsDataView();
                    vaciarCampos();
                    pelicula = null;
                } catch {
                    CodInexistente.IsOpen = true;
                }
                
            }
        }

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
                //MessageBox.Show(pelicula.Peli_Codigo.ToString());
            }
        }

        private void vaciarCampos() {
            txtDuracion_Pel.SelectedTime = null;
            txtTitulo_Pel.Text = "";
            txtDuracion_Pel.Text = "";
            cmbClases.SelectedValue = "";
            cmbGeneros.SelectedValue = "";
        }

        private void btnAgregarFoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarVideo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

