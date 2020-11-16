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
using System.Data;
using System.Text.RegularExpressions;
using ClasesBase;
using ClasesBase.TrabajarABM;

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlABMSalas.xaml
    /// </summary>
    public partial class UserControlABMSalas : UserControl
    {
        int filas = 0;
        int columnas = 0;
        string nombre = "";
        string letra = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public UserControlABMSalas()
        {
            InitializeComponent();
            generar_Butacas();
        }

        private async void btnAgregarProy_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            Sala oSala = new Sala();

       
            if(txtSala_Definicion.Text!="" && cmbTipo.SelectedValue != null && filas != 0 && columnas != 0) {
                oSala.Sala_Descripcion = txtSala_Definicion.Text + " " + cmbTipo.SelectedValue.ToString();
                oSala.Sala_DimensionCol = Int32.Parse(txtSala_Columnas.Text);
                oSala.Sala_DimensionFil = Int32.Parse(txtSala_Filas.Text);
                await Task.Run(async () => {

                    Task<int> result = ABMSala.nueva_sala(oSala);
                    int aasd = await result;

                }).ContinueWith((mostrar) => {

                    oSala.Sala_ID = int.Parse(ABMSala.cargar_salas().Rows[ABMSala.cargar_salas().Rows.Count - 1]["sala_iD"].ToString());
                    ABMButaca.crear_butacas(oSala);
                    MessageBox.Show("Sala Agregada");
                    
                    
                });
                cargarCombo();
                vaciarCampos();
            } else {
                MessageBox.Show("Complete todos los campos");
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
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j - 1);
                    DynamicGrid.Children.Add(btn);
                }
            }
            // AGREGAR GRID CREADO AL GRID CENTRAL
            GridCentral.Children.Add(DynamicGrid);

        }

        private void txtSala_Filas_TextChanged(object sender, TextChangedEventArgs e) {
            if (txtSala_Filas.Text != "") {
                if(Int32.Parse(txtSala_Filas.Text)<13) {
                    filas = Int32.Parse(txtSala_Filas.Text);

                    GridCentral.Children.Clear();
                    generar_Butacas();
                }else {
                    txtSala_Filas.Text = "12";
                }
                
            }
        }

        private void txtSala_Columnas_TextChanged(object sender, TextChangedEventArgs e) {
            if (txtSala_Columnas.Text != "") {
                if (Int32.Parse(txtSala_Columnas.Text) < 13) {
                    columnas = Int32.Parse(txtSala_Columnas.Text);

                    GridCentral.Children.Clear();
                    generar_Butacas();
                }else {
                    txtSala_Columnas.Text = "12";
                }
                

            }
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text) {
            return !_regex.IsMatch(text);
        }

        private void txtSala_Filas_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void cmbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbTipo.SelectedValue.ToString() == "2D") {
                
                txtSala_Filas.Text = "5";
                txtSala_Columnas.Text = "7";
            }
            if (cmbTipo.SelectedValue.ToString() == "3D") {
                txtSala_Filas.Text = "5";
                txtSala_Columnas.Text = "5";
            }
        }

        private void cargarCombo() {
            cmbVisualizarSala.DisplayMemberPath = "sala_Descripcion";
            cmbVisualizarSala.SelectedValuePath = "sala_ID";
            cmbVisualizarSala.ItemsSource = ABMSala.cargar_salas().DefaultView;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            cargarCombo();
        }

        private void cmbVisualizarSala_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var dtsala = ABMSala.cargar_salas();

            //filas = int.Parse(dtsala.Rows[cmbVisualizarSala.SelectedIndex]["sala_DimensionFil"].ToString());
            //columnas = int.Parse(dtsala.Rows[cmbVisualizarSala.SelectedIndex]["sala_DimensionCol"].ToString());
            if (cmbVisualizarSala.SelectedIndex != -1) {
                txtSala_Columnas.Text = dtsala.Rows[cmbVisualizarSala.SelectedIndex]["sala_DimensionCol"].ToString();
                txtSala_Filas.Text = dtsala.Rows[cmbVisualizarSala.SelectedIndex]["sala_DimensionFil"].ToString();

                GridCentral.Children.Clear();
                generar_Butacas();
            }
            
        }

        private void vaciarCampos() {
            txtSala_Definicion.Text = "";
            cmbTipo.SelectedValue = null;
            txtSala_Filas.Text = "0";
            txtSala_Columnas.Text = "0";
            
        }
    }
}
