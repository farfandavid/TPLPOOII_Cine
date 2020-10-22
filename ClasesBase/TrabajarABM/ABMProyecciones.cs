using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClasesBase.TrabajarABM
{
    public class ABMProyecciones
    {
        public static DataTable traerProyeccion()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Proyeccion";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }

        public static void agregarProyecciones(Proyeccion proyeccion)
        {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert_proyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@cod_peli", proyeccion.Peli_Codigo);
            cmd.Parameters.AddWithValue("@fecha", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@hora", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@sala_id", proyeccion.Sala_ID);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static void editarProyeccion(Proyeccion proyeccion)
        {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "edit_proyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@cod", proyeccion.Proy_Codigo);
            cmd.Parameters.AddWithValue("@cod_peli", proyeccion.Peli_Codigo);
            cmd.Parameters.AddWithValue("@fecha", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@hora", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@sala_id", proyeccion.Sala_ID);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static void eliminarProyeccion(Proyeccion proyeccion)
        {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "eliminar_proyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@cod", proyeccion.Proy_Codigo);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
