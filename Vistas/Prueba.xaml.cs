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

namespace Vistas {
    /// <summary>
    /// Lógica de interacción para Prueba.xaml
    /// </summary>
    public partial class Prueba : Window {
        public Prueba() {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, RoutedEventArgs e) {
            ABMCliente.buscarCli_DNI(dnicliente.Text);
        }
    }
}
