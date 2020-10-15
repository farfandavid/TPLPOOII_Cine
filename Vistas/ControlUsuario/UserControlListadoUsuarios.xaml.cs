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

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlListadoUsuarios.xaml
    /// </summary>
    public partial class UserControlListadoUsuarios : UserControl
    {
        CollectionViewSource vistaColeccionFiltrada;
        public UserControlListadoUsuarios()
        {
            InitializeComponent();
            vistaColeccionFiltrada = Resources["VISTA_USER"] as CollectionViewSource;
        }

        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e) {
            Usuario usuario = e.Item as Usuario;

            if (usuario.Usu_NombreUsuario.StartsWith(txtRol.Text, StringComparison.CurrentCultureIgnoreCase)) {
                e.Accepted = true;
            } else {
                e.Accepted = false;
            }
        }

        private void txtRol_TextChanged(object sender, TextChangedEventArgs e) {
            if (vistaColeccionFiltrada != null) {
                vistaColeccionFiltrada.Filter += eventVistaUsuario_Filter;
            }
        }
    }


}
