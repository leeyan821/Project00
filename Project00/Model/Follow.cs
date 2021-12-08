using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.Model
{
    public class Follow
    {
        public static Follow CreateNewFollow()
        {
            return new Follow();
        }
        public static Follow CreateFollow(
            string userId,
            string following)
        {
            return new Follow
            {
                UserId = userId,
                Following = following
            };
        }
        public string UserId { get; set; }
        public string Following { get; set; }
    }
}
