using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase {
    public class Sala {
        private int sala_ID;

        public int Sala_ID {
            get {
                return sala_ID;
            }
            set {
                sala_ID = value;
            }
        }
        private string sala_Descripcion;

        public string Sala_Descripcion {
            get {
                return sala_Descripcion;
            }
            set {
                sala_Descripcion = value;
            }
        }
        private int sala_Butacas;

        public int Sala_Butacas {
            get {
                return sala_Butacas;
            }
            set {
                sala_Butacas = value;
            }
        }
    }
}
