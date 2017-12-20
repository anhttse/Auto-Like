using System.Collections.Generic;

namespace FaceBookAutoLike
{
    public class Post
    {
        public string Id { get; set; }
        public string Created_time { get; set; }
        public string Message { get; set; }
    }

    public class Posts
    {
        public  IEnumerable<Post> data { get; set; }
    }
}
