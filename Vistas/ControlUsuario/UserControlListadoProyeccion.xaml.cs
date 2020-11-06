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
    /// Lógica de interacción para UserControlListadoProyeccion.xaml
    /// </summary>
    public partial class UserControlListadoProyeccion : UserControl
    {
        public UserControlListadoProyeccion()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            trailer.LoadedBehavior = MediaState.Manual;
            //agregar los source de los videos xd
            trailer.Source = new Uri(@"", UriKind.Relative);
        }
        private void eventVistaUsuario_Filter(object sender, FilterEventArgs e)
        {

        }
        private void txtRol_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnIrPrimero_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIrAtras_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIrSiguiente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIrUltimo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            trailer.Play();
        }

        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            trailer.Stop();
        }

        
    }
}
