﻿using Horizon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using Microsoft.Win32;
using Horizon.Controls;
using Horizon.ViewModels;

namespace Horizon.Windows
{
    /// <summary>
    /// The main window for the IDE.
    /// </summary>
    public partial class IDEWindow : BorderlessWindow
    {
        public static IDEWindow Instance { get; private set; }

        public IDEWindowViewModel ViewModel { get; set; }

        public IDEWindow()
        {
            this.InitializeComponent();
            Instance = this;

            this.ViewModel = new IDEWindowViewModel();
            this.DataContext = this.ViewModel;
        }
    }
}