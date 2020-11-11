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
using Microsoft.Win32;
using System.IO;

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
            oPelicula.Peli_Imagen = txtPel_Img.Text;
            oPelicula.Peli_Trailer = txtPel_Vid.Text;

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
                try {
                    ABMPelicula.eliminarPelicula(pelicula);
                    dgPeliculas.ItemsSource = ABMPelicula.traerPelicula().AsDataView();
                    vaciarCampos();
                    pelicula = null;
                } catch(Exception ex) {
                    if (ex.HResult==-2146232060) {
                        MessageBox.Show("Pelicula asociada a una Proyeccion");
                    }else {
                        CodInexistente.IsOpen = true;
                    }
                    
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
                    pelicula.Peli_Imagen = txtPel_Img.Text;
                    pelicula.Peli_Trailer = txtPel_Vid.Text;

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
            BitmapImage bi3 = new BitmapImage();
            //MediaElement me3 = new MediaElement();
            //string videoPath = "";

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
                pelicula.Peli_Imagen = row_selected[5].ToString();
                pelicula.Peli_Trailer = row_selected[6].ToString();

                ////Imagen
                //bi3.BeginInit();
                //bi3.StreamSource = System.IO.File.OpenRead(row_selected[5].ToString());
                //bi3.EndInit();

                ////Trailer
                //videoPath = System.IO.File.OpenRead(row_selected[6].ToString()).Name.ToString();
                //videoPeli.Source = new Uri(videoPath);

                //imagePeli.Stretch = Stretch.Fill;
                //imagePeli.Source = bi3;
                //MessageBox.Show(row_selected[5].ToString());
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
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.jpg; *.bmp; *.png; *.jpeg) | *.jpg; *.bmp; *.png; *.jpeg";
            string pathImg = "../../Pelicula/Imagen/";
            if (open.ShowDialog() == true) {
                
                MessageBox.Show(open.SafeFileName);
                try {
                    System.IO.File.Copy(open.FileName, pathImg + open.SafeFileName);
                    txtPel_Img.Text = pathImg + open.SafeFileName;
                } catch {
                    System.IO.File.Copy(open.FileName, pathImg +"Copia "+ open.SafeFileName);
                    txtPel_Img.Text = pathImg +"Copia "+ open.SafeFileName;
                }
                
            }
            //BitmapDecoder bitdecoder;
            //OpenFileDialog open = new OpenFileDialog();
            //open.InitialDirectory = @"C:\";
            //open.Filter = "(*.jpg; *.bmp; *.png; *.jpeg) | *.jpg; *.bmp; *.png; *.jpeg";
            //if (open.ShowDialog() == true) {
            //    using (Stream stream = open.OpenFile()) {
            //        bitdecoder = BitmapDecoder.Create(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            //        txtPel_Img.Text = open.FileName.ToString().Trim();
            //    }
            //}
        }

        private void btnAgregarVideo_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            //open.InitialDirectory = @"C:\";
            open.Filter = "(*.mp4; *.avi; *.wmv; *.mpeg) | *.mp4; *.avi; *.wmv; *.mpeg";
            string pathVid = "../../Pelicula/Trailer/";
            if (open.ShowDialog() == true) {

                MessageBox.Show(open.SafeFileName);
                try {
                    System.IO.File.Copy(open.FileName, pathVid + open.SafeFileName);
                    txtPel_Vid.Text = pathVid + open.SafeFileName;
                } catch {
                    System.IO.File.Copy(open.FileName, pathVid + "Copia " + open.SafeFileName);
                    txtPel_Vid.Text = pathVid + "Copia " + open.SafeFileName;
                }

            }
            //if (open.ShowDialog() == true) {
            //    this.txtPel_Vid.Text = open.FileName;
            //}
        }
    }
}

