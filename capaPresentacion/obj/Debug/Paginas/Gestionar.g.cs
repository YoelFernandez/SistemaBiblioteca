﻿#pragma checksum "..\..\..\Paginas\Gestionar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9E2EE09EE5F44838AE433A8646330D8BD12D21F58CD05376226D867EE09F5D2E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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
using capaPresentacion.Paginas;


namespace capaPresentacion.Paginas {
    
    
    /// <summary>
    /// Gestionar
    /// </summary>
    public partial class Gestionar : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Paginas\Gestionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_buscarLibroCodigo;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Paginas\Gestionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Paginas\Gestionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Paginas\Gestionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_libros;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Paginas\Gestionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_nuevoLibro;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Paginas\Gestionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_editarLibro;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Paginas\Gestionar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_eliminarLibro;
        
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
            System.Uri resourceLocater = new System.Uri("/capaPresentacion;component/paginas/gestionar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Paginas\Gestionar.xaml"
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
            
            #line 9 "..\..\..\Paginas\Gestionar.xaml"
            ((capaPresentacion.Paginas.Gestionar)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_buscarLibroCodigo = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\Paginas\Gestionar.xaml"
            this.tb_buscarLibroCodigo.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tb_buscarLibroCodigo_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.button = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.dg_libros = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\Paginas\Gestionar.xaml"
            this.dg_libros.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg_libros_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.b_nuevoLibro = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Paginas\Gestionar.xaml"
            this.b_nuevoLibro.Click += new System.Windows.RoutedEventHandler(this.b_nuevoLibro_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.b_editarLibro = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Paginas\Gestionar.xaml"
            this.b_editarLibro.Click += new System.Windows.RoutedEventHandler(this.b_editarLibro_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.b_eliminarLibro = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Paginas\Gestionar.xaml"
            this.b_eliminarLibro.Click += new System.Windows.RoutedEventHandler(this.b_eliminarLibro_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

