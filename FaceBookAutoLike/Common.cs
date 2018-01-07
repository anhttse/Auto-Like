using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookAutoLike
{
    public static class Common
    {
        public enum TargetComments
        {
            Group = 0,
            FriendPost = 1,
            YourPost = 2,
            ReplyCommentInYourPost = 3
        }

        public static string Token { get; set; }
        public static string Version { get; set; }

        public static string CUrl(string target, string fields)
        {
            var url = $"https://graph.facebook.com/{Version}/{target}/{fields}";
            return url;
        }
    }
}
