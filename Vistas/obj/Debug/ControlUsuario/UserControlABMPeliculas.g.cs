﻿#pragma checksum "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8763F9018B2E0D6CB1D8FDB47740F63D7A0511F6"
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
using Vistas;


namespace Vistas {
    
    
    /// <summary>
    /// UserControlABMPeliculas
    /// </summary>
    public partial class UserControlABMPeliculas : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCod_Pel;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitulo_Pel;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker txtDuracion_Pel;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClases;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbGeneros;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPel_Img;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarFoto;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPel_Vid;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarVideo;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarPel;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarPel;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificalPel;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dgPeliculas;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost EliminarPel;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost CodInexistente;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/controlusuario/usercontrolabmpeliculas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
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
            this.txtCod_Pel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtTitulo_Pel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtDuracion_Pel = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 4:
            this.cmbClases = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cmbGeneros = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtPel_Img = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnAgregarFoto = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
            this.btnAgregarFoto.Click += new System.Windows.RoutedEventHandler(this.btnAgregarFoto_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtPel_Vid = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnAgregarVideo = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
            this.btnAgregarVideo.Click += new System.Windows.RoutedEventHandler(this.btnAgregarVideo_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnAgregarPel = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
            this.btnAgregarPel.Click += new System.Windows.RoutedEventHandler(this.btnAgregarPel_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnEliminarPel = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
            this.btnEliminarPel.Click += new System.Windows.RoutedEventHandler(this.btnEliminarPel_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnModificalPel = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
            this.btnModificalPel.Click += new System.Windows.RoutedEventHandler(this.btnModificalPel_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.dgPeliculas = ((System.Windows.Controls.ListView)(target));
            
            #line 88 "..\..\..\ControlUsuario\UserControlABMPeliculas.xaml"
            this.dgPeliculas.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgPeliculas_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.EliminarPel = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 15:
            this.CodInexistente = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
