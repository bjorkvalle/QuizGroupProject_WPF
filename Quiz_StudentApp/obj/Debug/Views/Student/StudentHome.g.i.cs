﻿#pragma checksum "..\..\..\..\Views\Student\StudentHome.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C6122CBD9298FB28891CF72F48DD2623"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quiz_StudentApp.Models;
using Quiz_StudentApp.Views.Student;
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


namespace Quiz_StudentApp.Views.Student {
    
    
    /// <summary>
    /// StudentHome
    /// </summary>
    public partial class StudentHome : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Views\Student\StudentHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView userInfoTemplate;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\Student\StudentHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewQuiz;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\Student\StudentHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOldQuiz;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\Student\StudentHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView quizListTemplate;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\Student\StudentHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView resultListTemplate;
        
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
            System.Uri resourceLocater = new System.Uri("/Quiz_StudentApp;component/views/student/studenthome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Student\StudentHome.xaml"
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
            this.userInfoTemplate = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.btnNewQuiz = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Views\Student\StudentHome.xaml"
            this.btnNewQuiz.Click += new System.Windows.RoutedEventHandler(this.btnNewQuiz_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnOldQuiz = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Views\Student\StudentHome.xaml"
            this.btnOldQuiz.Click += new System.Windows.RoutedEventHandler(this.btnOldQuiz_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.quizListTemplate = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.resultListTemplate = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

