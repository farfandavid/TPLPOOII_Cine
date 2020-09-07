using System;
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
using ClasesBase;

namespace Vistas.ABM {
    /// <summary>
    /// Interaction logic for ABMCliente.xaml
    /// </summary>
    public partial class ABMCliente: Page {

        Cliente cliente = new Cliente();

        public ABMCliente() {
            InitializeComponent();
        }

        private void btnAceptar_Click( object sender, RoutedEventArgs e ) {
            cliente.Cli_DNI = txtDNI.Text;
            cliente.Cli_Nombre = txtNombre.Text;
            cliente.Cli_Apellido = txtApellido.Text;
            cliente.Cli_Telefono = txtTelefono.Text;
            cliente.Cli_Email = txtEmail.Text;

            MessageBox.Show(cliente.Cli_DNI + "\n" + cliente.Cli_Nombre + "\n" +
            cliente.Cli_Apellido + "\n" + cliente.Cli_Telefono + "\n" + cliente.Cli_Email);
        }
    }
}
