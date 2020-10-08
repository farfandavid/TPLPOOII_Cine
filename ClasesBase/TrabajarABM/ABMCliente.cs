using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase.TrabajarABM {
    public class ABMCliente {
        public static DataTable traerCliente() {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Cliente";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }

        public static void modificar_Cliente(Cliente cliente) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPClienteModificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@idCli", cliente.Cli_ID);
            cmd.Parameters.AddWithValue("@dniCli",cliente.Cli_DNI);
            cmd.Parameters.AddWithValue("@apeCli",cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nomCli",cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@emailCli",cliente.Cli_Email);
            cmd.Parameters.AddWithValue("@telCli",cliente.Cli_Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //Buscar Cliente por DNI
        public static DataTable buscarCli_DNI(string DNI) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPClienteBuscarDNI";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@clienteDNI",DNI);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public static void eliminar_cliente(Cliente cli) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPClienteEliminar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@idCli", cli.Cli_ID);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public static void agregar_cliente(Cliente cliente) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPClienteAgregar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            
            cmd.Parameters.AddWithValue("@dniCli", cliente.Cli_DNI);
            cmd.Parameters.AddWithValue("@apeCli", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nomCli", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@emailCli", cliente.Cli_Email);
            cmd.Parameters.AddWithValue("@telCli", cliente.Cli_Telefono);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public Cliente valCliente() {

            Cliente oCliente = new Cliente();

            oCliente.Cli_DNI = "";
            oCliente.Cli_Apellido = "";
            oCliente.Cli_Nombre = "";
            oCliente.Cli_Telefono = "";
            oCliente.Cli_Email = "";

            return oCliente;
        }
    }
}
