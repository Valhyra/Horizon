﻿using Horizon.Controls;
using Horizon.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Horizon.Windows
{
    /// <summary>
    /// Allows the user to change personal settings to customize user experience.
    /// </summary>
    public partial class PreferencesWindow : BorderlessReactiveWindow<PreferencesViewModel>
    {
        private List<DockPanel> panels = new List<DockPanel>();

        public PreferencesWindow()
        {
            this.InitializeComponent();

            this.ViewModel = new PreferencesViewModel();

            this.WhenActivated(dispose =>
            {
                this.Bind(this.ViewModel,
                    vm => vm.OpenLastProjectOnStartup,
                    v => v.OpenLastProject.IsChecked)
                .DisposeWith(dispose);
            });
        }

        private void Cancel_Click(object sender, RoutedEventArgs args) => this.Close();

        private void Ok_Click(object sender, RoutedEventArgs args)
        {
            this.ViewModel.CommitPreferences();
            this.Close();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> args)
        {
            TreeViewItem oldItem = args.OldValue as TreeViewItem ?? this.TreeNav.Items[0] as TreeViewItem;
            TreeViewItem newItem = args.NewValue as TreeViewItem;

            this.panels.Find(x => x.Tag.ToString() == oldItem.Tag.ToString()).Visibility = Visibility.Hidden;
            this.panels.Find(x => x.Tag.ToString() == newItem.Tag.ToString()).Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs args)
        {
            foreach (DockPanel panel in this.PreferenceDock.Children)
            {
                this.panels.Add(panel);
                panel.Visibility = Visibility.Hidden;
            }

            this.PreferenceDock.Children[0].Visibility = Visibility.Visible;
        }
    }
}