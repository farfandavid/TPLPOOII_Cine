using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Butaca {
        private int but_Fila;
        private int but_ID;
        private int but_Col;
        private int sala_ID;

        public int But_Fila
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

        public int But_ID
        {
            get
            {
                return but_ID;
            }

            set
            {
                but_ID = value;
            }
        }

        public int But_Col
        {
            get
            {
                return but_Col;
            }

            set
            {
                but_Col = value;
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
    }
}