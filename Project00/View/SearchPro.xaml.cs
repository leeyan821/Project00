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
    /// SearchPro.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchPro : Window
    {
        public SearchPro()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool re = SearchProViewModel.Re();
            if (re)
            {
                SearchProViewModel.ChangeF();
                MessageBox.Show("언팔로우 되었습니다.");
            }
            else
            {
                SearchProViewModel.ChangeFo();
                SearchProViewModel.PlusAlarm();
                MessageBox.Show("팔로우 되었습니다.");
            }
            this.Close();
        }
    }
}
