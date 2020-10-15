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
using System.Collections.ObjectModel;
using ClasesBase;
using ClasesBase.TrabajarABM;

namespace Vistas.ControlUsuario {
    /// <summary>
    /// Lógica de interacción para UserControlDashboard.xaml
    /// </summary>
    public partial class UserControlDashboard : UserControl {

    
        bool nuevo = true;

        public UserControlDashboard() {
            InitializeComponent();
        }

        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuario;

        private void btnNuevoUsu_Click(object sender, RoutedEventArgs e)
        {
            habilitar_tetxbox();
            nuevo = true;
            habilitar_botones();

            btnModifUsu.IsEnabled = false;
            btnEliminarUsu.IsEnabled = false;
        }
        private void btnModifUsu_Click(object sender, RoutedEventArgs e) {
            nuevo = false;
            txtCod_Usu.Text = txtCod_Usu_Canvas.Text;
            txtUserName_Usu.Text = txtUserName_Usu_Canvas.Text;
            txtPassword_Usu.Text = txtPassword_Usu_Canvas.Text;
            txtApellido_Usu.Text = txtApellido_Usu_Canvas.Text;
            txtRol_Usu.Text = txtRol_Usu_Canvas.Text;
            habilitar_tetxbox();
            habilitar_botones();

            btnNuevoUsu.IsEnabled = false;
            btnEliminarUsu.IsEnabled = false;
        }

        private void btnEliminarUsu_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el Usuario?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No) {

            } else {
                Usuario oUser = new Usuario();
                oUser.Usu_Id = Convert.ToInt32(txtCod_Usu_Canvas.Text);
                listaUsuario.Remove(Vista.CurrentItem as Usuario);
                ABMUsuario.eliminar_usuario(oUser);
                MessageBox.Show("Usuario Eliminado");

            }
        }

        private void btnCancelarUsu_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_botones();
            deshabilitar_textbox();

            btnNuevoUsu.IsEnabled = true;
            btnModifUsu.IsEnabled = true;
            btnEliminarUsu.IsEnabled = true;
        }

        private void btnGuardarUsu_Click(object sender, RoutedEventArgs e)
        {
            if (nuevo == true) {
                nuevo_usuario();
            } else {
                modificar_usuario();
            }

            

            btnNuevoUsu.IsEnabled = true;
            btnModifUsu.IsEnabled = true;
            btnEliminarUsu.IsEnabled = true;
            
        }

        private void btnIrPrimero_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToFirst();
        }

        private void btnIrAtras_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToPrevious();
            if (Vista.IsCurrentBeforeFirst) {
                Vista.MoveCurrentToLast();
            }
        }

        private void btnIrSiguiente_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToNext();
            if (Vista.IsCurrentAfterLast) {
                Vista.MoveCurrentToFirst();
            }
        }

        private void btnIrUltimo_Click(object sender, RoutedEventArgs e)
        {
            Vista.MoveCurrentToLast();
        }

        private void btnActualizarUsu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void llenar_vista() {
            ObjectDataProvider odp = (ObjectDataProvider)this.Resources["lista_Usuarios"];
            listaUsuario = odp.Data as ObservableCollection<Usuario>;
            Vista = (CollectionView)CollectionViewSource.GetDefaultView(canvas_content.DataContext);
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            llenar_vista();
            cargar_Combo();
        }

        private void habilitar_botones()
        {
            btnGuardarUsu.Visibility = Visibility.Visible;
            btnCancelarUsu.Visibility = Visibility.Visible; 
        }
        private void deshabilitar_botones()
        {
            btnGuardarUsu.Visibility = Visibility.Hidden;
            btnCancelarUsu.Visibility = Visibility.Hidden;
        }

        private void deshabilitar_textbox()
        {
            //txtUserName_Usu.Visibility = Visibility.Hidden;
            //txtPassword_Usu.Visibility = Visibility.Hidden;
            //txtApellido_Usu.Visibility = Visibility.Hidden;
            //txtRol_Usu.Visibility = Visibility.Hidden;

            //txtPassword_Usu_Canvas.Visibility = Visibility.Visible;
            //txtPassword_Usu_Canvas.Visibility = Visibility.Visible;
            //txtApellido_Usu_Canvas.Visibility = Visibility.Visible;
            //txtRol_Usu_Canvas.Visibility = Visibility.Visible;
        }

        private void habilitar_tetxbox()
        {
            //txtUserName_Usu.Visibility = Visibility.Visible;
            //txtPassword_Usu.Visibility = Visibility.Visible;
            //txtApellido_Usu.Visibility = Visibility.Visible;
            //txtRol_Usu.Visibility = Visibility.Visible;

            //txtPassword_Usu_Canvas.Visibility = Visibility.Hidden;
            //txtPassword_Usu_Canvas.Visibility = Visibility.Hidden;
            //txtApellido_Usu_Canvas.Visibility = Visibility.Hidden;
            //txtRol_Usu_Canvas.Visibility = Visibility.Hidden;
        }

        private void nuevo_usuario() {
            try {
                Usuario oUser = new Usuario();
                oUser.Usu_Id = listaUsuario.Last().Usu_Id + 1;
                oUser.Usu_NombreUsuario = txtUserName_Usu.Text;
                oUser.Usu_Contraseña = txtPassword_Usu.Text;
                oUser.Usu_ApellidoNombre = txtApellido_Usu.Text;
                //oUser.Rol_Codigo = Convert.ToInt32(txtRol_Usu.Text);
                oUser.Rol_Codigo = Convert.ToInt32(cmbRol.SelectedValue);
                ABMUsuario.nuevo_usuario(oUser);
                deshabilitar_botones();
                listaUsuario.Add(oUser);
                Vista.MoveCurrentToLast();
                deshabilitar_textbox();
                limpiarCampos();
                MessageBox.Show("Agregado!");
            } catch {
                MessageBox.Show("El nombre de usuario esta en uso");
            }
            
        }

        private void modificar_usuario() {

            try {
                Usuario oUser = new Usuario();
                oUser = new Usuario();
                oUser.Usu_Id = Convert.ToInt32(txtCod_Usu.Text);
                oUser.Usu_NombreUsuario = txtUserName_Usu.Text;
                oUser.Usu_Contraseña = txtPassword_Usu.Text;
                oUser.Usu_ApellidoNombre = txtApellido_Usu.Text;
                oUser.Rol_Codigo = Convert.ToInt32(txtRol_Usu.Text);
                
                ABMUsuario.modificar_usuario(oUser);

                deshabilitar_textbox();
                deshabilitar_botones();

                listaUsuario[Vista.CurrentPosition] = oUser;

                MessageBox.Show("Modificado!");
                Vista.MoveCurrentToLast();
                Vista.MoveCurrentToPosition(0);
                limpiarCampos();
            } catch {
                MessageBox.Show("El nombre de usuario esta en uso");
            }
        }
        
        private void limpiarCampos() {
            txtCod_Usu.Text = "";
            txtApellido_Usu.Text = "";
            txtUserName_Usu.Text = "";
            txtPassword_Usu.Text = "";
            txtRol_Usu.Text = "";
        }

        private void cargar_Combo() {
            cmbRol.DisplayMemberPath = "rol_Descripcion";
            cmbRol.SelectedValuePath = "rol_Codigo";
            cmbRol.ItemsSource = ABMRol.cargar_rol().DefaultView;

            cmbRolCanvas.DisplayMemberPath = "rol_Descripcion";
            cmbRolCanvas.SelectedValuePath = "rol_Codigo";
            cmbRolCanvas.ItemsSource = ABMRol.cargar_rol().DefaultView;
        }
    }
}
