﻿#pragma checksum "..\..\..\ControlUsuario\UserControlABMClientes.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8D4C12A2C812E35AD20968735F62371B1BB92D4C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ClasesBase.TrabajarABM;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Vistas.ControlUsuario;


namespace Vistas.ControlUsuario {
    
    
    /// <summary>
    /// UserControlABMClientes
    /// </summary>
    public partial class UserControlABMClientes : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 73 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBuscarCliente;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCli_Dni;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCli_Nombre;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCli_Apellido;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCli_Telefono;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCli_Email;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid principal;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarCli;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarCli;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificalCli;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dgClientes;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost CamposIncompletos;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost DniRepetido;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost EliminarCli;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost DniInexistente;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Vistas;component/controlusuario/usercontrolabmclientes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 17 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
            ((Vistas.ControlUsuario.UserControlABMClientes)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnBuscarCliente = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
            this.btnBuscarCliente.Click += new System.Windows.RoutedEventHandler(this.btnBuscarCli_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtCli_Dni = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtCli_Nombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtCli_Apellido = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtCli_Telefono = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtCli_Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.principal = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.btnAgregarCli = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
            this.btnAgregarCli.Click += new System.Windows.RoutedEventHandler(this.btnAgregarCli_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnEliminarCli = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
            this.btnEliminarCli.Click += new System.Windows.RoutedEventHandler(this.btnEliminarCli_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnModificalCli = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
            this.btnModificalCli.Click += new System.Windows.RoutedEventHandler(this.btnModificalCli_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.dgClientes = ((System.Windows.Controls.ListView)(target));
            
            #line 136 "..\..\..\ControlUsuario\UserControlABMClientes.xaml"
            this.dgClientes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgClientes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.CamposIncompletos = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 14:
            this.DniRepetido = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 15:
            this.EliminarCli = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 16:
            this.DniInexistente = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

