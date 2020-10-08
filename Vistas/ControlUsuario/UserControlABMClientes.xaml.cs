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

namespace Vistas.ControlUsuario {
    /// <summary>
    /// Lógica de interacción para UserControlABMClientes.xaml
    /// </summary>
    public partial class UserControlABMClientes : UserControl {
        ABMCliente trabajarCli = new ABMCliente();
        Cliente cliente = new Cliente();
        //Cliente[] clientes = new Cliente[0];
        public UserControlABMClientes() {
            InitializeComponent();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void btnAgregarCli_Click(object sender, RoutedEventArgs e) {
            if (txtCli_Dni.Equals(null)&&txtCli_Nombre.Equals(null) && txtCli_Apellido.Equals(null) && txtCli_Telefono.Equals(null) && txtCli_Email.Equals(null))
            {
                CamposIncompletos.IsOpen = true;
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

                try {
                    ABMCliente.agregar_cliente(ocliente);
                    MessageBox.Show("Los datos fueron guardados con exito \nDNI=" + txtCli_Dni.Text + "\nNombre=" + txtCli_Nombre.Text + "\nApellido="
                        + txtCli_Apellido.Text + "\nTelefono=" + txtCli_Telefono.Text + "\nEmail=" + txtCli_Email.Text, "Acccion realizada con exito", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtCli_Dni.Clear();
                    txtCli_Nombre.Clear();
                    txtCli_Apellido.Clear();
                    txtCli_Telefono.Clear();
                    txtCli_Email.Clear();

                    dgClientes.ItemsSource = ABMCliente.traerCliente().AsDataView();
                    cliente = null;

                } catch {
                    DniRepetido.IsOpen=true;
                }
                
                //Array.Resize(ref clientes, clientes.Length+1);
                //clientes[clientes.Length - 1] = ocliente;

                //dgListadoClientes.ItemsSource = clientes;

                //falta actualizar ;

            }

        }

        private void btnEliminarCli_Click(object sender, RoutedEventArgs e) {
            Cliente ocliente = new Cliente();

            if (dgClientes.SelectedItem == null)
            {
                EliminarCli.IsOpen=true;
                return;            
            }
            else
            {
                //int numero;
                //Int32.TryParse(txtCli_Dni.Text, out numero);
                //ocliente.Cli_DNI = numero.ToString();
                //ocliente.Cli_Nombre = txtCli_Nombre.Text;
                //ocliente.Cli_Apellido = txtCli_Apellido.Text;
                //ocliente.Cli_Telefono = txtCli_Telefono.Text;
                //ocliente.Cli_Email = txtCli_Email.Text;
                //ABMCliente.eliminar_cliente(ocliente);
                try {
                    ABMCliente.eliminar_cliente(cliente);
                    dgClientes.ItemsSource = ABMCliente.traerCliente().AsDataView();
                    cliente = null;
                }catch{
                    DniInexistente.IsOpen= true;
                }
                
            }

            
            
        }

        private void btnBuscarCli_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            try {
                dt = ABMCliente.buscarCli_DNI(txtCli_Dni.Text.ToString());
                DataRow row = dt.Rows[0];

                txtCli_Dni.Text = row[3].ToString();
                txtCli_Nombre.Text = row[2].ToString();
                txtCli_Apellido.Text = row[1].ToString();
                txtCli_Telefono.Text = row[4].ToString();
                txtCli_Email.Text = row[5].ToString();
            } catch {
                
                DniInexistente.IsOpen=true;
            }
            


        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cliente = new Cliente();
            DataRowView row_selected = dgClientes.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtCli_Dni.Text = row_selected[1].ToString();
                txtCli_Nombre.Text = row_selected[3].ToString();
                txtCli_Apellido.Text = row_selected[2].ToString();
                txtCli_Telefono.Text = row_selected[4].ToString();
                txtCli_Email.Text = row_selected[5].ToString();
                this.cliente.Cli_ID = int.Parse(row_selected[0].ToString());
                this.cliente.Cli_DNI = row_selected[1].ToString();
                this.cliente.Cli_Nombre = row_selected[2].ToString();
                this.cliente.Cli_Apellido = row_selected[3].ToString();
                this.cliente.Cli_Telefono = row_selected[4].ToString();
                this.cliente.Cli_Email = row_selected[5].ToString();
                //MessageBox.Show(cliente.Cli_ID.ToString());
            }
        }
        private static List<T> ConvertDataTable<T>(DataTable dt) {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows) {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr) {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns) {
                foreach (PropertyInfo pro in temp.GetProperties()) {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        private void btnModificalCli_Click(object sender, RoutedEventArgs e) {
            if (dgClientes.SelectedItem == null) {
                EliminarCli.IsOpen=true;
                return;
            } else {

                this.cliente.Cli_DNI = txtCli_Dni.Text;
                this.cliente.Cli_Nombre = txtCli_Nombre.Text;
                this.cliente.Cli_Apellido = txtCli_Apellido.Text;
                this.cliente.Cli_Telefono = txtCli_Telefono.Text;
                this.cliente.Cli_Email = txtCli_Email.Text;
                ABMCliente.modificar_Cliente(cliente);
                vaciarCampos();
                dgClientes.ItemsSource = ABMCliente.traerCliente().AsDataView();
                cliente = null;
            }
        }

        private void vaciarCampos() {
            txtCli_Dni.Text = "";
            txtCli_Nombre.Text = "";
            txtCli_Apellido.Text = "";
            txtCli_Telefono.Text = "";
            txtCli_Email.Text = "";
        }
    }
}
