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
using System.Windows.Shapes;
namespace Vistas {
    /// <summary>
    /// Interaction logic for WinWelcome.xaml
    /// </summary>
    public partial class WinLogin: Window {
        public WinLogin() {
            InitializeComponent();
        }

        private void btn_Aceptar_Click( object sender, RoutedEventArgs e ) {
            if((textUsername.Text == "admin" && textPassword.Text == "admin") || (textUsername.Text == "vende" && textPassword.Text == "vende")){
                WinMain mainform = new WinMain(textUsername.Text);
                mainform.Show();
            } else {
                MessageBox.Show("Datos Incorrectos");
            }
        }
    }
}
