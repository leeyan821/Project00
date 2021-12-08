using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Resources;
using Project00.Model;
using System.IO;

namespace Project00.DataAccess
{
    public class UserStore
    {
        public static string ID = "";
        static List<User> users;
        
        static UserStore()
        {
            users = LoadUsers();
        }
        public static List<User> GetUsers()
        {
            return new List<User>(users);
        }
        public static int num;
        public static int CountUserPost()
        {
            int n = 1;
            users = LoadUsers();
            n = (from a in users
                 where a.Id == ID
                 select a.PostNum).Single();
            return n;
        }
        public static int CountFollower()
        {
            int n = 1;
            users = LoadUsers();
            n = (from a in users
                 where a.Id == ID
                 select a.FollowerNum).Single();
            return n;
        }
        public static int CountFollowing()
        {
            int n = 1;
            users = LoadUsers();
            n = (from a in users
                 where a.Id == ID
                 select a.FollowingNum).Single();
            return n;
        }
        public static string UserName()
        {
            string n;
            users = LoadUsers();
            n = (from a in users
                 where a.Id == ID
                 select a.Name).Single();
            return n;
        }
        public static string Profile()
        {
            string n;
            users = LoadUsers();
            n = (from a in users
                 where a.Id == ID
                 select a.Profile).Single();
            return n;
        }
        public static List<User> LoadUsers()
        {
            string userDataFile = "Data/User.xml";
            using (Stream stream = GetResourceStream(userDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                        (from userElem in XDocument.Load(xmlRdr).Element("users").Elements("user")
                         select User.CreateUser(
                             (string)userElem.Attribute("id"),
                             (string)userElem.Attribute("password"),
                             (string)userElem.Attribute("name"),
                             (string)userElem.Attribute("show"),
                             (int)userElem.Attribute("followerNum"),
                             (int)userElem.Attribute("followingNum"),
                             (int)userElem.Attribute("postNum"),
                             (string)userElem.Attribute("profile")
                             )).ToList();
        }
        static Stream GetResourceStream(string userDataFile)
        {
            Uri uri = new Uri(userDataFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + userDataFile);

            return info.Stream;
        }
    }
}