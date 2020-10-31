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
using System.Data;
using ClasesBase.TrabajarABM;


namespace Vistas.ControlUsuario {
    /// <summary>
    /// Lógica de interacción para UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl {

        public UserControlLogin() {
            InitializeComponent();
        }

        private void btnAcept_Click(object sender, RoutedEventArgs e) {
            int rol = 0;
            rol = validar(txtUserName.Text, passBoxInicio.Password.ToString());
            string tipo_rol = "";
            string ayn = "";
            string usuID = "";
            if (rol != 0) {
                ayn = ABMUsuario.obtener_rol(txtUserName.Text, passBoxInicio.Password.ToString()).Rows[0][1].ToString();
                usuID = ABMUsuario.obtener_rol(txtUserName.Text, passBoxInicio.Password.ToString()).Rows[0][2].ToString();
                if (rol == 1) {

                    tipo_rol = "admin";
                    ayn = ABMUsuario.obtener_rol(txtUserName.Text, passBoxInicio.Password.ToString()).Rows[0][1].ToString();
                    usuID = ABMUsuario.obtener_rol(txtUserName.Text, passBoxInicio.Password.ToString()).Rows[0][2].ToString();
                }
                WinMenuAdmin atrWinMenu = new WinMenuAdmin(tipo_rol, ayn, usuID);
                atrWinMenu.Show();
                txtUserName.Text = "";
                passBoxInicio.Password = "";
            } else {
                error.IsOpen = true;
            }
            //if ((txtUserName.Text == "admin" && passBoxInicio.Password.ToString() == "12345") || (txtUserName.Text == "vend" && passBoxInicio.Password.ToString() == "12345")) {
            //    WinMenuAdmin atrWinMenu = new WinMenuAdmin(txtUserName.Text);
            //    atrWinMenu.Show();
            //    txtUserName.Text = "";
            //    passBoxInicio.Password = "";
            //} else {
            //    error.IsOpen = true;
            //}

        }



        public int validar(string user, string pass) {
            int x = 0;
            DataTable dt = ABMUsuario.obtener_rol(user, pass);

            if (dt.Rows.Count == 1) {
                if (dt.Rows[0][0].ToString() == "1") {
                    return 1;
                } else {
                    if (dt.Rows[0][0].ToString() == "2") {
                        return 2;
                    }
                }
            } else {
                return 0;
            }
            return x;
        }
    }
}
