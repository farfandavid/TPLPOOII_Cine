using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket {
        private int tick_ID;

        private int proy_ID;
        private Proyeccion proyeccion;

        private int but_ID;
        private string tick_Estado;
        private int tick_precio;

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

        public string Tick_Estado {
            get {
                return tick_Estado;
            }

            set {
                tick_Estado = value;
            }
        }

        public int Tick_precio {
            get {
                return tick_precio;
            }

            set {
                tick_precio = value;
            }
        }

        public Proyeccion Proyeccion {
            get {
                return proyeccion;
            }

            set {
                proyeccion = value;
            }
        }
    }
}