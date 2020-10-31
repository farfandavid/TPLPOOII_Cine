using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase {
    public class Sala {
        private int sala_ID;
        private string sala_Descripcion;
        private int sala_DimensionFil;
        private int sala_DimensionCol;

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

        public string Sala_Descripcion
        {
            get
            {
                return sala_Descripcion;
            }

            set
            {
                sala_Descripcion = value;
            }
        }


        public int Sala_DimensionFil {
            get {
                return sala_DimensionFil;
            }

            set {
                sala_DimensionFil = value;
            }
        }

        public int Sala_DimensionCol {
            get {
                return sala_DimensionCol;
            }

            set {
                sala_DimensionCol = value;
            }
        }
    }
}