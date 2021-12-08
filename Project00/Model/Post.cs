using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.Model
{
    class Post
    {
        public static Post CreateNewPost()
        {
            return new Post();
        }
        public static Post CreatePost(
            string user,
            string img,
            string text)
        {
            return new Post
            {
                User = user,
                Img = img,
                Text = text
            };
        }
        protected Post() { }
        public string User { get; set; }
        public string Img { get; set; }
        public string Text { get; set; }
    }
}
