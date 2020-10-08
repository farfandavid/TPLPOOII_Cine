using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase.TrabajarABM
{
    public class ABMPelicula
    {
        public static DataTable traerPelicula()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Pelicula";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }

        public static void agregar_Pelicula(Pelicula pel)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPeliculaAgregar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            
            cmd.Parameters.AddWithValue("@titulo", pel.Peli_Titulo);
            cmd.Parameters.AddWithValue("@genero", pel.Peli_Duracion);
            cmd.Parameters.AddWithValue("@clase", pel.Peli_Clase);
            cmd.Parameters.AddWithValue("@duracion", pel.Peli_Genero);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
