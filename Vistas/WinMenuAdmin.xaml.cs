using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
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
using Vistas.ControlUsuario;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WinMenuAdmin.xaml
    /// </summary>
    public partial class WinMenuAdmin : Window
    {
        string rolUser = "";
        public WinMenuAdmin(string rol)
        {
            rolUser = rol;
            InitializeComponent();

            if (rolUser == "admin")
            {
                var menuUsuarios = new List<SubItem>();
                menuUsuarios.Add(new SubItem("ejemplo prueba", new UserControlDashboard()));
                menuUsuarios.Add(new SubItem("algo 2"));
                menuUsuarios.Add(new SubItem("algo 3"));
                menuUsuarios.Add(new SubItem("algo 4"));
                var item0 = new ItemMenu("Gestionar Usuarios", menuUsuarios, PackIconKind.Face);

                var menuPeliculas = new List<SubItem>();
                menuPeliculas.Add(new SubItem("ABM Peliculas", new UserControlABMPeliculas()));
                menuPeliculas.Add(new SubItem("algo 2"));
                menuPeliculas.Add(new SubItem("algo 3"));
                menuPeliculas.Add(new SubItem("algo 4"));
                var item1 = new ItemMenu("Gestionar Peliculas", menuPeliculas, PackIconKind.MovieFilter);

                var menuButacas = new List<SubItem>();
                menuButacas.Add(new SubItem("Asignacion de Butacas", new UserControlButacas()));
                menuButacas.Add(new SubItem("algo 2"));
                menuButacas.Add(new SubItem("algo 3"));
                menuButacas.Add(new SubItem("algo 4"));
                var item2 = new ItemMenu("Gestionar Butacas", menuButacas, PackIconKind.EventSeat);

                var menuProyecciones = new List<SubItem>();
                menuProyecciones.Add(new SubItem("ABM Proyecciones", new UserControlABMProyecciones()));
                menuProyecciones.Add(new SubItem("algo 2"));
                menuProyecciones.Add(new SubItem("algo 3"));
                menuProyecciones.Add(new SubItem("algo 4"));
                var item3 = new ItemMenu("Gest. Proyecciones", menuProyecciones, PackIconKind.CameraRoll);

                Menu.Children.Add(new UserControlMenuItem(item0, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
                Menu.Children.Add(new UserControlMenuItem(item2, this));
                Menu.Children.Add(new UserControlMenuItem(item3, this));

            }
            else
            {
                var menuTickets = new List<SubItem>();
                menuTickets.Add(new SubItem("algo 1"));
                menuTickets.Add(new SubItem("algo 2"));
                menuTickets.Add(new SubItem("algo 3"));
                menuTickets.Add(new SubItem("algo 4"));
                var item4 = new ItemMenu("Gestionar Tickets", menuTickets, PackIconKind.LocalActivity);

                var menuClientes = new List<SubItem>();
                menuClientes.Add(new SubItem("ABM Clientes", new UserControlABMClientes()));
                menuClientes.Add(new SubItem("algo 2"));
                menuClientes.Add(new SubItem("algo 3"));
                menuClientes.Add(new SubItem("algo 4"));
                var item5 = new ItemMenu("Gestionar Clientes", menuClientes, PackIconKind.Group);


                Menu.Children.Add(new UserControlMenuItem(item4, this));
                Menu.Children.Add(new UserControlMenuItem(item5, this));
            }


        }

        private void borde_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void btnMenuClose_Click(object sender, RoutedEventArgs e)
        {
            cerrarSesion.IsOpen = true;

            Button btn = new Button();

            btn = sender as Button;

            if (btn.Name == "btnSalir"){

                Application.Current.Shutdown();
            }else if (btn.Name == "btnCerrarSesion")
            {
                this.Close();
                
            }
            //Application.Current.Shutdown();
        }
    }
}
