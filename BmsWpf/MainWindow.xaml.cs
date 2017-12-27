﻿using BmsWpf.Views;
using BmsWpf.Views.ChildWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BmsWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            LoginFormView dash = new LoginFormView();
            dash.Show();
            this.Close();
        }

        private void projects_Click(object sender, RoutedEventArgs e)
        {
            var dash = new ActiveProjects();
            dash.Show();
            this.Close();
        }

        private void contragents_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainContragents();
            dash.Show();
            this.Close();
        }

        private void offers_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainOffers();
            dash.Show();
            this.Close();
        }

        private void inquiries_Click(object sender, RoutedEventArgs e)
        {
            var dash = new MainInquiries();
            dash.Show();
            this.Close();
        }
    }
}