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
using ClasesBase.TrabajarABM;
using System.Data;

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlVentaTicket.xaml
    /// </summary>
    public partial class UserControlVentaTicket : UserControl
    {


        int filas = 0;
        int columnas = 0;
        string nombre = "";
        string letra = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        List<Button> listBtn = new List<Button>();
        List<string> listVenta = new List<string>();

        Ticket oTicket = new Ticket();
        Venta oVenta = new Venta();


        public UserControlVentaTicket()
        {
            InitializeComponent();
            Task.Run(async() => {
                await generar_Butacas();
            });
            
        }

        private void btnConfirmarVenta_Click(object sender, RoutedEventArgs e)
        {
            //WinSatckDoc ticket = new WinSatckDoc();
            //ticket.Show();
        }

        private async Task<int> generar_Butacas() {
            await Dispatcher.BeginInvoke(new Action(() => {
                Grid DynamicGrid = new Grid();
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Center;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;

            DynamicGrid.Margin = new Thickness(5);
            // CREAR FILAS
            for (int i = 0; i < filas; i++) {
                nombre = "GridRow" + i;
                RowDefinition gridRow = new RowDefinition();
                gridRow.Name = nombre;
                gridRow.Height = new GridLength(30);
                DynamicGrid.RowDefinitions.Add(gridRow);
            }
            // CREAR COLUMNAS
            for (int j = 0; j < columnas; j++) {
                nombre = "GridCol" + j;
                ColumnDefinition GridCol = new ColumnDefinition();
                GridCol.Name = nombre;
                GridCol.Width = new GridLength(30);
                DynamicGrid.ColumnDefinitions.Add(GridCol);

            }
            // CREAR BOTONES
            for (int i = 0; i < filas; i++) {
                for (int j = 1; j < columnas + 1; j++) {
                    Button btn = new Button();
                    btn.BorderThickness = new Thickness(2);
                    btn.Margin = new Thickness(1);
                    btn.Padding = new Thickness(0);
                    btn.Content = letra[i] + j.ToString();
                    btn.Name = "btn" + i.ToString() + j.ToString();
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j - 1);
                    DynamicGrid.Children.Add(btn);
                    btn.Click += vender_butaca;
                    listBtn.Add(btn);
                }
            }
            // AGREGAR GRID CREADO AL GRID CENTRAL
            GridCentral.Children.Add(DynamicGrid);
            }));
            return 1;
        }

        private void vender_butaca(Object sender, EventArgs e) {
            Button clickedButton = (Button)sender;
            //MessageBox.Show(clickedButton.Background.ToString());
            if (clickedButton.Background.ToString() == "#FF008000") {
                clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF673AB7"));
            } else if (clickedButton.Background.ToString() == "#FF673AB7") {
                clickedButton.Background = new SolidColorBrush(Colors.Green);
                listVenta.Add(listBtn.IndexOf(clickedButton).ToString());
            }

        }

        private void cargarComboBox() {
            cmbProy.DisplayMemberPath = "Proy";
            cmbProy.SelectedValuePath = "proy_Codigo";
            cmbProy.ItemsSource = ABMProyeccion.traerProyeccion().DefaultView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            cargarComboBox();
        }

        private async void cmbProy_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            DataTable dt = ABMProyeccion.traerProyeccion();

            this.filas = Int32.Parse(dt.Rows[cmbProy.SelectedIndex]["sala_DimensionFil"].ToString());
            this.columnas = Int32.Parse(dt.Rows[cmbProy.SelectedIndex]["sala_DimensionCol"].ToString());
            txtProy_Fecha.SelectedDate = DateTime.Parse(dt.Rows[cmbProy.SelectedIndex]["proy_Fecha"].ToString());
            txtProy_Hora.SelectedTime = DateTime.Parse(dt.Rows[cmbProy.SelectedIndex]["proy_Hora"].ToString());

            GridCentral.Children.Clear();
            listBtn.Clear();

            await generar_Butacas();

            await ocuparButaca();
        }

        private async Task<int> ocuparButaca() {
            await Dispatcher.BeginInvoke(new Action(() => {
                DataTable dtp = ABMProyeccion.traerProyeccion();
                DataTable dt = ABMTicket.cargar_ticket(dtp.Rows[cmbProy.SelectedIndex]["proy_Codigo"].ToString());
                int capacidad = filas * columnas;
                if (dt.Rows.Count >= 1) {
                        for (int i = 1; i <= capacidad; i++) {
                            if (dt.Rows[i - 1]["tick_Estado"].ToString() == "VENDIDO") {
                                    listBtn[i - 1].Background = new SolidColorBrush(Colors.Red);

                            }
                        }

                }
            }));
            return 0;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e) {
            DataTable dt = new DataTable();
            try {
                dt = ABMCliente.buscarCli_DNI(txtDNI.Text);
                DataRow row = dt.Rows[0];
                oVenta.Cli_ID = int.Parse(row[0].ToString());
                txtNombre.Text = row[2].ToString();
                txtApellido.Text = row[1].ToString();
            } catch {
                MessageBox.Show("Cliente no Registrado");
            }
        }
    }
}
