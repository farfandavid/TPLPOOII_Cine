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
using System.Collections.ObjectModel;

namespace Vistas.ControlUsuario {
    /// <summary>
    /// Lógica de interacción para UserControlABMProyecciones.xaml
    /// </summary>
    public partial class UserControlABMProyecciones : UserControl {

        ObservableCollection<Proyeccion> lista_proyeccion = new ObservableCollection<ClasesBase.Proyeccion>();
        Proyeccion proyec = new Proyeccion();

        public UserControlABMProyecciones() {
            InitializeComponent();
            txtProy_Fecha.DisplayDateStart = DateTime.Today;
        }

        private async void btnAgregarProy_Click(object sender, RoutedEventArgs e) {
            if (txtProy_Fecha.SelectedDate != null && txtProy_Hora.SelectedTime.ToString() != "" && txtPrecioTicket.Text != ""
                && cmbNroSala.SelectedIndex != -1) {
                proyec.Proy_Fecha = DateTime.Parse(txtProy_Fecha.ToString());
                proyec.Proy_Hora = txtProy_Hora.Text;
                proyec.Peli_Codigo = int.Parse(cmbPeli.SelectedValue.ToString());
                proyec.Sala_ID = int.Parse(cmbNroSala.SelectedValue.ToString());
                Ticket oTicket = new Ticket();
                oTicket.Tick_precio = int.Parse(txtPrecioTicket.Text);
                //ABMProyeccion.agregarProyecciones(proyec);
                await Task.Run(async () => {

                    Task<int> result = ABMProyeccion.agregarProyecciones(proyec);
                    int aasd = await result;

                }).ContinueWith((mostrar) => {

                    
                    int pCount = ABMProyeccion.traerProyeccion().Rows.Count;
                    int cantidad = ABMButaca.obtener_butaca(proyec.Sala_ID.ToString()).Rows.Count;

                    oTicket.Proy_ID = int.Parse(ABMProyeccion.traerProyeccion().Rows[pCount - 1]["proy_Codigo"].ToString());
                    oTicket.But_ID = int.Parse(ABMButaca.obtener_butaca(proyec.Sala_ID.ToString()).Rows[0]["but_ID"].ToString());
                    

                    ABMTicket.nuevo_ticket(oTicket, cantidad);
                    //MessageBox.Show(ABMSala.cargar_salas().Rows[ABMSala.cargar_salas().Rows.Count - 1]["sala_iD"].ToString());
                });

                cargar_listView();
                vaciarCampos();
            } else {
                MessageBox.Show("Llenar Campos");
            }
            


        }

        private void vaciarCampos()
        {
            txtProy_Codigo.Text = null;
            txtProy_Fecha.SelectedDate = null;
            txtProy_Hora.SelectedTime = null;
            cmbNroSala.SelectedValue = null;
            cmbPeli.SelectedValue = null;
        }
        
        private void cargar_comboBox() {
            cmbPeli.DisplayMemberPath = "peli_Titulo";
            cmbPeli.SelectedValuePath = "peli_Codigo";
            cmbPeli.ItemsSource = ABMPelicula.traerPelicula().DefaultView;

            cmbNroSala.DisplayMemberPath = "sala_Descripcion";
            cmbNroSala.SelectedValuePath = "sala_ID";
            cmbNroSala.ItemsSource = ABMSala.cargar_salas().DefaultView;
        }

        private void cargar_listView() {
            ABMProyeccion abmpr = new ABMProyeccion();
            dgListadoProyecciones.ItemsSource = abmpr.traer_viewProy();
        }

        private void btnEliminarProy_Click(object sender, RoutedEventArgs e)
        {
            if (dgListadoProyecciones.SelectedItem != null) {
                try {
                    if (MessageBox.Show("Seguro quiere eliminarlo", "Importante!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        ABMTicket.eliminarTicket(proyec);
                        ABMProyeccion.eliminarProyeccion(proyec);
                        MessageBox.Show("Eliminado");
                        cargar_listView();
                    }
                } catch(Exception ex) {

                    if (ex.HResult == -2146232060) {
                        MessageBox.Show("Error: Ticket de la Proyeccion ha sido vendido");
                    } else {
                        MessageBox.Show(ex.Message);
                    }
                }
            } else {
                MessageBox.Show("Selecciones una fila");
            }
            
        }

        private void btnModificarProy_Click(object sender, RoutedEventArgs e)
        {
            if (dgListadoProyecciones.SelectedItem != null) {
                try {
                    proyec.Proy_Fecha = DateTime.Parse(txtProy_Fecha.ToString());
                    proyec.Proy_Hora = txtProy_Hora.Text;
                    proyec.Peli_Codigo = int.Parse(cmbPeli.SelectedValue.ToString());
                    proyec.Sala_ID = int.Parse(cmbNroSala.SelectedValue.ToString());
                    if (MessageBox.Show("Seguro quiere eliminarlo", "Importante!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        ABMProyeccion.editarProyeccion(proyec);
                        MessageBox.Show("Modificado");
                        cargar_listView();
                    }
                } catch {
                    MessageBox.Show("error");
                }
            }else {
                MessageBox.Show("Selecciones una fila");
            }
        }

        private void dgListadoProyecciones_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            proyec = new Proyeccion(); 
            if (dgListadoProyecciones.SelectedItem != null) {
                proyec = dgListadoProyecciones.SelectedItem as Proyeccion;

                txtProy_Codigo.Text = proyec.Proy_Codigo.ToString();
                txtProy_Fecha.Text = proyec.Proy_Fecha.ToString();
                txtProy_Hora.Text = proyec.Proy_Hora;
                cmbPeli.SelectedValue = proyec.Peli_Codigo;
                cmbNroSala.SelectedValue = proyec.Sala_ID;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e) {
            cargar_comboBox();
        }
    }
}
