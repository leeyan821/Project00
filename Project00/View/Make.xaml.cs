﻿using Project00.DataAccess;
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

namespace Project00.View
{
    /// <summary>
    /// Make.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Make : Page
    {
        public Make()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MakeViewModel.AddPost();
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }
    }
}
