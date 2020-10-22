using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Pelicula
    {
        private String peli_Codigo;
        private String peli_Titulo;
        private String peli_Duracion;
        private String peli_Genero;
        private String peli_Clase;

        public string Peli_Codigo
        {
            get
            {
                return peli_Codigo;
            }

            set
            {
                peli_Codigo = value;
            }
        }

        public string Peli_Titulo
        {
            get
            {
                return peli_Titulo;
            }

            set
            {
                peli_Titulo = value;
            }
        }

        public string Peli_Duracion
        {
            get
            {
                return peli_Duracion;
            }

            set
            {
                peli_Duracion = value;
            }
        }

        public string Peli_Genero
        {
            get
            {
                return peli_Genero;
            }

            set
            {
                peli_Genero = value;
            }
        }

        public string Peli_Clase
        {
            get
            {
                return peli_Clase;
            }

            set
            {
                peli_Clase = value;
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string msg_Error = null;

                switch (columnName)
                {
                    case "Peli_Titulo": msg_Error = validar_Titulo(); break;
                    //case "Peli_Genero": msg_Error = validar_Genero(); break;
                    //case "Peli_Clase": msg_Error = validar_Clase(); break;
                    case "Peli_Duracion": msg_Error = validar_Duracion(); break;
                }

                return msg_Error;
            }
        }

        private string validar_Duracion()
        {
            if (String.IsNullOrEmpty(Peli_Duracion))
            {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }

        private string validar_Titulo()
        {
            if (String.IsNullOrEmpty(Peli_Titulo))
            {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }
    }
}