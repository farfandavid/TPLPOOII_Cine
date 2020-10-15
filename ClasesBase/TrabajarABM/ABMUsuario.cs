using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase.TrabajarABM {
    public class ABMUsuario {

        public ObservableCollection<Usuario> traer_usuario() {
            ObservableCollection<Usuario> lista_usuario = new ObservableCollection<Usuario>();
            DataTable dt = new DataTable();
            dt = cargar_usuario();

            for (int i = 0; i < dt.Rows.Count; i++) {
                Usuario oUser = new Usuario();
                oUser.Usu_Id = Convert.ToInt32(dt.Rows[i]["usu_ID"]);
                oUser.Usu_NombreUsuario = dt.Rows[i]["usu_NombreUsuario"].ToString();
                oUser.Usu_Contraseña = dt.Rows[i]["usu_contraseña"].ToString();
                oUser.Usu_ApellidoNombre = dt.Rows[i]["usu_ApellidoNombre"].ToString();
                oUser.Rol_Codigo = Convert.ToInt32(dt.Rows[i]["rol_Codigo"]);
                lista_usuario.Add(oUser);
            }
            return lista_usuario;
        }

        public ObservableCollection<Usuario> traer_usuarioYrol() {
            ObservableCollection<Usuario> lista_usuario = new ObservableCollection<Usuario>();
            DataTable dt = new DataTable();
            dt = cargar_usuarioYrol();

            for (int i = 0; i < dt.Rows.Count; i++) {
                Usuario oUser = new Usuario();
                Rol oRol = new Rol();
                oUser.Usu_Id = Convert.ToInt32(dt.Rows[i]["usu_ID"]);
                oUser.Usu_NombreUsuario = dt.Rows[i]["usu_NombreUsuario"].ToString();
                oUser.Usu_Contraseña = dt.Rows[i]["usu_contraseña"].ToString();
                oUser.Usu_ApellidoNombre = dt.Rows[i]["usu_ApellidoNombre"].ToString();
                oUser.Rol_Codigo = Convert.ToInt32(dt.Rows[i]["rol_Codigo"]);
                oRol.Rol_Codigo = Convert.ToInt32(dt.Rows[i]["rol_Codigo"]);
                oRol.Rol_Descripcion = dt.Rows[i]["rol_descripcion"].ToString();
                oUser.Rol = oRol;
                lista_usuario.Add(oUser);
            }
            return lista_usuario;
        }

        public DataTable cargar_usuario() {
            SqlConnection c = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Usuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;

        }

        public DataTable cargar_usuarioYrol() {
            SqlConnection c = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM ViewUsuario";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;

        }

        public static void nuevo_usuario(Usuario usuario) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUsuarioAgregar";
            // cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@user", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@pass", usuario.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@ayp", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@codR", usuario.Rol_Codigo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        public static void modificar_usuario(Usuario usuario) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUsuarioModificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@idU", usuario.Usu_Id);
            cmd.Parameters.AddWithValue("@user", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@pass", usuario.Usu_Contraseña);
            cmd.Parameters.AddWithValue("@ayp", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@codR", usuario.Rol_Codigo);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static void eliminar_usuario(Usuario usuario) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUsuarioEliminar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@idU", usuario.Usu_Id);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
