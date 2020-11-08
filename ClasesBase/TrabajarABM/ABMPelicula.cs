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
            cmd.Parameters.AddWithValue("@duracion", pel.Peli_Duracion);
            cmd.Parameters.AddWithValue("@clase", pel.Peli_Clase);
            cmd.Parameters.AddWithValue("@genero", pel.Peli_Genero);
            cmd.Parameters.AddWithValue("@imagen", pel.Peli_Imagen);
            cmd.Parameters.AddWithValue("@trailer", pel.Peli_Trailer);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public static void editarPelicula(Pelicula pelicula) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPeliculaModificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@cod", pelicula.Peli_Codigo);
            cmd.Parameters.AddWithValue("@titulo", pelicula.Peli_Titulo);
            cmd.Parameters.AddWithValue("@genero", pelicula.Peli_Genero);
            cmd.Parameters.AddWithValue("@clase", pelicula.Peli_Clase);
            cmd.Parameters.AddWithValue("@duracion", pelicula.Peli_Duracion);
            cmd.Parameters.AddWithValue("@imagen", pelicula.Peli_Imagen);
            cmd.Parameters.AddWithValue("@trailer", pelicula.Peli_Trailer);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static void eliminarPelicula(Pelicula pelicula) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPeliculaEliminar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@cod", pelicula.Peli_Codigo);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
