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
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para WinSatckDoc.xaml
    /// </summary>
    public partial class WinSatckDoc : Window
    {
        public WinSatckDoc()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ticket
            txbIdTicket.Text += "";
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

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true) {
                //print.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
            }
        }
    }
}
