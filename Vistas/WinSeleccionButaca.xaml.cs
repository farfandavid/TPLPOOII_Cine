using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vistas {
    /// <summary>
    /// Interaction logic for WinSeleccionButaca.xaml
    /// </summary>
    public partial class WinSeleccionButaca: Window {
        //public ObservableCollection<string> Seats {
        //    get;
        //    private set;
        //}

        int fila = 6;
        int col = 10;
        
        public WinSeleccionButaca() {
            //Seats = new ObservableCollection<string>();
            string abcd = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int j = 0; j <= fila; j++) {
                for (int i = 1; i <= col; i++) {
                    
                    //Seats.Add(abcd[j]+i.ToString());
                }
            }
            InitializeComponent();

        }

        private void butaca_Click( object sender, RoutedEventArgs e ) {
            Button btn = new Button();
            btn = sender as Button;
            btn.Background = new SolidColorBrush(Colors.Green);
            //MessageBox.Show("mmmmm");
        }

        private void Seat_Click( object sender, RoutedEventArgs e ) {

        }

    }
}
