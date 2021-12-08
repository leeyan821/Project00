using Project00.ViewModel;
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
    /// Plus.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Plus : Page
    {
        public Plus()
        {
            InitializeComponent();           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Make.xaml", UriKind.Relative));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MakeViewModel.Img = "/Image/cat1.jpeg";
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MakeViewModel.Img = "/Image/cat2.jpeg";
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MakeViewModel.Img = "/Image/cat3.jpeg";
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MakeViewModel.Img = "/Image/cat4.jpeg";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MakeViewModel.Img = "/Image/cat5.jpeg";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }
    }
}
