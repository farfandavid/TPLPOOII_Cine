﻿#pragma checksum "..\..\UserControlABMPeliculas.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A57328CB719389E8D1BF3DB01508FD8895C08348"
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
        
        
        #line 37 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCod_Pel;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitulo_Pel;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDuracion_Pel;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbClases;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbGeneros;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarPel;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarPel;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificalPel;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dgPeliculas;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\UserControlABMPeliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost EliminarPel;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\UserControlABMPeliculas.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/usercontrolabmpeliculas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlABMPeliculas.xaml"
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
            this.txtDuracion_Pel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmbClases = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cmbGeneros = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnAgregarPel = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\UserControlABMPeliculas.xaml"
            this.btnAgregarPel.Click += new System.Windows.RoutedEventHandler(this.btnAgregarPel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnEliminarPel = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\UserControlABMPeliculas.xaml"
            this.btnEliminarPel.Click += new System.Windows.RoutedEventHandler(this.btnEliminarPel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnModificalPel = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\UserControlABMPeliculas.xaml"
            this.btnModificalPel.Click += new System.Windows.RoutedEventHandler(this.btnModificalPel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dgPeliculas = ((System.Windows.Controls.ListView)(target));
            
            #line 72 "..\..\UserControlABMPeliculas.xaml"
            this.dgPeliculas.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgPeliculas_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.EliminarPel = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 11:
            this.CodInexistente = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

