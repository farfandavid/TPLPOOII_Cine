﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase {
    public class Cliente {
        private string cli_Apellido;

        public string Cli_Apellido {
            get {
                return cli_Apellido;
            }
            set {
                cli_Apellido = value;
            }
        }
        private string cli_DNI;

        public string Cli_DNI {
            get {
                return cli_DNI;
            }
            set {
                cli_DNI = value;
            }
        }
        private string cli_Email;

        public string Cli_Email {
            get {
                return cli_Email;
            }
            set {
                cli_Email = value;
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
        private string cli_Nombre;

        public string Cli_Nombre {
            get {
                return cli_Nombre;
            }
            set {
                cli_Nombre = value;
            }
        }
        private string cli_Telefono;

        public string Cli_Telefono {
            get {
                return cli_Telefono;
            }
            set {
                cli_Telefono = value;
            }
        }
    }
}
