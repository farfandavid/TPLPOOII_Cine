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
using ClasesBase.TrabajarABM;
using System.Data;

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlABMProyecciones.xaml
    /// </summary>
    public partial class UserControlABMProyecciones : UserControl
    {
<<<<<<< Updated upstream
        List<Proyeccion> listaProyecciones = new List<Proyeccion>();
        int cont=1;
        String sala;
        public UserControlABMProyecciones()
        {
            InitializeComponent();
            
            txtProy_Codigo.Text = cont.ToString();

            List<Proyeccion> listaSalas = new List<Proyeccion>();
            listaSalas.Add(new Proyeccion { Proy_NroSala = "Sala 1"});
            listaSalas.Add(new Proyeccion { Proy_NroSala = "Sala 2" });
            listaSalas.Add(new Proyeccion { Proy_NroSala = "Sala 3" });
            listaSalas.Add(new Proyeccion { Proy_NroSala = "Sala 4" });
            listaSalas.Add(new Proyeccion { Proy_NroSala = "Sala 5" });
=======
        Proyeccion proyec = new Proyeccion();
        public UserControlABMProyecciones()
        {
            InitializeComponent();
        }

        private void btnAgregarProy_Click(object sender, RoutedEventArgs e)
        {
            if (txtProy_Fecha.Text == "" || txtProy_Hora.Text == "" || txtProy_CodPel.Text == "" || cmbNroSala.Text == "")
            {
                CamposIncompletos.IsOpen = true;
            }
            else
            {
                Proyeccion oProyeccion = new Proyeccion();
                oProyeccion.Proy_Fecha = new DateTime();
                oProyeccion.Proy_Hora = txtProy_Hora.Text;
                oProyeccion.Sala_ID = 1;
                oProyeccion.Peli_Codigo = int.Parse(txtProy_CodPel.Text);
                try
                {
                    ABMProyecciones.agregarProyecciones(oProyeccion);
                    MessageBox.Show("Los datos fueron guardados con exito \nFecha=" + txtProy_Fecha.Text + "\nHora="
                + txtProy_Hora.Text + "\nNumero Sala=" + cmbNroSala.SelectedValue.ToString() + "\nCodigo Pelicula="
                + txtProy_CodPel.Text, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtProy_Fecha.Clear();
                    txtProy_Hora.Clear();
                    txtProy_CodPel.Clear();

                    dgListadoProyecciones.ItemsSource = ABMProyecciones.traerProyeccion().AsDataView();
                    proyec = null;
                }
                catch
                {
                    PeliRepetida.IsOpen = true;
                }
            }
>>>>>>> Stashed changes

            cmbNroSala.ItemsSource = listaSalas;
        }
        private void btnEliminarProy_Click(object sender, RoutedEventArgs e)
        {

<<<<<<< Updated upstream
        private void btnAgregarProy_Click(object sender, RoutedEventArgs e)
        {
            Proyeccion oProyeccion = new Proyeccion();
            oProyeccion.Proy_Codigo = cont;
            oProyeccion.Proy_Fecha = txtProy_Fecha.Text;
            oProyeccion.Proy_Hora = txtProy_Hora.Text;
            oProyeccion.Proy_NroSala = sala;
            oProyeccion.Peli_Codigo = txtProy_CodPel.Text;

            listaProyecciones.Add(oProyeccion);
            dgListadoProyecciones.ItemsSource = listaProyecciones;
            dgListadoProyecciones.Items.Refresh();

            MessageBox.Show("Los datos fueron guardados con exito \nCodigo=" + cont + "\nFecha=" + txtProy_Fecha.Text + "\nHora="
                + txtProy_Hora.Text + "\nNumero Sala=" + sala + "\nCodigo Pelicula=" + txtProy_CodPel.Text, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);

            cont = cont + 1;
            txtProy_Codigo.Text = cont.ToString();
            txtProy_Fecha.Clear();
            txtProy_Hora.Clear();
            txtProy_CodPel.Clear();
        }

        private void cmbSalas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Proyeccion selec = this.cmbNroSala.SelectedItem as Proyeccion;
            sala = selec.Proy_NroSala;
=======
        }

        private void btnModificalProy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgProyeccion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            proyec = new Proyeccion();
            DataRowView row_selected = dgListadoProyecciones.SelectedItem as DataRowView
                if(row_selected != null) {
                ;
            }
>>>>>>> Stashed changes
        }
    }

}
