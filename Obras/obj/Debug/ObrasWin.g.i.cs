﻿#pragma checksum "..\..\ObrasWin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B13C201FF2526A7E3120B6D015E41309"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NumericUpDownControl;
using Obras.Converters;
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


namespace Obras {
    
    
    /// <summary>
    /// ObrasWin
    /// </summary>
    public partial class ObrasWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PanelCentral;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtTitulo;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtNumMaterial;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbxPresentacion;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NumericUpDownControl.NumericBox TxtNumVolumen;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtIsbn;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbxTipoObra;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NumericUpDownControl.NumericBox TxtYear;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSalir;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\ObrasWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGuardar;
        
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
            System.Uri resourceLocater = new System.Uri("/Obras;component/obraswin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ObrasWin.xaml"
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
            
            #line 10 "..\..\ObrasWin.xaml"
            ((Obras.ObrasWin)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PanelCentral = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.TxtTitulo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtNumMaterial = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\ObrasWin.xaml"
            this.TxtNumMaterial.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TxtNumMaterial_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CbxPresentacion = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.TxtNumVolumen = ((NumericUpDownControl.NumericBox)(target));
            return;
            case 7:
            this.TxtIsbn = ((System.Windows.Controls.TextBox)(target));
            
            #line 82 "..\..\ObrasWin.xaml"
            this.TxtIsbn.LostFocus += new System.Windows.RoutedEventHandler(this.TxtIsbn_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CbxTipoObra = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.TxtYear = ((NumericUpDownControl.NumericBox)(target));
            return;
            case 10:
            this.BtnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\ObrasWin.xaml"
            this.BtnSalir.Click += new System.Windows.RoutedEventHandler(this.BtnSalir_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\ObrasWin.xaml"
            this.BtnGuardar.Click += new System.Windows.RoutedEventHandler(this.BtnGuardar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
