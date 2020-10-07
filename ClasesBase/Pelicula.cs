using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Pelicula {
        private int peli_Codigo;
        private String peli_Titulo;
        private String peli_Duracion;
        private String peli_Genero;
        private String peli_Clase;

        public int Peli_Codigo
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
    }
}