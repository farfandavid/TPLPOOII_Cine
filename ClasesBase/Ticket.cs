using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket {
        private int tick_ID;
        private int proy_ID;
        private int but_ID;
        private bool tick_Estado;

        public int Tick_ID
        {
            get
            {
                return tick_ID;
            }

            set
            {
                tick_ID = value;
            }
        }

        public int Proy_ID
        {
            get
            {
                return proy_ID;
            }

            set
            {
                proy_ID = value;
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

        public bool Tick_Estado
        {
            get
            {
                return tick_Estado;
            }

            set
            {
                tick_Estado = value;
            }
        }
    }
}