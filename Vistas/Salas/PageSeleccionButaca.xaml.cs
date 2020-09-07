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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Vistas.Salas {
    /// <summary>
    /// Interaction logic for PageSeleccionButaca.xaml
    /// </summary>
    public partial class PageSeleccionButaca: Page {

        public ObservableCollection<Button> Seats {
            get;
            private set;
        }

        public List<Button> Butaca {
            get;
            set;
        }

        int fila = 6;
        int col = 10;

        public PageSeleccionButaca() {
            //Seats = new ObservableCollection<Button>();
            Butaca = new List<Button>();
            string abcd = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int j = 0; j <= fila; j++) {
                for (int i = 1; i <= col; i++) {
                    Button btn = new Button();
                    btn.Width = 25;
                    btn.Height = 25;
                    btn.Background = new SolidColorBrush(Colors.LightGray);
                    btn.Name = "btn" + abcd[j] + i.ToString();
                    //if (btn.Name == "btnB3") {
                    //    btn.Background = new SolidColorBrush(Colors.Red);
                    //}
                    btn.Content = abcd[j] + i.ToString();
                    btn.Click += new RoutedEventHandler(butaca_Click);
                    Butaca.Add(btn);
                    
                }
            }
            InitializeComponent();
            Butaca.Find(x => x.Name == "btnB3").Background = new SolidColorBrush(Colors.Red);
            
        }

        private void butaca_Click( object sender, RoutedEventArgs e ) {
            Button btn = new Button();
            btn = sender as Button;
            if (btn.Background.ToString() == "#FF008000") {
                btn.Background = new SolidColorBrush(Colors.LightGray);
            } else if (btn.Background.ToString() == "#FFD3D3D3") {
                btn.Background = new SolidColorBrush(Colors.Green);
            }
        }

        private void StackPanel_Loaded( object sender, RoutedEventArgs e ) {
        }

            //public void definirGrid (){
            //    for (int i = 0; i < fila; i++ ) {
            //        RowDefinition rowdef = new RowDefinition();
            //        gridButacas.RowDefinitions.Add(rowdef);
            //    }
            //    for (int i = 0; i < col; i++) {
            //        ColumnDefinition coldef = new ColumnDefinition();
            //        gridButacas.ColumnDefinitions.Add(coldef);
            //    }
            //}
        
    }
}
