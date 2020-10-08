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

namespace Vistas.ControlUsuario {
    /// <summary>
    /// Lógica de interacción para UserControlABMClientes.xaml
    /// </summary>
    public partial class UserControlABMClientes : UserControl {
        ABMCliente trabajarCli = new ABMCliente();
        //Cliente[] clientes = new Cliente[0];
        public UserControlABMClientes() {
            InitializeComponent();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void btnAgregarCli_Click(object sender, RoutedEventArgs e) {
            if (txtCli_Dni.Equals(null)&&txtCli_Nombre.Equals(null) && txtCli_Apellido.Equals(null) && txtCli_Telefono.Equals(null) && txtCli_Email.Equals(null))
            {
                MessageBox.Show("TODOS LOS CAMPOS DEBEN ESTAR COMPLETADOS");
            }
            else
            {

            
            Cliente ocliente = new Cliente();
            int numero;
            Int32.TryParse(txtCli_Dni.Text, out numero);
            ocliente.Cli_DNI = numero.ToString();
            ocliente.Cli_Nombre = txtCli_Nombre.Text;
            ocliente.Cli_Apellido = txtCli_Apellido.Text;
            ocliente.Cli_Telefono = txtCli_Telefono.Text;
            ocliente.Cli_Email = txtCli_Email.Text;

            ABMCliente.agregar_cliente(ocliente);
            //Array.Resize(ref clientes, clientes.Length+1);
            //clientes[clientes.Length - 1] = ocliente;

            //dgListadoClientes.ItemsSource = clientes;

            //falta actualizar ;
            
            MessageBox.Show("Los datos fueron guardados con exito \nDNI=" + txtCli_Dni.Text + "\nNombre=" + txtCli_Nombre.Text + "\nApellido="
                + txtCli_Apellido.Text + "\nTelefono=" + txtCli_Telefono.Text + "\nEmail=" + txtCli_Email.Text, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);

            txtCli_Dni.Clear();
            txtCli_Nombre.Clear();
            txtCli_Apellido.Clear();
            txtCli_Telefono.Clear();
            txtCli_Email.Clear();

            }

        }

        private void btnEliminarCli_Click(object sender, RoutedEventArgs e) {
            Cliente ocliente = new Cliente();
            if(dgClientes.SelectedItem == null)
            {
                MessageBox.Show("SELECCIONE UN CLIENTE ANTES DE ELIMINAR");
                return;            
            }
            else
            {
                int numero;
                Int32.TryParse(txtCli_Dni.Text, out numero);
                ocliente.Cli_DNI = numero.ToString();
                ocliente.Cli_Nombre = txtCli_Nombre.Text;
                ocliente.Cli_Apellido = txtCli_Apellido.Text;
                ocliente.Cli_Telefono = txtCli_Telefono.Text;
                ocliente.Cli_Email = txtCli_Email.Text;
                ABMCliente.eliminar_cliente(ocliente);
            }

            
            
        }

        private void btnBuscarCli_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt=ABMCliente.buscarCli_DNI(txtCli_Dni.Text.ToString());
            
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataRowView row_selected = dgClientes.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtCli_Dni.Text = row_selected[1].ToString();
                txtCli_Nombre.Text = row_selected[2].ToString();
                txtCli_Apellido.Text = row_selected[3].ToString();
                txtCli_Telefono.Text = row_selected[4].ToString();
                txtCli_Email.Text = row_selected[5].ToString();
            }
        }
    }
}
