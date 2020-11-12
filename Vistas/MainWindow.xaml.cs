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
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            musica.LoadedBehavior = MediaState.Manual;
            musica.Source = new Uri(@"C:\Users\Cathy\Documents\GitHub\TPLPOOII_Cine\Vistas\cancion\Everybody_Falls_Fall_Guys_Theme.mp3");
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
