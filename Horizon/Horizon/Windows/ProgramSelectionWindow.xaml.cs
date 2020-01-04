﻿using Horizon.Diagnostics;
using System.Windows;

namespace Horizon.Windows
{
    /// <summary>
    /// Displays a window that allows the user to choose between the launcher and the IDE.
    /// </summary>
    public partial class ProgramSelectionWindow : Window
    {
        public ProgramSelectionWindow()
        {
            this.InitializeComponent();
        }

        [Log("Selected IDE. Opening IDE Window.")]
        private void IDEButtonClick(object sender, RoutedEventArgs args)
        {
            this.Close();
            new IDEWindow().Show();
        }

        [Log("Selected Launcher. Opening Launcher Window.")]
        private void LauncherButtonClick(object sender, RoutedEventArgs args)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.Close();
                new Launcher().Show();
            });
        }
    }
}