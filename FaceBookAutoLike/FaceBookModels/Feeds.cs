using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookAutoLike
{
    public class Feeds
    {
         public IEnumerable<Feed> data { get; set; }
    }

    public class Feed:Post
    {
        public User from { get; set; }

        //public Feed(string id, string createdTime, string message) : base(id, createdTime, message)
        //{
        //}
    }

}
