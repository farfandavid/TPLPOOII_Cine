using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket
    {
        private int tick_Nro;
        private DateTime tick_FechaVenta;
        private int cli_Dni;
        private int proy_Codigo;
        private String but_Fila;
        private String but_Nro;

        public int Tick_Nro
        {
            get
            {
                return tick_Nro;
            }

            set
            {
                tick_Nro = value;
            }
        }

        public DateTime Tick_FechaVenta
        {
            get
            {
                return tick_FechaVenta;
            }

            set
            {
                tick_FechaVenta = value;
            }
        }

        public int Cli_Dni
        {
            get
            {
                return cli_Dni;
            }

            set
            {
                cli_Dni = value;
            }
        }

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
    }
}