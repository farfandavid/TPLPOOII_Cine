using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Cliente : IDataErrorInfo
    {
        private string cli_DNI;
        private string cli_Nombre;
        private string cli_Apellido;
        private string cli_Telefono;
        private string cli_Email;
        private int cli_ID;

        public string Cli_DNI
        {
            get
            {
                return cli_DNI;
            }

            set
            {
                cli_DNI = value;
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

        public string Error {
            get {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName] {
            get {
                string msg_Error = null;
                switch (columnName) {
                    case "Cli_DNI": msg_Error = validar_DNI(); break;
                    case "Cli_Nombre": msg_Error = validar_Nombre(); break;
                    case "Cli_Apellido": msg_Error = validar_Apellido(); break;
                    case "Cli_Email": msg_Error = validar_Email(); break;
                    case "Cli_Telefono": msg_Error = validar_Telefono(); break;
                }
                return msg_Error;
            }
        }

        public string validar_DNI() {
            if (String.IsNullOrEmpty(Cli_DNI)) {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }

        public string validar_Nombre()
        {
            if (String.IsNullOrEmpty(Cli_Nombre))
            {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }

        public string validar_Apellido()
        {
            if (String.IsNullOrEmpty(Cli_Apellido))
            {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }

        public string validar_Telefono()
        {
            if (String.IsNullOrEmpty(Cli_Telefono))
            {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }

        public string validar_Email()
        {
            if (String.IsNullOrEmpty(Cli_Email))
            {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }
        
    }
}