#pragma checksum "..\..\..\UserContols\GraphCanvas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "216D93BBD653641B1F77B3D58AB56C95B0AFA44E598062B6505B15C03560A030"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using GraphDesktop.UserContols;
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


namespace GraphDesktop.UserContols {
    
    
    /// <summary>
    /// GraphCanvas
    /// </summary>
    public partial class GraphCanvas : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// Canvas Name Field
        /// </summary>
        
        #line 56 "..\..\..\UserContols\GraphCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Canvas Canvas;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\UserContols\GraphCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup Popup;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\UserContols\GraphCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MatrixChoice;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\UserContols\GraphCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MatrixGrid;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\UserContols\GraphCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DiametrData;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\UserContols\GraphCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RadiusData;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\UserContols\GraphCanvas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MatrixAdjGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/GraphDesktop;component/usercontols/graphcanvas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserContols\GraphCanvas.xaml"
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
            this.Canvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 55 "..\..\..\UserContols\GraphCanvas.xaml"
            this.Canvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 3:
            this.MatrixChoice = ((System.Windows.Controls.ComboBox)(target));
            
            #line 86 "..\..\..\UserContols\GraphCanvas.xaml"
            this.MatrixChoice.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MatrixChoice_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MatrixGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 96 "..\..\..\UserContols\GraphCanvas.xaml"
            this.MatrixGrid.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.Grid1_LoadingRow);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DiametrData = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.RadiusData = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            
            #line 121 "..\..\..\UserContols\GraphCanvas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddElement);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 158 "..\..\..\UserContols\GraphCanvas.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MatrixAdjGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 213 "..\..\..\UserContols\GraphCanvas.xaml"
            this.MatrixAdjGrid.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.Grid1_LoadingRow);
            
            #line default
            #line hidden
            
            #line 217 "..\..\..\UserContols\GraphCanvas.xaml"
            this.MatrixAdjGrid.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.MatrixAdjGrid_OnCellEditEnding);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

