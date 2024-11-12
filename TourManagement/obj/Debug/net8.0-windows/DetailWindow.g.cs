﻿#pragma checksum "..\..\..\DetailWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74D43ED48188C15BDECBB439E139EADFF461E722"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TourManagement;


namespace TourManagement {
    
    
    /// <summary>
    /// DetailWindow
    /// </summary>
    public partial class DetailWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TourIDTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TourNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StartTimeTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FinishTimeTextBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ParticipantsTextBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\DetailWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuitButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TourManagement;component/detailwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DetailWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\DetailWindow.xaml"
            ((TourManagement.DetailWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TourIDTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TourNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.StartTimeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.FinishTimeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ParticipantsTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\DetailWindow.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.QuitButton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\DetailWindow.xaml"
            this.QuitButton.Click += new System.Windows.RoutedEventHandler(this.QuitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

