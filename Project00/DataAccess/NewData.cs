using Project00.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project00.DataAccess
{
    class NewData
    {
        public static List<NewUser> NewUsers = new List<NewUser>();
        public static List<NewFollow> NewFollows = new List<NewFollow>();
        public static List<NewPost> NewPosts = new List<NewPost>();
        public static List<NewComment> NewComments = new List<NewComment>();
        public static List<NewAlarm> NewAlarms = new List<NewAlarm>();
        static NewData()
        {
            Load();
        }
       public static void Load()
        {
            try
            {
                string userOut = File.ReadAllText(@"./UserNew.xml");
                XElement userXElement = XElement.Parse(userOut);
                NewUsers = (from item in userXElement.Descendants("user")
                            select new NewUser()
                            {
                                Id = item.Element("id").Value,
                                Password = item.Element("password").Value,
                                Name = item.Element("name").Value,
                                Show = item.Element("show").Value,
                                FollowerNum = int.Parse(item.Element("followerNum").Value),
                                FollowingNum = int.Parse(item.Element("followingNum").Value),
                                PostNum = int.Parse(item.Element("postNum").Value),
                                Profile = item.Element("profile").Value
                            }).ToList<NewUser>();

                string followOut = File.ReadAllText(@"./FollowNew.xml");
                XElement followXElement = XElement.Parse(followOut);
                NewFollows = (from item in followXElement.Descendants("follow")
                            select new NewFollow()
                            {
                                UserId = item.Element("userId").Value,
                                Following = item.Element("following").Value,
                            }).ToList<NewFollow>();

                string postOut = File.ReadAllText(@"./PostNew.xml");
                XElement postXElement = XElement.Parse(postOut);
                NewPosts = (from item in postXElement.Descendants("post")
                            select new NewPost()
                            {
                                User = item.Element("user").Value,
                                Image = item.Element("image").Value,
                                Text = item.Element("text").Value,
                                Num = int.Parse(item.Element("num").Value)
                            }).ToList<NewPost>();

                string commentOut = File.ReadAllText(@"./CommentNew.xml");
                XElement commentXElement = XElement.Parse(commentOut);
                NewComments = (from item in commentXElement.Descendants("comment")
                              select new NewComment()
                              {
                                  PostNum = int.Parse(item.Element("postnum").Value),
                                  User = item.Element("user").Value,
                                  Text = item.Element("text").Value
                              }).ToList<NewComment>();

                string alarmOut = File.ReadAllText(@"./Alarm.xml");
                XElement alarmXElement = XElement.Parse(alarmOut);
                NewAlarms = (from item in alarmXElement.Descendants("alarm")
                               select new NewAlarm()
                               {
                                   Send = item.Element("send").Value,
                                   Rec = item.Element("rec").Value,
                                   Kind = item.Element("kind").Value,
                                   PostNum = int.Parse(item.Element("post").Value)
                               }).ToList<NewAlarm>();
            }
            catch(Exception e) { Save(); }
        }

        public static void Save()
        {
            string usersOut = "";
            usersOut += "<users>\n";
            foreach(var item in NewUsers)
            {
                usersOut += "<user>\n";
                usersOut += "<id>" + item.Id + "</id>\n";
                usersOut += "<password>" + item.Password + "</password>\n";
                usersOut += "<name>" + item.Name + "</name>\n";
                usersOut += "<show>" + item.Show + "</show>\n";
                usersOut += "<followerNum>" + item.FollowerNum + "</followerNum>\n";
                usersOut += "<followingNum>" + item.FollowingNum + "</followingNum>\n";
                usersOut += "<postNum>" + item.PostNum + "</postNum>\n";
                usersOut += "<profile>" + item.Profile + "</profile>\n";
                usersOut += "</user>\n";
            }
            usersOut += "</users>\n";

            string followsOut = "";
            followsOut += "<follows>\n";
            foreach(var item in NewFollows)
            {
                followsOut += "<follow>\n";
                followsOut += "<userId>" + item.UserId + "</userId>\n";
                followsOut += "<following>" + item.Following + "</following>\n";
                followsOut += "</follow>\n";
            }
            followsOut += "</follows>\n";

            string postOut = "";
            postOut += "<posts>\n";
            foreach(var item in NewPosts)
            {
                postOut += "<post>\n";
                postOut += "<user>" + item.User + "</user>\n";
                postOut += "<image>" + item.Image + "</image>\n";
                postOut += "<text>" + item.Text + "</text>\n";
                postOut += "<num>" + item.Num + "</num>\n";
                postOut += "</post>\n";
            }
            postOut += "</posts>\n";

            string commentOut = "";
            commentOut += "<comments>\n";
            foreach(var item in NewComments)
            {
                commentOut += "<comment>\n";
                commentOut += "<postnum>" + item.PostNum + "</postnum>\n";
                commentOut += "<user>" + item.User + "</user>\n";
                commentOut += "<text>" + item.Text + "</text>\n";
                commentOut += "</comment>\n";
            }
            commentOut += "</comments>\n";

            string alarmOut = "";
            alarmOut += "<alarms>\n";
            foreach(var item in NewAlarms)
            {
                alarmOut += "<alarm>\n";
                alarmOut += "<send>" + item.Send + "</send>\n";
                alarmOut += "<rec>" + item.Rec + "</rec>\n";
                alarmOut += "<kind>" + item.Kind + "</kind>\n";
                alarmOut += "<post>" + item.PostNum + "</post>\n";
                alarmOut += "</alarm>\n";
            }
            alarmOut += "</alarms>\n";

            File.WriteAllText(@"./UserNew.xml", usersOut);
            File.WriteAllText(@"./FollowNew.xml", followsOut);
            File.WriteAllText(@"./PostNew.xml", postOut);
            File.WriteAllText(@"./CommentNew.xml", commentOut);
            File.WriteAllText(@"./Alarm.xml", alarmOut);
        }
    }
}
