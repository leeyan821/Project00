using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.Model
{
    public class User
    {
        public static User CreateNewUser()
        {
            return new User();
        }
        public static User CreateUser(
            string id,
            string password,
            string name,
            string show,
            int followerNum,
            int followingNum,
            int postNum,
            string profile)
        {
            return new User
            {
                Id = id,
                Password = password,
                Name = name,
                Show = show,
                FollowerNum = followerNum,
                FollowingNum = followingNum,
                PostNum = postNum,
                Profile = profile
            };
        }
        protected User() { }
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Show { get; set; }
        public int FollowerNum { get; set; }
        public int FollowingNum { get; set; }
        public int PostNum { get; set; }
        public string Profile { get; set; }
    }
}
