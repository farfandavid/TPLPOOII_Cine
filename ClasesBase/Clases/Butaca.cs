using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase {
    public class Butaca {
        private int but_ID;

        public int But_ID {
            get {
                return but_ID;
            }
            set {
                but_ID = value;
            }
        }
        private int but_Nro;

        public int But_Nro {
            get {
                return but_Nro;
            }
            set {
                but_Nro = value;
            }
        }
        private string but_Fila;

        public string But_Fila {
            get {
                return but_Fila;
            }
            set {
                but_Fila = value;
            }
        }
        private int sala_ID;

        public int Sala_ID {
            get {
                return sala_ID;
            }
            set {
                sala_ID = value;
            }
        }
    }
}
