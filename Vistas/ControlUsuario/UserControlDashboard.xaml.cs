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
        string _usuario = "";

        public UserControlDashboard() {
            InitializeComponent();
            
           
            btnEliminarUsu.IsEnabled = true;
            _usuario = txtUserName_Usu.Text;
        }

        CollectionView Vista;
        ObservableCollection<Usuario> listaUsuario;

        private void btnNuevoUsu_Click(object sender, RoutedEventArgs e)
        {
            habilitar_tetxbox();
            nuevo = true;
            habilitar_botones();
            deshabilitar_botonesCanvas();
            btnModifUsu.IsEnabled = false;
            btnEliminarUsu.IsEnabled = false;

        }
        private void btnModifUsu_Click(object sender, RoutedEventArgs e) {
            nuevo = false;
            txtCod_Usu.Text = txtCod_Usu_Canvas.Text;
            txtUserName_Usu.Text = txtUserName_Usu_Canvas.Text;
            txtPassword_Usu.Text = txtPassword_Usu_Canvas.Text;
            txtApellido_Usu.Text = txtApellido_Usu_Canvas.Text;
            cmbRol.SelectedValue = txtRol_Usu_Canvas.Text;
            habilitar_tetxbox();
            habilitar_botones();
            deshabilitar_botonesCanvas();
            btnNuevoUsu.IsEnabled = false;
            btnEliminarUsu.IsEnabled = false;
            _usuario = txtUserName_Usu.Text;
        }

        private void btnEliminarUsu_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el Usuario?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No) {

            } else {
               
                Usuario oUser = new Usuario();
                oUser.Usu_Id = Convert.ToInt32(txtCod_Usu_Canvas.Text);
                if (ABMUsuario.usuario_venta(oUser.Usu_Id) == 0)
                {
                    listaUsuario.Remove(Vista.CurrentItem as Usuario);
                    ABMUsuario.eliminar_usuario(oUser);
                    limpiarCampos();
                    txtMensaje.Text = "Usuario Eliminado";
                    mensajes.IsOpen = true;
                }else
                {
                    txtMensaje.Text = "El usuario posee ventas, no se puede eliminar";
                    mensajes.IsOpen = true;
                }
                
                
            }
        }

        private void btnCancelarUsu_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_botones();
            deshabilitar_textbox();

            btnNuevoUsu.IsEnabled = true;
            btnModifUsu.IsEnabled = true;
            btnEliminarUsu.IsEnabled = true;
            limpiarCampos();
            habilitar_botonesCanvas();
        }

        private void btnGuardarUsu_Click()
        {
            if (ABMUsuario.usuario_existente(txtUserName_Usu.Text) == 0 && nuevo == true)
            {
                nuevo_usuario();
            }
            else
            {
                if (nuevo == false &&
                    (ABMUsuario.usuario_existente(txtUserName_Usu.Text) == 0 || _usuario == txtUserName_Usu.Text))
                {
                    modificar_usuario();
                }
                else
                {
                    txtMensaje.Text = "Nombre de usuario Existente";
                    mensajes.IsOpen = true;
                    
                }

            }

            btnNuevoUsu.IsEnabled = true;
            btnModifUsu.IsEnabled = true;
            btnEliminarUsu.IsEnabled = true;
            habilitar_botonesCanvas();
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

        

        private void llenar_vista() {
            (FindResource("lista_Usuarios") as ObjectDataProvider).Refresh();
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
            btnGuardarUsu.IsEnabled = true;
            btnCancelarUsu.IsEnabled = true; 
        }
        private void deshabilitar_botones()
        {
            btnGuardarUsu.IsEnabled = false;
            btnCancelarUsu.IsEnabled = false;
        }

        private void deshabilitar_textbox()
        {
            txtUserName_Usu.IsEnabled = false;
            txtPassword_Usu.IsEnabled = false;
            txtApellido_Usu.IsEnabled = false;
            cmbRol.IsEnabled = false;
        }

        private void habilitar_tetxbox()
        {
            txtUserName_Usu.IsEnabled = true;
            txtPassword_Usu.IsEnabled = true;
            txtApellido_Usu.IsEnabled = true;
            cmbRol.IsEnabled = true;
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
                txtMensaje.Text = "Agregado!";
                mensajes.IsOpen = true;

                
            } catch {
                txtMensaje.Text = "El nombre de usuario esta en uso";
                mensajes.IsOpen = true;
                
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
                oUser.Rol_Codigo = Convert.ToInt32(cmbRol.SelectedValue.ToString());
                
                ABMUsuario.modificar_usuario(oUser);

                deshabilitar_textbox();
                deshabilitar_botones();

                listaUsuario[Vista.CurrentPosition] = oUser;
                txtMensaje.Text = "Modificado!";
                mensajes.IsOpen = true;
                Vista.MoveCurrentToLast();
                Vista.MoveCurrentToPosition(0);
                limpiarCampos();
            } catch {
                txtMensaje.Text = "El nombre de usuario esta en uso";
                mensajes.IsOpen = true;
            }
        }
        
        private void limpiarCampos() {
            txtCod_Usu.Text = "";
            txtApellido_Usu.Text = "";
            txtUserName_Usu.Text = "";
            txtPassword_Usu.Text = "";
            cmbRol.SelectedIndex= -1;
        }

        private void cargar_Combo() {
            cmbRol.DisplayMemberPath = "rol_Descripcion";
            cmbRol.SelectedValuePath = "rol_Codigo";
            cmbRol.ItemsSource = ABMRol.cargar_rol().DefaultView;

            cmbRolCanvas.DisplayMemberPath = "rol_Descripcion";
            cmbRolCanvas.SelectedValuePath = "rol_Codigo";
            cmbRolCanvas.ItemsSource = ABMRol.cargar_rol().DefaultView;
        }

        private void deshabilitar_botonesCanvas()
        {
            btn_Ir_Primero.IsEnabled = false;
            btn_Ir_Atras.IsEnabled = false;
            btn_Ir_Siguiente.IsEnabled = false;
            btn_Ir_Ultimo.IsEnabled = false;
        }

        private void habilitar_botonesCanvas()
        {
            btn_Ir_Primero.IsEnabled = true;
            btn_Ir_Atras.IsEnabled = true;
            btn_Ir_Siguiente.IsEnabled = true;
            btn_Ir_Ultimo.IsEnabled = true;
        }

        /// <summary>
        /// VALIDAR ERRORES AL GUARDAR
        /// </summary>
        private int _noOfErrorsOnScreen = 0;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void AddUser_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void AddUser_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btnGuardarUsu_Click();
            e.Handled = true;

        }

     
    }
}
