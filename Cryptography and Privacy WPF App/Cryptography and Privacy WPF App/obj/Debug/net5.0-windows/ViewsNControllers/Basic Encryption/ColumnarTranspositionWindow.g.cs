﻿#pragma checksum "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "283F0E6CA61E813171DFEA5E3483FAE3B481CF78"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Cryptography_and_Privacy_WPF_App;
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


namespace Cryptography_and_Privacy_WPF_App {
    
    
    /// <summary>
    /// ColumnarTranspositionWindow
    /// </summary>
    public partial class ColumnarTranspositionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputStringTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox keyTextBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button encryptButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button decryptButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button copyButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock outputTextBlock;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer blurbScroller;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock blurbTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Cryptography and Privacy WPF App;component/viewsncontrollers/basic%20encryption/" +
                    "columnartranspositionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.inputStringTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.keyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.encryptButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
            this.encryptButton.Click += new System.Windows.RoutedEventHandler(this.encryptButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.decryptButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
            this.decryptButton.Click += new System.Windows.RoutedEventHandler(this.decryptButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.copyButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\..\ViewsNControllers\Basic Encryption\ColumnarTranspositionWindow.xaml"
            this.copyButton.Click += new System.Windows.RoutedEventHandler(this.copyButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.outputTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.blurbScroller = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 8:
            this.blurbTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

