﻿using Horizon.Controls;
using Horizon.UI;
using Horizon.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.ViewModels
{
    /// <summary>
    /// ViewModel for main menu control.
    /// </summary>
    public class MainMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsFileButtonEnabled
        {
            get
            {
                if (Status.Instance is null) { return true; }
                return !Status.Instance.ViewModel.IsRunningStarbound;
            }
        }

        public bool IsTestButtonEnabled => !(IDEWindow.Instance.ViewModel.CurrentProject is null);

        public RecentItem LastOpenedProject => App.Metadata.LastOpenedProject;

        public ObservableCollection<RecentItem> RecentlyOpenedProjects => new ObservableCollection<RecentItem>(App.Metadata?.RecentlyOpenedProjects?.Reverse());

        public string SaveText => "";// $"Save {App.MainWindow.ActivePage.GetModel().Header}..."; //TODO: Fix whatever this is

        public MainMenuViewModel()
        {
            if (App.Metadata is null) { return; }
            App.Metadata.PropertyChanged += this.Metadata_PropertyChanged;
            IDEWindow.Instance.ViewModel.PropertyChanged += this.IDEWindowPropertyChanged;
        }

        private void IDEWindowPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(IDEWindow.Instance.ViewModel.CurrentProject))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsTestButtonEnabled)));
            }
        }

        private void Metadata_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(App.Metadata.RecentlyOpenedProjects))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.RecentlyOpenedProjects)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.LastOpenedProject)));
            }
        }
    }
}