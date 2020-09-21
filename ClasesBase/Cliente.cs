using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Cliente
    {
        private int cli_Dni;
        private String cli_Nombre;
        private String cli_Apellido;
        private String cli_Telefono;
        private String cli_Email;
        
        
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

        public string Cli_Nombre
        {
            get
            {
                return cli_Nombre;
            }

            set
            {
                cli_Nombre = value;
            }
        }

        public string Cli_Apellido
        {
            get
            {
                return cli_Apellido;
            }

            set
            {
                cli_Apellido = value;
            }
        }

        public string Cli_Telefono
        {
            get
            {
                return cli_Telefono;
            }

            set
            {
                cli_Telefono = value;
            }
        }

        public string Cli_Email
        {
            get
            {
                return cli_Email;
            }

            set
            {
                cli_Email = value;
            }
        }
    }
}