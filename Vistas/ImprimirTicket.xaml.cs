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
using ClasesBase;

namespace Vistas {
    /// <summary>
    /// Lógica de interacción para ImprimirTicket.xaml
    /// </summary>
    public partial class ImprimirTicket : UserControl {


        int codi = 0;
        public ImprimirTicket(string but, string vendedor, Proyeccion proyec, Pelicula pel, Cliente cliente, Ticket ticket) {
            InitializeComponent();
            //Ticket
            txbIdTicket.Text += ticket.Tick_ID;
            txbFecha.Text += DateTime.Now.Date;
            txbHora.Text += DateTime.Now.TimeOfDay;
            //Proyeccion
            txbPelicula.Text += pel.Peli_Titulo;
            txbFechaProy.Text += proyec.Proy_Fecha.ToString();
            txbHoraProy.Text += proyec.Proy_Hora;
            txbButaca.Text += but;
            //cliente
            txbNombre.Text += cliente.Cli_Nombre;
            txbApellido.Text += cliente.Cli_Apellido;
            txbDNI.Text += cliente.Cli_DNI;
            //vendedor
            txbVendedor.Text += vendedor;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            //Ticket
            txbIdTicket.Text += codi.ToString();
            txbFecha.Text += "";
            txbHora.Text += "";
            //Proyeccion
            txbPelicula.Text += "";
            txbFechaProy.Text += "";
            txbHoraProy.Text += "";
            txbButaca.Text += "";
            //cliente
            txbNombre.Text += "";
            txbApellido.Text += "";
            txbDNI.Text += "";
            //vendedor
            txbVendedor.Text += "";
        }
    }
}
