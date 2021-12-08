using Project00.DataAccess;
using Project00.Model;
using Project00.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project00.View
{
    /// <summary>
    /// Profile.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Setting.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserStore.ID = "";
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                CommentViewModel.getPostNum(UserStore.ID, Im.Source.ToString(), Te.Text);
            }catch(Exception ex) { }
            Window window = new PostComment();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string user = us.Text;
            string img = Im.Source.ToString();
            string text = Te.Text;
            ProfileViewModel.Remove(user, img, text);
            MessageBox.Show("삭제완료");
        }
    }
}
