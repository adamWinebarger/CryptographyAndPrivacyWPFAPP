﻿#pragma checksum "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9B8AF9B41A82F1C7A6734C54C3A6ACF579844B06"
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
    /// AdvancedEncryptionMenu
    /// </summary>
    public partial class AdvancedEncryptionMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button aesButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button adfgvxButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button rsaButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button hillCipherButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button enigmaButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Cryptography and Privacy WPF App;component/viewsncontrollers/submenus/advanceden" +
                    "cryptionmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
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
            this.aesButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
            this.aesButton.Click += new System.Windows.RoutedEventHandler(this.aesButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.adfgvxButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
            this.adfgvxButton.Click += new System.Windows.RoutedEventHandler(this.adfgvxButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rsaButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.hillCipherButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\ViewsNControllers\SubMenus\AdvancedEncryptionMenu.xaml"
            this.hillCipherButton.Click += new System.Windows.RoutedEventHandler(this.hillCipherButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.enigmaButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

