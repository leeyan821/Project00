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
using System.Windows.Shapes;

namespace Project00.View
{
    /// <summary>
    /// Alarm.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Alarm : Window
    {
        public Alarm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(postNum.Text);
            string u = user.Text;
            
            if(num == 0)
            {
                MainViewModel.userId = u;
                SearchProViewModel.userId = u;
                Window window = new SearchPro();
                window.Show();
            }
            else
            {
                try
                {
                    NewPost newPost = NewData.NewPosts.Single(x => x.Num == num);
                    CommentViewModel.getPostNum(newPost.User, "pack://application:,,," + newPost.Image, newPost.Text);
                }
                catch (Exception ex) { }
                Window window = new PostComment();
                window.Show();
            }
        }
    }
}
