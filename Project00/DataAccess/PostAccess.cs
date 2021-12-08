using Project00.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;

namespace Project00.DataAccess
{
    class PostAccess
    {
        static List<Post> posts;
        public static int Pn;
        static PostAccess()
        {
            posts = LoadPosts();
        }
        public static int CountPost()
        {
            posts = LoadPosts();
            var re = (from te in posts
                      where te.User == UserStore.ID
                      select te).ToList();
            int num = 0;
            foreach(var a in re)
            {
                num++;
            }
            Pn = num - 1;
            return num;
        }
        
        public static List<Post> LoadPosts()
        {
            string postDataFile = "Data/Post.xml";
            using (Stream stream = GetResourceStream(postDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                        (from postElem in XDocument.Load(xmlRdr).Element("posts").Elements("post")
                         select Post.CreatePost(
                             (string)postElem.Attribute("user"),
                             (string)postElem.Attribute("image"),
                             (string)postElem.Attribute("text")
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