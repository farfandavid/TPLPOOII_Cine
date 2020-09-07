using System;
using Vistas.Salas;
using Vistas.ABM;
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
    /// Interaction logic for WinMain.xaml
    /// </summary>
    public partial class WinMain: Window {
        
        string rolUser = "";

        public Visibility mostrar {
            get;
            set;
        }


        public WinMain(string rol) {
            rolUser = rol;
            InitializeComponent();
            if (rolUser == "admin") {
                //this.mostrar = Visibility.Collapsed;
                menuItem_ABMCli.Visibility = Visibility.Collapsed;
                menuItem_ticket.Visibility = Visibility.Collapsed;

            } else {
                menuItem_ABMUsu.Visibility = Visibility.Collapsed;
                menuItem_Peli.Visibility = Visibility.Collapsed;
                menuItem_Proy.Visibility = Visibility.Collapsed;
                menuItem_Sala.Visibility = Visibility.Collapsed;
            }
            
            
        }



        private void MenuItem_Click( object sender, RoutedEventArgs e ) {
            FrameMain.Navigate(new PageSeleccionButaca());
        }

        private void menuItem_ABMCli_Click( object sender, RoutedEventArgs e ) {
            FrameMain.Navigate(new ABMCliente());
        }

        private void MenuItem_Click_1( object sender, RoutedEventArgs e ) {
            FrameMain.Navigate(new ABMPeliculas());
        }

    }
}
