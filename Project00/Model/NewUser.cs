using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.Model
{
    class NewUser
    {
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
