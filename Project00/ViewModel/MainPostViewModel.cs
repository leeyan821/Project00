using Project00.DataAccess;
using Project00.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.ViewModel
{
    public class MainPostViewModel : ObservableCollection<MainPost>
    {
        public MainPostViewModel()
        {
            try
            {
                var re = (from a in NewData.NewPosts
                          where a.User == UserStore.ID
                          select a).ToList();
                var re1 = from a in re
                           join b in NewData.NewUsers on a.User equals b.Id
                           select new
                           {
                               Profile = b.Profile,
                               User = a.User,
                               Image = a.Image,
                               Text = a.Text
                           };
                foreach (var u in re1)
                {
                    Add(new MainPost() { User = u.User, Image = u.Image, Content = u.Text, Profile=u.Profile });
                }
                var re2 = (from a in NewData.NewFollows
                           where a.UserId == UserStore.ID
                           select a).ToList();
                var re4 = from a in re2
                           join b in NewData.NewUsers on a.Following equals b.Id
                           select new
                           {
                               Profile = b.Profile,
                               Following = a.Following
                           };
                var re3 = from a in re4
                          join b in NewData.NewPosts on a.Following equals b.User
                          select new
                          {
                              Profile = a.Profile,
                              User = b.User,
                              Image = b.Image,
                              Text = b.Text
                          };                             
                foreach(var u in re3)
                {
                    Add(new MainPost() { User = u.User, Image = u.Image, Content = u.Text, Profile=u.Profile });
                }
                this.Add(new MainPost() { User = "OutStarGram", Image = "/Image/cat5.jpeg", Content = "First Test", Profile= "/Image/ProfileKey8.png" });
            }
            catch(Exception ex) { }
        }
    }
    public class MainPost
    {
        public string Profile { get; set; }
        public string User { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
    }
}
