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
        string aynUser = "";
        string idUser = "";
        public WinMenuAdmin(string rol, string ayn, string usuID)
        {
            rolUser = rol;
            aynUser = ayn;
            idUser = usuID;
            InitializeComponent();
            musica.LoadedBehavior = MediaState.Manual;
            string musicPath = System.IO.File.OpenRead("..//..//cancion//Everybody_Falls_Fall_Guys_Theme.mp3").Name.ToString();
            musica.Source = new Uri(musicPath);

            if (rolUser == "admin")
            {
                var menuUsuarios = new List<SubItem>();
                menuUsuarios.Add(new SubItem("ABM Usuarios", new UserControlDashboard()));
                menuUsuarios.Add(new SubItem("Listado de Usuarios", new UserControlListadoUsuarios()));
                
                var item0 = new ItemMenu("Gestionar Usuarios", menuUsuarios, PackIconKind.Face);

                var menuPeliculas = new List<SubItem>();
                menuPeliculas.Add(new SubItem("ABM Peliculas", new UserControlABMPeliculas()));
                menuPeliculas.Add(new SubItem("Proximamente"));
                
                var item1 = new ItemMenu("Gestionar Peliculas", menuPeliculas, PackIconKind.MovieFilter);

                var menuButacas = new List<SubItem>();
                menuButacas.Add(new SubItem("Asignacion de Butacas", new UserControlButacas()));
                menuButacas.Add(new SubItem("ABM Salas", new UserControlABMSalas()));
                
                var item2 = new ItemMenu("Gestionar Salas", menuButacas, PackIconKind.EventSeat);

                var menuProyecciones = new List<SubItem>();
                menuProyecciones.Add(new SubItem("ABM Proyecciones", new UserControlABMProyecciones()));
                menuProyecciones.Add(new SubItem("Listado Proyecciones", new UserControlListadoProyeccion()));
                
                var item3 = new ItemMenu("Gest. Proyecciones", menuProyecciones, PackIconKind.CameraRoll);

                var menuVentas = new List<SubItem>();
                menuVentas.Add(new SubItem("Control de Ventas", new UserControlVentas()));
                menuVentas.Add(new SubItem("Proximamente"));

                var item4 = new ItemMenu("Gestionar Ventas", menuVentas, PackIconKind.PointOfSale);

                Menu.Children.Add(new UserControlMenuItem(item0, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
                Menu.Children.Add(new UserControlMenuItem(item2, this));
                Menu.Children.Add(new UserControlMenuItem(item3, this));
                Menu.Children.Add(new UserControlMenuItem(item4, this));

            }
            else
            {
                var menuTickets = new List<SubItem>();
                menuTickets.Add(new SubItem("Venta de Tickets", new UserControlVentaTicket(aynUser, idUser)));
                menuTickets.Add(new SubItem("Proximamente"));
                
                var item4 = new ItemMenu("Gestionar Tickets", menuTickets, PackIconKind.LocalActivity);

                var menuClientes = new List<SubItem>();
                menuClientes.Add(new SubItem("ABM Clientes", new UserControlABMClientes()));
                menuClientes.Add(new SubItem("Validar Clientes", new UserControlValidarCliente()));
                
                var item5 = new ItemMenu("Gestionar Clientes", menuClientes, PackIconKind.Group);


                Menu.Children.Add(new UserControlMenuItem(item4, this));
                Menu.Children.Add(new UserControlMenuItem(item5, this));
            }


        }

        private void borde_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        internal void SwitchScreen(object sender) {
            var screen = ((UserControl)sender);

            if (screen != null) {
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

        private void btnParar_Click(object sender, RoutedEventArgs e)
        {
            musica.Pause();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            musica.Play();
        }
    }
}
