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
using System.Windows.Shapes;

namespace Project00.View
{
    /// <summary>
    /// PostComment.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PostComment : Window
    {
        public PostComment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommentViewModel.Plus();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchProViewModel.userId = UId.Text;
            MainViewModel.userId = UId.Text;
            Window window = new SearchPro();
            window.Show();
        }
    }
}
