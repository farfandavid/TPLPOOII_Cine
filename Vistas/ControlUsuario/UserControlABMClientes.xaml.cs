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
    /// Lógica de interacción para UserControlABMClientes.xaml
    /// </summary>
    public partial class UserControlABMClientes : UserControl
    {
        List<Cliente> listaClientes = new List<Cliente>();
        //Cliente[] clientes = new Cliente[0];
        public UserControlABMClientes()
        {
            InitializeComponent();
            
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                            
        }

<<<<<<< Updated upstream
        private void btnAgregarCli_Click(object sender, RoutedEventArgs e)
        {
=======
        private void btnAgregarCli_Click(object sender, RoutedEventArgs e) {
            if (txtCli_Dni.Text==""||txtCli_Nombre.Text == "" || txtCli_Apellido.Text == "" || txtCli_Telefono.Text == "" || txtCli_Email.Text == "")
            {
                CamposIncompletos.IsOpen = true;
            }
            else
            {
>>>>>>> Stashed changes
            Cliente ocliente = new Cliente();
            int numero;
            Int32.TryParse(txtCli_Dni.Text, out numero);
            ocliente.Cli_Dni = numero;
            ocliente.Cli_Nombre = txtCli_Nombre.Text;
            ocliente.Cli_Apellido = txtCli_Apellido.Text;
            ocliente.Cli_Telefono = txtCli_Telefono.Text;
            ocliente.Cli_Email = txtCli_Email.Text;

            listaClientes.Add(ocliente);
            //Array.Resize(ref clientes, clientes.Length+1);
            //clientes[clientes.Length - 1] = ocliente;

            //dgListadoClientes.ItemsSource = clientes;
            dgListadoClientes.ItemsSource = listaClientes;
            dgListadoClientes.Items.Refresh();

            MessageBox.Show("Los datos fueron guardados con exito \nDNI=" + txtCli_Dni.Text + "\nNombre=" + txtCli_Nombre.Text + "\nApellido="
                + txtCli_Apellido.Text + "\nTelefono=" + txtCli_Telefono.Text + "\nEmail=" + txtCli_Email.Text, "Acccion realizada con exito", MessageBoxButton.OK,MessageBoxImage.Information);

            txtCli_Dni.Clear();
            txtCli_Nombre.Clear();
            txtCli_Apellido.Clear();
            txtCli_Telefono.Clear();
            txtCli_Email.Clear();

            
        }

        private void btnEliminarCli_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
