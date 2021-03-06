﻿using Horizon.Diagnostics;
using System.Threading;
using System.Windows;

namespace Horizon.Windows
{
    /// <summary>
    /// Presents a splash window that disappears in 5 seconds.
    /// </summary>
    public partial class Splash : Window
    {
        public Splash()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Waits for 5 seconds, then closes the window and opens program selection on the UI thread.
        /// </summary>
        [Log("Waiting for splash.")]
        private void DelayThread()
        {
            Thread.Sleep(5000);
            this.Dispatcher.Invoke(() =>
            {
                this.Close();
                bool? _ = new ProgramSelectionWindow().ShowDialog();
            });
        }

        /// <summary>
        /// Calls the delay thread when the window loads.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="args">
        /// The event arguments.
        /// </param>
        private void SplashLoaded(object sender, RoutedEventArgs args) => new Thread(new ThreadStart(this.DelayThread)).Start();
    }
}