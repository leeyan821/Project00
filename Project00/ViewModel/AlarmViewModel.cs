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
    public class AlarmViewModel : ObservableCollection<al>
    {
        public AlarmViewModel()
        {
            try
            {
                //로그인 유저의 정보
                var re = (from a in NewData.NewUsers
                            where a.Id == UserStore.ID
                            select a).ToList();
                //로그인 유저의 알람
                var re2 = (from a in re
                           join b in NewData.NewAlarms on a.Id equals b.Rec
                           select b).ToList();
                var re3 = (from a in NewData.NewUsers
                           join b in re2 on a.Id equals b.Send
                           select new
                           {
                               Profile = a.Profile,
                               Send = b.Send,
                               Kind = b.Kind,
                               Post = b.PostNum
                           });

                foreach(var u in re3)
                {
                    if (u.Kind == "like")
                        Add(new al() { Profile = u.Profile, User = u.Send, Text = u.Send + "님이 회원님의 사진을 좋아합니다.", Num = u.Post });
                    else if(u.Kind == "follow")
                        Add(new al() { Profile = u.Profile, User = u.Send, Text = u.Send + "님이 회원님을 팔로우합니다.", Num = u.Post });
                    else if(u.Kind == "comment")
                        Add(new al() { Profile = u.Profile, User = u.Send, Text = u.Send + "님이 댓글을 남겼습니다.", Num = u.Post });
                }
            }catch(Exception ex) { }
        }
    }
    public class al
    {
        public string Profile { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public int Num { get; set; }
    }
}
