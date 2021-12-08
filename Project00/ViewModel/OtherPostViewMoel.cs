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
    public class OtherPostViewMoel : ObservableCollection<Other>
    {
        public OtherPostViewMoel()
        {
            try
            {
                var re = (from a in NewData.NewPosts
                          where a.User == UserStore.ID
                          select a).ToList();
                var NoUser = NewData.NewPosts.Where(x => !re.Contains(x)).ToList();
                var re2 = (from a in NewData.NewFollows
                           where a.UserId == UserStore.ID
                           select a).ToList();

                var re3 = (from a in NoUser
                           join b in re2 on a.User equals b.Following
                           select a).ToList();
                var NoUser2 = NoUser.Where(x => !re3.Contains(x)).ToList();

                foreach (var a in NoUser2)
                {
                    Add(new Other() { Id = a.User, Image = a.Image, Num = a.Num, Text = a.Text });
                }
            }
            catch (Exception ex) { }
        }
    }
    public class Other
    {
        public string Image { get; set; }
        public int Num { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
