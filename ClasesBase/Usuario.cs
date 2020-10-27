using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ClasesBase
{
    public class Usuario: INotifyPropertyChanged, IDataErrorInfo
    {
        private int usu_Id;

        public int Usu_Id {
            get { return usu_Id; }
            set {
                usu_Id = value;
                Notificador(usu_Id.ToString());
            }
        }
        private string usu_NombreUsuario;

        public string Usu_NombreUsuario {
            get { return usu_NombreUsuario; }
            set {
                usu_NombreUsuario = value;
                Notificador(usu_NombreUsuario);
            }
        }
        private string usu_Contraseña;

        public string Usu_Contraseña {
            get { return usu_Contraseña; }
            set {
                usu_Contraseña = value;
                Notificador(usu_Contraseña);
            }
        }
        private string usu_ApellidoNombre;

        public string Usu_ApellidoNombre {
            get { return usu_ApellidoNombre; }
            set {
                usu_ApellidoNombre = value;
                Notificador(usu_ApellidoNombre);
            }
        }

        private Rol rol;
        public Rol Rol {
            get {
                return rol;
            }

            set {
                rol = value;
            }
        }

        private int rol_Codigo;



        public int Rol_Codigo {
            get { return rol_Codigo; }
            set {
                rol_Codigo = value;
                Notificador(rol_Codigo.ToString());
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
                    case "Usu_NombreUsuario": msg_Error = validar_NombreUsuario(); break;
                    case "Usu_Contraseña": msg_Error = validar_Contraseña(); break;
                    case "Usu_ApellidoNombre": msg_Error = validar_ApellidoNombre(); break;
                    case "Rol": msg_Error = validar_Rol(); break;
                }
                return msg_Error;
            }
        }

        public string validar_NombreUsuario() {
            Regex patron = new Regex("^[a-zA-Z0-9ñÑ]{4,12}$");
            if(!patron.IsMatch(Usu_NombreUsuario))
            {
                return "El nombre de usuario debe ser entre 8 y 12 letras y/o numeros";
            }
            return null;
        }

        public string validar_Contraseña() {
            Regex patronMinus = new Regex("[a-zñ]+");
            Regex patronMayus = new Regex("[A-ZÑ]+");
            Regex patronDig = new Regex("[0-9]+");

            if (!(patronMinus.IsMatch(Usu_Contraseña) & patronMayus.IsMatch(Usu_Contraseña)
                & patronDig.IsMatch(Usu_Contraseña))) {
                return "La contraseña debe Contener al menos 1 mayuscula, minuscula y un numero";
            } else if (Usu_Contraseña.Length < 9) {
                return "La contraseña debe Contener al menos 8 caracteres";
            }
            return null;
        }

        public string validar_ApellidoNombre() {
            Regex patron = new Regex("[a-zA-Z]+ ?");
            Regex patronDig = new Regex("[0-9]+");

            if (!(patron.IsMatch(Usu_ApellidoNombre) & !patronDig.IsMatch(Usu_ApellidoNombre))) {
                return "Ingresar Apellido y Nombres Completo";
            }
            return null;
        }

        public string validar_Rol() {
            if (String.IsNullOrEmpty(Usu_NombreUsuario)) {
                return "El valor de Campo es Obligatorio";
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notificador(string prop) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}