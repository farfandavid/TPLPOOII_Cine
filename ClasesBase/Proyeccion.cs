using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Proyeccion
    {
        private int proy_Codigo;
        private String proy_Fecha;
        private String proy_Hora;
        private String proy_NroSala;
        private String peli_Codigo;

        public int Proy_Codigo
        {
            get
            {
                return proy_Codigo;
            }

            set
            {
                proy_Codigo = value;
            }
        }

        public string Proy_Fecha
        {
            get
            {
                return proy_Fecha;
            }

            set
            {
                proy_Fecha = value;
            }
        }

        public string Proy_Hora
        {
            get
            {
                return proy_Hora;
            }

            set
            {
                proy_Hora = value;
            }
        }

        public string Proy_NroSala
        {
            get
            {
                return proy_NroSala;
            }

            set
            {
                proy_NroSala = value;
            }
        }

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
    }
}