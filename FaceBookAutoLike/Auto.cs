using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FaceBookAutoLike
{
    public class Auto
    {
        public string Token { get; set; }
        public string Version { get; set; }


        public async void AutoReactFriends(string type, int delayTimeUser, int delayTimePost,int limitPost)
        {
            var cUser =  GetCurrentUser();
            var friends = await GetFriendsAsync();
            foreach (var user in friends.data)
            {
                AutoReactionToUser(user,type,delayTimePost,limitPost);
                await Task.Delay(delayTimeUser);
            }
            
        }

        public async Task AutoReactionToUser(User user,string type,int delayTime, int limit)
        {
                var posts = await GetPostsTask(user.Id, limit);
            foreach (var post in posts.data)
            {
                ReactTask(user,post, type);
                Thread.Sleep(delayTime);
            }
        }

        private async Task ReactTask(User user,Post post, string typeReact)
        {
            var fbClient = new FacebookClient()
            {
                AccessToken = Token
            };
                var url = $"https://graph.facebook.com/{Version}/{post.Id}/reactions";
                var js = fbClient.Post(url, new { type = typeReact });
                var rs = JObject.FromObject(js).GetValue("success").ToString().ToLowerInvariant();
                var message = rs.Equals("true")
                    ? user.Name + "_" + post.Id + post.Message +" : OK"
                    : user.Name + "_" + post.Id + ": Fail";
                WriteResultToFile(message);

        }

        public bool Comment(Post post)
        {
            return false;
        }


        private Task<Friends> GetFriendsAsync()
        {
            var url = $"https://graph.facebook.com/{Version}/me/friends?limit=100";
            var fbClient = new FacebookClient()
            {
                AccessToken = Token
            };
            var js = fbClient.Get(url);
            dynamic page = JObject.FromObject(js).GetValue("paging");
            var friends = JsonConvert.DeserializeObject<Friends>(js.ToString());
            var next = page["next"].ToString();
            var list = new List<User>();
            list.AddRange(friends.data);
            while (!string.Equals(next, null, StringComparison.Ordinal))
            {
                js = fbClient.Get(next);
                friends = JsonConvert.DeserializeObject<Friends>(js.ToString());
                list.AddRange(friends.data);
                page = JObject.FromObject(js).GetValue("paging");
                next = page["next"]?.ToString();
            }
           
            friends.data = list;
            return Task<Friends>.Factory.StartNew(() =>friends);
        }

        private User GetCurrentUser()
        {
            var url = $"https://graph.facebook.com/{Version}/me";
            var fbClient = new FacebookClient()
            {
                AccessToken = Token
            };
            var js = fbClient.Get(url);
            var user = JsonConvert.DeserializeObject<User>(js.ToString());
            return user;
        }

        private Task<Posts> GetPostsTask(string userId,int limit)
        {
            var url = $"https://graph.facebook.com/{Version}/{userId}/posts?limit={limit}";
            var fbClient = new FacebookClient()
            {
                AccessToken = Token
            };
            var js = fbClient.Get(url);
            var posts = JsonConvert.DeserializeObject<Posts>(js.ToString());
            return Task<Posts>.Factory.StartNew(() => posts);
        }

        private void WriteResultToFile(string result)
        {
            using (var sw = File.AppendText("Result.txt"))
            {
                if (result != null) sw.WriteLineAsync(result.ToString());
            }
        }

        public Group GetGroup(string id)
        {
            var url = $"https://graph.facebook.com/{Version}/{id}";
            var fbClient = new FacebookClient()
            {
                AccessToken = Token
            };
            var js = fbClient.Get(url);
            var group = JsonConvert.DeserializeObject<Group>(js.ToString());
            return group;
        }
    }
}
