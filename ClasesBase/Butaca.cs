using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Butaca
    {
        private String but_Fila;
        private String but_Nro;
        private String but_NroSala;

        public string But_Fila
        {
            get
            {
                return but_Fila;
            }

            set
            {
                but_Fila = value;
            }
        }

        public string But_Nro
        {
            get
            {
                return but_Nro;
            }

            set
            {
                but_Nro = value;
            }
        }

        public string But_NroSala
        {
            get
            {
                return but_NroSala;
            }

            set
            {
                but_NroSala = value;
            }
        }
    }
}