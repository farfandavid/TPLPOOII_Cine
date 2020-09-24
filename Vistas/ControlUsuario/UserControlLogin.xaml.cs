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

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
        }
        private void btnAcept_Click(object sender, RoutedEventArgs e)
        {

            if ((txtUserName.Text == "admin" && passBoxInicio.Password.ToString() == "12345") || (txtUserName.Text == "vend" && passBoxInicio.Password.ToString() == "12345"))
            {
                WinMenuAdmin atrWinMenu = new WinMenuAdmin(txtUserName.Text);
                atrWinMenu.Show();
                txtUserName.Text = "";
                passBoxInicio.Password = "";
            }
            else
            {
                error.IsOpen = true;
            }

        }
    }
}
