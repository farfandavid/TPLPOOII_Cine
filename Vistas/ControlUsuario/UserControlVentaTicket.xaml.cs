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
    /// Lógica de interacción para UserControlVentaTicket.xaml
    /// </summary>
    public partial class UserControlVentaTicket : UserControl
    {
        public UserControlVentaTicket()
        {
            InitializeComponent();
        }

        private void btnConfirmarVenta_Click(object sender, RoutedEventArgs e)
        {
            WinSatckDoc ticket = new WinSatckDoc();
            ticket.Show();
        }
    }
}
