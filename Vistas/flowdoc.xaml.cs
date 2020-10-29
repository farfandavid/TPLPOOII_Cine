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
    /// Lógica de interacción para flowdoc.xaml
    /// </summary>
    public partial class flowdoc : Window
    {
        public flowdoc()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if(print.ShowDialog()== true)
            {
                print.PrintDocument(((IDocumentPaginatorSource)DocMain).DocumentPaginator, "Imprimir");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }

    
}
