using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase {
    public class Pelicula {
        private int peli_Codigo;

        public int Peli_Codigo {
            get {
                return peli_Codigo;
            }
            set {
                peli_Codigo = value;
            }
        }
        private string peli_Titulo;

        public string Peli_Titulo {
            get {
                return peli_Titulo;
            }
            set {
                peli_Titulo = value;
            }
        }
        private string peli_Genero;

        public string Peli_Genero {
            get {
                return peli_Genero;
            }
            set {
                peli_Genero = value;
            }
        }
        private string peli_Duracion;

        public string Peli_Duracion {
            get {
                return peli_Duracion;
            }
            set {
                peli_Duracion = value;
            }
        }
        private string peli_Clase;

        public string Peli_Clase {
            get {
                return peli_Clase;
            }
            set {
                peli_Clase = value;
            }
        }
    }
}
