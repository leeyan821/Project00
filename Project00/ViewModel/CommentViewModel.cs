using Project00.DataAccess;
using Project00.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Project00.ViewModel
{
    class CommentViewModel : ObservableCollection<Message>, INotifyPropertyChanged
    {
        static int num;
        static string rec;
        public static void getPostNum(string id, string img, string text)
        {
            try
            {
                rec = id;
                string image2 = "pack://application:,,,";
                num = (from a in NewData.NewPosts
                       where a.User == id && image2 + a.Image == img && a.Text == text
                       select a.Num).Single();
            }catch(Exception ex) { }
        }
        public CommentViewModel()
        {
            try
            {
                var re = (from a in NewData.NewComments
                          where a.PostNum == num
                          select a).ToList();
                var re2 = from a in re
                           join b in NewData.NewUsers on a.User equals b.Id
                           select new
                           {
                               User = a.User,
                               Text = a.Text,
                               Profile = b.Profile
                           };
                foreach(var a in re2)
                {
                    this.Add(new Message() { User = a.User, Text = a.Text, Profile=a.Profile });
                }
            }
            catch (Exception) { }
        }
        static private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value;
                OnPropertyChanged("Comment");
            }
        }

        public static void Plus()
        {
            try
            {
                NewComment newComment = new NewComment()
                {
                    PostNum = num,
                    User = UserStore.ID,
                    Text = comment
                };
                NewData.NewComments.Add(newComment);
                NewData.Save();

                NewAlarm newAlarm = new NewAlarm()
                {
                    Send = UserStore.ID,
                    Rec = rec,
                    Kind = "comment",
                    PostNum = num
                };
                NewData.NewAlarms.Add(newAlarm);
                NewData.Save();
                
            }catch(Exception ex) { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Message
    {
        public string User { get; set; }
        public string Text { get; set; }
        public string Profile { get; set; }
    }
}
