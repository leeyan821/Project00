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
    class FollowAccess
    {
        private static List<Follow> follows;

        static FollowAccess()
        {
            follows = LoadFollows();
        }

        public static bool SearchPro(string id, string search)
        {
            List<Follow> follows = LoadFollows();
            bool re = false;
            var pro = (from a in follows
                       where a.UserId == id
                       select a).ToList();
            foreach(var a in pro)
            {
                if(a.Following == search)
                    re = true;
            }
            return re;
        }

        public static List<Follow> LoadFollows()
        {
            string followDataFile = "Data/Follow.xml";
            using (Stream stream = GetResourceStream(followDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                        (from followElem in XDocument.Load(xmlRdr).Element("follows").Elements("follow")
                         select Follow.CreateFollow(
                             (string)followElem.Attribute("userId"),
                             (string)followElem.Attribute("following")
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
