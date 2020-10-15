using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Usuario: INotifyPropertyChanged
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

       

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notificador(string prop) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}