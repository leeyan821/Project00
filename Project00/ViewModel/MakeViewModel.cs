using Project00.DataAccess;
using Project00.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Project00.ViewModel
{
    public class MakeViewModel : INotifyPropertyChanged
    {
        private static string img;

        public static string Img
        {
            get { return img; }
            set
            {
                img = value;
            }
        }
        private static string te;

        public string Te
        {
            get { return te; }
            set { 
                te = value;
                OnPropertyChanged("Te");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public static void AddPost()
        {
            //int n1 = PostAccess.CountPost();
            string u = UserStore.ID;
            try
            {
               /* XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@"C:\Users\dkdud\source\repos\Project00\Project00\Data\Post.xml");
                XmlNode node = xmlDoc.DocumentElement;
                XmlElement child = xmlDoc.CreateElement("post");
                child.SetAttribute("user", u);
                child.SetAttribute("image", img);
                child.SetAttribute("text", te);
                node.AppendChild(child);
                xmlDoc.Save(@"C:\Users\dkdud\source\repos\Project00\Project00\Data\Post.xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\Users\dkdud\source\repos\Project00\Project00\Data\User.xml");
                XmlNode node1 = doc.SelectSingleNode("/descendant::users/user");
                XmlAttributeCollection acxNode = node1.Attributes;
                if (acxNode.GetNamedItem("postNum") != null)
                    acxNode.GetNamedItem("postNum").Value = n1.ToString();
                doc.Save(@"C:\Users\dkdud\source\repos\Project00\Project00\Data\User.xml");
               */
                int pp2 = NewData.NewUsers.Single(x => x.Id == UserStore.ID).PostNum;
                NewUser ne = NewData.NewUsers.Single(x => x.Id == UserStore.ID);

                ne.PostNum = pp2 + 1;
                NewData.Save();
                int num = NewData.NewPosts.Count() + 1;

                NewPost po = new NewPost()
                {
                    User = UserStore.ID,
                    Image = img,
                    Text = te,
                    Num = num
                };
                NewData.NewPosts.Add(po);
                NewData.Save();
            }
            catch (XmlException xe) { }       
        }
    }
}
