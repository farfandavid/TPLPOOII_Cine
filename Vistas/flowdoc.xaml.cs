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
using ClasesBase;
using ClasesBase.TrabajarABM;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para flowdoc.xaml
    /// </summary>
    public partial class flowdoc : Window
    {

        CollectionViewSource vistaColeccionFiltrada;
        public flowdoc( string user)
        {
            InitializeComponent();
            listUsuarios.ItemsSource = ABMUsuario.traer_usuario_filtrado(user);
                vistaColeccionFiltrada = Resources["VISTA_USER"] as CollectionViewSource;
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true) {
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

       /* private void eventVistaUsuario_Filter(object sender, FilterEventArgs e) {
            Usuario usuario = e.Item as Usuario;

            if (usuario.Usu_NombreUsuario.StartsWith(txtUserName.Text, StringComparison.CurrentCultureIgnoreCase)) {
                e.Accepted = true;
            } else {
                e.Accepted = false;
            }

        }*/

      /*  private void txtUserName_TextChanged(object sender, TextChangedEventArgs e) {
            if (vistaColeccionFiltrada != null) {
                vistaColeccionFiltrada.Filter += eventVistaUsuario_Filter;
            }
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e) {

        }*/

        private void button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }

    
}
