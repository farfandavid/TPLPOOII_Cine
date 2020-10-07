using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Proyeccion
    {
        private int proy_Codigo;
        private DateTime proy_Fecha;
        private String proy_Hora;
        private int sala_ID;
        private int peli_Codigo;

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

        public DateTime Proy_Fecha
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

        public int Sala_ID
        {
            get
            {
                return sala_ID;
            }

            set
            {
                sala_ID = value;
            }
        }

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
    }
}