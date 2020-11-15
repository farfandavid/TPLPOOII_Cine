using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase.TrabajarABM {
    public class ABMVenta {
        public static void nueva_venta(Venta venta) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            DateTime hoy = DateTime.Now.Date;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPVentaAgregar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@cliID", venta.Cli_ID);
            cmd.Parameters.AddWithValue("@usuID", venta.Usu_ID);
            cmd.Parameters.AddWithValue("@tick_ID", venta.Tick_ID);
            cmd.Parameters.AddWithValue("@vtaFec", hoy);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static DataTable traer_venta() {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM ViewVenta";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static DataTable traer_ventaFecha() {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPVentaFecha";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static DataTable traer_ventaPelicula() {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPVentaPeli";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
    }
}
