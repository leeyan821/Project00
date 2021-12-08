using Project00.DataAccess;
using Project00.Model;
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
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Plus.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchProViewModel.userId = search.Text;
            Window window = new Search();
            window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Chat.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UserStore user = new UserStore();
            NavigationService.Navigate(new Uri("/View/Profile.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                CommentViewModel.getPostNum(us.Text, Im.Source.ToString(), Te.Text);
            }
            catch(Exception ex) { }
            Window window = new PostComment();
            window.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/OtherPost.xaml", UriKind.Relative));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainViewModel.Pluslike(us.Text, Im.Source.ToString(), Te.Text);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Window window = new Alarm();
            window.Show();
        }
    }
}
