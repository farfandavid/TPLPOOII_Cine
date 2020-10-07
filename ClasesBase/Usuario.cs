using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario
    {
        private int usu_Id;
        private String usu_NombreUsuario;
        private String usu_Contraseña;
        private String usu_ApellidoNombre;
        private int rol_Codigo;

        public int Usu_Id
        {
            get
            {
                return usu_Id;
            }

            set
            {
                usu_Id = value;
            }
        }

        public string Usu_NombreUsuario
        {
            get
            {
                return usu_NombreUsuario;
            }

            set
            {
                usu_NombreUsuario = value;
            }
        }

        public string Usu_Contraseña
        {
            get
            {
                return usu_Contraseña;
            }

            set
            {
                usu_Contraseña = value;
            }
        }

        public string Usu_ApellidoNombre
        {
            get
            {
                return usu_ApellidoNombre;
            }

            set
            {
                usu_ApellidoNombre = value;
            }
        }

        public int Rol_Codigo
        {
            get
            {
                return rol_Codigo;
            }

            set
            {
                rol_Codigo = value;
            }
        }
    }
}