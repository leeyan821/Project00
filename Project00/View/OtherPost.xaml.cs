using Project00.DataAccess;
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
    /// OtherPost.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OtherPost : Page
    {
        public OtherPost()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommentViewModel.getPostNum(us.Text, Im.Source.ToString(), Te.Text);
            }
            catch (Exception ex) { }
            Window window = new PostComment();
            window.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Main.xaml", UriKind.Relative));
        }
    }
}
