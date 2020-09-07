using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase {
    public class TIcket {
        private int but_ID;

        public int But_ID {
            get {
                return but_ID;
            }
            set {
                but_ID = value;
            }
        }
        private int cli_ID;

        public int Cli_ID {
            get {
                return cli_ID;
            }
            set {
                cli_ID = value;
            }
        }
        private int proy_Codigo;

        public int Proy_Codigo {
            get {
                return proy_Codigo;
            }
            set {
                proy_Codigo = value;
            }
        }
        private int tick_ID;

        public int Tick_ID {
            get {
                return tick_ID;
            }
            set {
                tick_ID = value;
            }
        }
        private DateTime tick_FechaVenta;

        public DateTime Tick_FechaVenta {
            get {
                return tick_FechaVenta;
            }
            set {
                tick_FechaVenta = value;
            }
        }
    }
}
