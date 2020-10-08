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

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlABMProyecciones.xaml
    /// </summary>
    public partial class UserControlABMProyecciones : UserControl
    {
        List<Proyeccion> listaProyecciones = new List<Proyeccion>();
        int cont=1;
<<<<<<< HEAD
        //String sala;
=======
>>>>>>> Tp-versionMili
        public UserControlABMProyecciones()
        {
            InitializeComponent();
            
            txtProy_Codigo.Text = cont.ToString();

<<<<<<< HEAD
            List<Proyeccion> listaSalas = new List<Proyeccion>();
            listaSalas.Add(new Proyeccion { Sala_ID = 1 });
            listaSalas.Add(new Proyeccion { Sala_ID = 2 });
            listaSalas.Add(new Proyeccion { Sala_ID = 3 });
            listaSalas.Add(new Proyeccion { Sala_ID = 4 });
            listaSalas.Add(new Proyeccion { Sala_ID = 5 });

            cmbNroSala.ItemsSource = listaSalas;
=======
            
>>>>>>> Tp-versionMili
        }

        private void btnAgregarProy_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            //Proyeccion oProyeccion = new Proyeccion();
            //oProyeccion.Proy_Codigo = cont;
            //oProyeccion.Proy_Fecha = DateTime.Parse(txtProy_Fecha.Text);
            //oProyeccion.Proy_Hora = txtProy_Hora.Text;
            //oProyeccion.Proy_Nro = sala;
            //oProyeccion.Peli_Codigo = txtProy_CodPel.Text;
=======
            Proyeccion oProyeccion = new Proyeccion();
            oProyeccion.Proy_Codigo = cont;
            oProyeccion.Proy_Fecha = txtProy_Fecha.Text;
            oProyeccion.Proy_Hora = txtProy_Hora.Text;
            oProyeccion.Proy_NroSala = cmbNroSala.SelectedValue.ToString();
            oProyeccion.Peli_Codigo = txtProy_CodPel.Text;
>>>>>>> Tp-versionMili

            //listaProyecciones.Add(oProyeccion);
            //dgListadoProyecciones.ItemsSource = listaProyecciones;
            //dgListadoProyecciones.Items.Refresh();

<<<<<<< HEAD
            //MessageBox.Show("Los datos fueron guardados con exito \nCodigo=" + cont + "\nFecha=" + txtProy_Fecha.Text + "\nHora="
            //    + txtProy_Hora.Text + "\nNumero Sala=" + sala + "\nCodigo Pelicula=" + txtProy_CodPel.Text, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);
=======
            MessageBox.Show("Los datos fueron guardados con exito \nCodigo=" + cont + "\nFecha=" + txtProy_Fecha.Text + "\nHora="
                + txtProy_Hora.Text + "\nNumero Sala=" + cmbNroSala.SelectedValue.ToString() + "\nCodigo Pelicula=" + txtProy_CodPel.Text, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);
>>>>>>> Tp-versionMili

            //cont = cont + 1;
            //txtProy_Codigo.Text = cont.ToString();
            //txtProy_Fecha.Clear();
            //txtProy_Hora.Clear();
            //txtProy_CodPel.Clear();
        }

<<<<<<< HEAD
        private void cmbSalas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Proyeccion selec = this.cmbNroSala.SelectedItem as Proyeccion;
            //sala = selec.Proy_NroSala;
        }
=======
>>>>>>> Tp-versionMili
    }
}
