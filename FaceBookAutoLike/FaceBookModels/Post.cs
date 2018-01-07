using System.Collections.Generic;

namespace FaceBookAutoLike
{
    public class Post
    {
        public string Id { get; set; }
        public string Created_time { get; set; }
        public string Message { get; set; }

        //public Post(string id, string createdTime, string message)
        //{
        //    Id = id;
        //    Created_time = createdTime;
        //    Message = message;
        //}
    }

    public class Posts
    {
        public  IEnumerable<Post> data { get; set; }
    }
}
