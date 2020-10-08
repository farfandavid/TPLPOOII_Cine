﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase.TrabajarABM {
    public class ABMSala {
        public DataTable cargar_salas() {
            SqlConnection c = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Sala";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = c;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;

        }

        public static void nueva_sala(Sala sala) {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPSalaAgregar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            cmd.Parameters.AddWithValue("@desS", sala.Sala_Descripcion);
            cmd.Parameters.AddWithValue("@capS", sala.Sala_Capacidad);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        public static void modificar_sala(Sala sala) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPSalaModificar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@idS", sala.Sala_ID);
            cmd.Parameters.AddWithValue("@desS", sala.Sala_Descripcion);
            cmd.Parameters.AddWithValue("@capS", sala.Sala_Capacidad);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public static void eliminar_sala(Sala sala) {
            SqlConnection conexion = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPSalaEliminar";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            cmd.Parameters.AddWithValue("@idS", sala.Sala_ID);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}