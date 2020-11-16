using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ClasesBase.TrabajarABM {
    public class ABMProyeccion: INotifyCollectionChanged, INotifyPropertyChanged {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Proyeccion> traer_viewProy() {
            ObservableCollection<Proyeccion> lista_proyeccion = new ObservableCollection<Proyeccion>();
            DataTable dt = new DataTable();
            dt = traerProyeccion();

            for (int i = 0; i < dt.Rows.Count; i++) {
                Proyeccion oProy = new Proyeccion();
                Pelicula oPelicula = new Pelicula();
                Sala oSala = new Sala();

                oProy.Proy_Codigo = Convert.ToInt32(dt.Rows[i]["proy_Codigo"].ToString());
                oProy.Proy_Fecha = DateTime.Parse(dt.Rows[i]["proy_Fecha"].ToString());
                oProy.Proy_Hora = dt.Rows[i]["proy_Hora"].ToString();

                oProy.Peli_Codigo = Convert.ToInt32(dt.Rows[i]["peli_Codigo"].ToString());
                oPelicula.Peli_Titulo = dt.Rows[i]["peli_Titulo"].ToString();
                oPelicula.Peli_Imagen = dt.Rows[i]["peli_Imagen"].ToString();
                oPelicula.Peli_Trailer = dt.Rows[i]["peli_Trailer"].ToString();

                oProy.Sala_ID = Convert.ToInt32(dt.Rows[i]["sala_ID"].ToString());
                oSala.Sala_Descripcion = dt.Rows[i]["sala_Descripcion"].ToString();

                oProy.Sala = oSala;
                oProy.Pelicula = oPelicula;

                lista_proyeccion.Add(oProy);
            }
            if (CollectionChanged != null) {
                CollectionChanged(lista_proyeccion, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
            return lista_proyeccion;
        }

        public static DataTable traerProyeccion() {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM ViewProyeccionPelSal";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }
        public static DataTable traerProyeccionEstreno() {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPProyeccionEstreno";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }
        public async static Task<int> agregarProyecciones(Proyeccion proyeccion) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPProyeccionAgregar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@pelID", proyeccion.Peli_Codigo);
            cmd.Parameters.AddWithValue("@prFec", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@prHor", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@sID", proyeccion.Sala_ID);

            conexion.Open();
            return await cmd.ExecuteNonQueryAsync();
            conexion.Close();
        }

        public static void editarProyeccion(Proyeccion proyeccion) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPProyeccionModificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@prID", proyeccion.Proy_Codigo);
            cmd.Parameters.AddWithValue("@pelID", proyeccion.Peli_Codigo);
            cmd.Parameters.AddWithValue("@prFec", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@prHor", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@sID", proyeccion.Sala_ID);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static void eliminarProyeccion(Proyeccion proyeccion) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPProyeccionEliminar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@prID", proyeccion.Proy_Codigo);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
