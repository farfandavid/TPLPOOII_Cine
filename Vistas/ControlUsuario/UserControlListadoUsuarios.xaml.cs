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

            if (usuario.Usu_NombreUsuario.StartsWith(txtUserName.Text, StringComparison.CurrentCultureIgnoreCase)) {
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

        private void btnVistaPrevia_Click(object sender, RoutedEventArgs e)
        {
            flowdoc doc = new flowdoc(txtUserName.Text);
            doc.Show();
        }

          //  <Grid>
          //  <Grid.RowDefinitions>
          //      <RowDefinition Height = "30" />
          //      < RowDefinition Height="80"/>
          //      <RowDefinition Height = "*" />
          //  </ Grid.RowDefinitions >
         //   < Border Grid.Row="0" Background="Transparent" MouseLeftButtonDown="Border_MouseLeftButtonDown">
         //       <Grid>
        //            <materialDesign:ColorZone Background = "#65b3f6" >
        //                < StackPanel HorizontalAlignment="Right">
        //                    <Button Width = "30" Height="30" materialDesign:ShadowAssist.ShadowDepth="Depth3" Padding="0" Click="btnClose_Click" Name="btnClose" Background="#FF4192D7">
        //                        <materialDesign:PackIcon Kind = "WindowClose" />
        //                    </ Button >
        //                </ StackPanel >
        //            </ materialDesign:ColorZone>
        //        </Grid>

        //    </Border>
        //    <Grid Grid.Row="1" >

        //        <Image Source = "/imagenes/Listado_Usuarios_xd.png" HorizontalAlignment= "Center" Margin= "46,0,105,0" />
        //        < Image Source= "/imagenes/Caballero_PNG.png" HorizontalAlignment= "Right" Margin= "0,0,15,0" />

        //    </ Grid >
        //    < Grid Grid.Row= "2" >
        //        < StackPanel Margin= "15" >
        //< FlowDocumentReader Height = "290" Width= "600" Name= "flowDoc" >
        //    < FlowDocument Name = "DocMain" >
        //        < !--< Paragraph FontFamily= "Impact" TextDecorations= "Underline" > Listado de Usuarios</Paragraph>-->
        //        <BlockUIContainer>
        //                        <ListView Name = "listUsuariosImprime" ItemsSource= "{Binding Source={StaticResource VISTA_USER}}" Margin= "10 0" >
        //                            < ListView.View >
        //                                < GridView >
        //                                    < GridViewColumn Header= "Codigo" Width= "115" DisplayMemberBinding= "{Binding Usu_Id}" />
        //                                    < GridViewColumn Header= "Apellido" Width= "115" DisplayMemberBinding= "{Binding Usu_ApellidoNombre}" />

        //                                    < GridViewColumn Header= "UserName" Width= "115" DisplayMemberBinding= "{Binding Usu_NombreUsuario}" />
        //                                    < GridViewColumn Header= "Password" Width= "115" DisplayMemberBinding= "{Binding Usu_Contraseña}" />
        //                                    < GridViewColumn Header= "Rol" Width= "115" DisplayMemberBinding= "{Binding Rol.Rol_Descripcion}" />
        //                                </ GridView >
        //                            </ ListView.View >
        //                        </ ListView >
        //        </ BlockUIContainer >
        //    </ FlowDocument >
        //</ FlowDocumentReader >

                    //< Button x:Name= "btnImprimir"  Style= "{DynamicResource MaterialDesignFlatButton}" Content= "Imprimir"  Click= "btnImprimir_Click" HorizontalAlignment= "Center" />
        //        </ StackPanel >
        //    </ Grid >
        //</ Grid >
    }

}
