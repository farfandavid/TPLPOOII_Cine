using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase {
    public class Venta {
        private int vent_ID;
        private int cli_ID;
        private int tick_ID;
        private DateTime vent_Fecha;
        private int usu_ID;

        public int Vent_ID
        {
            get
            {
                return vent_ID;
            }

            set
            {
                vent_ID = value;
            }
        }

        public int Cli_ID
        {
            get
            {
                return cli_ID;
            }

            set
            {
                cli_ID = value;
            }
        }

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

        public DateTime Vent_Fecha
        {
            get
            {
                return vent_Fecha;
            }

            set
            {
                vent_Fecha = value;
            }
        }

        public int Usu_ID
        {
            get
            {
                return usu_ID;
            }

            set
            {
                usu_ID = value;
            }
        }
    }
}