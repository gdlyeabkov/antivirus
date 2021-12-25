﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8670ED0CE9DBFAB00777E63779724374301526EDCFD5DEF4BE7903863B7F36EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AntiVirus;
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


namespace AntiVirus {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel tabs;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel headerIcons;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl asideTabs;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabsToggler;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel tabsLabels;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl capabilities;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel notifications;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel breadcrumbs;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock breadcrumb;
        
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
            System.Uri resourceLocater = new System.Uri("/AntiVirus;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 8 "..\..\MainWindow.xaml"
            ((AntiVirus.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.SearchVirusesHandler);
            
            #line default
            #line hidden
            
            #line 8 "..\..\MainWindow.xaml"
            ((AntiVirus.MainWindow)(target)).DragOver += new System.Windows.DragEventHandler(this.DragWindowHandler);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ToggleProgrammHandler);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.CloseProgrammHandler);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tabs = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            
            #line 27 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SelectTabHandler);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 30 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SelectTabHandler);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 33 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SelectTabHandler);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 36 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.SelectTabHandler);
            
            #line default
            #line hidden
            return;
            case 9:
            this.headerIcons = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            
            #line 41 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverHeaderIconHandler);
            
            #line default
            #line hidden
            
            #line 41 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoutHeaderIconHandler);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 42 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverHeaderIconHandler);
            
            #line default
            #line hidden
            
            #line 42 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoutHeaderIconHandler);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 43 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.HoverHeaderIconHandler);
            
            #line default
            #line hidden
            
            #line 43 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.HoutHeaderIconHandler);
            
            #line default
            #line hidden
            return;
            case 13:
            this.asideTabs = ((System.Windows.Controls.TabControl)(target));
            return;
            case 14:
            
            #line 148 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ToggleTabHandler);
            
            #line default
            #line hidden
            return;
            case 15:
            this.tabsToggler = ((System.Windows.Controls.TabControl)(target));
            return;
            case 16:
            this.tabsLabels = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 17:
            
            #line 176 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ActivateTabHandler);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 177 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ActivateTabHandler);
            
            #line default
            #line hidden
            return;
            case 19:
            this.capabilities = ((System.Windows.Controls.TabControl)(target));
            return;
            case 20:
            this.notifications = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 21:
            this.breadcrumbs = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 22:
            
            #line 209 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GetSecurityReport);
            
            #line default
            #line hidden
            return;
            case 23:
            this.breadcrumb = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 24:
            
            #line 211 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GetSecurityReport);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 241 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.OpenInternetProtectionHandler);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 261 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.OpenPasswordsManagementHandler);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 273 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GoToMyAccountHandler);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 285 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GoToSecurityLogHandler);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 290 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GoToAboutHandler);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 294 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GoToHelpHandler);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 305 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.StackPanel)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ToggleTabHandler);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

