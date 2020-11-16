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
using System.Windows.Markup;

namespace Vistas.ControlUsuario {
    /// <summary>
    /// Lógica de interacción para UserControlVentaTicket.xaml
    /// </summary>
    public partial class UserControlVentaTicket : UserControl {

        string usuarioV = "";
        string idVende = "";
        int filas = 0;
        int columnas = 0;
        string nombre = "";
        string letra = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        List<Button> listBtn = new List<Button>();
        List<int> listButaca = new List<int>();

        Ticket oTicket = new Ticket();
        Venta oVenta = new Venta();
        Cliente oCliente = new Cliente();
        Proyeccion oProyeccion = new Proyeccion();
        Pelicula oPelicula = new Pelicula();
        Butaca oButaca = new Butaca();




        public UserControlVentaTicket(string vendedor, string idVendedor) {
            InitializeComponent();
            Ticket oTicket = new Ticket();
            Venta oVenta = new Venta();
            Cliente oCliente = new Cliente();
            Proyeccion oProyeccion = new Proyeccion();
            Pelicula oPelicula = new Pelicula();
            Butaca oButaca = new Butaca();
            usuarioV = vendedor;
            idVende = idVendedor;
            generar_Butacas();

        }

        private void btnConfirmarVenta_Click(object sender, RoutedEventArgs e) {

            //vender_ticket();
            PrintDialog printTicket = new PrintDialog();

            printTicket.ShowDialog();
            var pageSize = new Size(7.26 * 96, 4.69 * 96); // A4 page, at 96 dpi
            var document = new FixedDocument();
           
            if (vender_ticket()) {
                oTicket.Tick_precio = int.Parse(txtPrecioTicket.Text.ToString());
                for (int i = 0; i < listButaca.Count; i++) {
                    string butaca = listBtn[listButaca[i]].Content.ToString();
                    oTicket.But_ID = int.Parse(ABMButaca.obtener_butaca(oProyeccion.Sala_ID.ToString()).Rows[listButaca[i]]["but_ID"].ToString());
                    oTicket.Tick_ID = int.Parse(ABMTicket.obtener_ticket(oProyeccion.Proy_Codigo, oTicket.But_ID).Rows[0]["tick_ID"].ToString());
                    
                    MessageBox.Show(butaca);
                    // Create FixedPage
                    var fixedPage = new FixedPage();
                    fixedPage.Width = pageSize.Width;
                    fixedPage.Height = pageSize.Height;
                    ImprimirTicket miTicket = new ImprimirTicket(butaca, usuarioV, oProyeccion, oPelicula, oCliente, oTicket);

                    // Add visual, measure/arrange page.
                    fixedPage.Children.Add((UIElement)miTicket);
                    fixedPage.Measure(pageSize);
                    fixedPage.Arrange(new Rect(new Point(), pageSize));
                    fixedPage.UpdateLayout();

                    // Add page to document
                    var pageContent = new PageContent();
                    ((IAddChild)pageContent).AddChild(fixedPage);
                    document.Pages.Add(pageContent);
                }
                
                printTicket.PrintDocument(document.DocumentPaginator, "Mi Ticket");
                vistaImpresion.IsOpen = false;
                listButaca.Clear();
            }


        }



        private void generar_Butacas() {
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
        }

        private void vender_butaca(Object sender, EventArgs e) {
            Button clickedButton = (Button)sender;
            //MessageBox.Show(clickedButton.Background.ToString());
            if (clickedButton.Background.ToString() == "#FF008000") {
                clickedButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF673AB7"));
                listButaca.Remove(listBtn.IndexOf(clickedButton));
            } else if (clickedButton.Background.ToString() == "#FF673AB7") {
                clickedButton.Background = new SolidColorBrush(Colors.Green);
                listButaca.Add(listBtn.IndexOf(clickedButton));
            }

        }

        private void cargarComboBox() {
            cmbProy.DisplayMemberPath = "Proy";
            cmbProy.SelectedValuePath = "proy_Codigo";
            cmbProy.ItemsSource = ABMProyeccion.traerProyeccionEstreno().DefaultView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            cargarComboBox();
            GridCentral.Children.Clear();
            
        }

        private void cmbProy_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            DataTable dt = ABMProyeccion.traerProyeccionEstreno();
            if (cmbProy.SelectedIndex != -1) {
                oProyeccion = new Proyeccion();
                oProyeccion.Proy_Codigo = Int32.Parse(dt.Rows[cmbProy.SelectedIndex]["proy_Codigo"].ToString());
                oProyeccion.Proy_Fecha = Convert.ToDateTime(dt.Rows[cmbProy.SelectedIndex]["proy_Fecha"].ToString());
                oProyeccion.Proy_Hora = dt.Rows[cmbProy.SelectedIndex]["proy_Hora"].ToString();
                oProyeccion.Sala_ID = Int32.Parse(dt.Rows[cmbProy.SelectedIndex]["sala_ID"].ToString());

                oPelicula = new Pelicula();
                oPelicula.Peli_Titulo = dt.Rows[cmbProy.SelectedIndex]["peli_Titulo"].ToString();

                oProyeccion.Pelicula = oPelicula;

                oTicket = new Ticket();
                oTicket.Proyeccion = oProyeccion;

                oVenta.Ticket = oTicket;

                this.filas = Int32.Parse(dt.Rows[cmbProy.SelectedIndex]["sala_DimensionFil"].ToString());
                this.columnas = Int32.Parse(dt.Rows[cmbProy.SelectedIndex]["sala_DimensionCol"].ToString());



                txtProy_Fecha.SelectedDate = DateTime.Parse(dt.Rows[cmbProy.SelectedIndex]["proy_Fecha"].ToString());
                txtProy_Hora.SelectedTime = DateTime.Parse(dt.Rows[cmbProy.SelectedIndex]["proy_Hora"].ToString());


                GridCentral.Children.Clear();
                listBtn.Clear();

                generar_Butacas();

                ocuparButaca();
            }

        }

        private void ocuparButaca() {
            DataTable dtp = ABMProyeccion.traerProyeccionEstreno();
            DataTable dt = ABMTicket.cargar_ticket(dtp.Rows[cmbProy.SelectedIndex]["proy_Codigo"].ToString());
            txtPrecioTicket.Text = dt.Rows[0]["tick_Precio"].ToString();
            int capacidad = filas * columnas;
            if (dt.Rows.Count >= 1) {
                for (int i = 1; i <= capacidad; i++) {
                    if (dt.Rows[i - 1]["tick_Estado"].ToString() == "VENDIDO") {
                        listBtn[i - 1].Background = new SolidColorBrush(Colors.Red);

                    }
                }

            }
        }

        private bool vender_ticket() {
            bool vendido = false;
            if (txtApellido.Text != "" && cmbProy.SelectedIndex != -1) {
                for (int i = 0; i < listButaca.Count; i++) {
                    //MessageBox.Show(ABMButaca.obtener_butaca(oProyeccion.Sala_ID.ToString()).Rows[listButaca[i]]["but_ID"].ToString());
                    int NbutID = int.Parse(ABMButaca.obtener_butaca(oProyeccion.Sala_ID.ToString()).Rows[listButaca[i]]["but_ID"].ToString());
                    int NtickID = int.Parse(ABMTicket.obtener_ticket(oProyeccion.Proy_Codigo, NbutID).Rows[0]["tick_ID"].ToString());
                    oVenta.Tick_ID = NtickID;
                    oTicket.But_ID = NbutID;
                    oTicket.Tick_ID = NtickID;

                    oVenta.Usu_ID = int.Parse(this.idVende);
                    ABMTicket.modificar_ticket(oTicket);
                    ABMVenta.nueva_venta(oVenta);

                    GridCentral.Children.Clear();
                    listBtn.Clear();

                    generar_Butacas();

                    ocuparButaca();
                    vendido = true;
                }
                //listButaca.Clear();
            }else {
                MessageBox.Show("Complete los Campos");
            }
            return vendido;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            oCliente = new Cliente();
            DataTable dt = new DataTable();
            try {
                dt = ABMCliente.buscarCli_DNI(txtDNI.Text);
                DataRow row = dt.Rows[0];

                oCliente.Cli_ID = int.Parse(row[0].ToString());
                oCliente.Cli_DNI = row[3].ToString();
                oCliente.Cli_Nombre = row[2].ToString();
                oCliente.Cli_Apellido = row[1].ToString();

                oVenta.Cli_ID = oCliente.Cli_ID;

                txtNombre.Text = row[2].ToString();
                txtApellido.Text = row[1].ToString();
            } catch {
                MessageBox.Show("Cliente no Registrado");
            }
        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e) {
            vistaImpresion.IsOpen = true;
        }
        
    }
}
