﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Rol {
        private int rol_Codigo;
        private String rol_Descripcion;

        public int Rol_Codigo
        {
            get
            {
                return rol_Codigo;
            }

            set
            {
                rol_Codigo = value;
            }
        }

        public string Rol_Descripcion
        {
            get
            {
                return rol_Descripcion;
            }

            set
            {
                rol_Descripcion = value;
            }
        }
    }
}