using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FaceBookAutoLike
{
    public class Auto
    {
        public string Token { private get; set; }
        public string Version { private get; set; }
        public string FId { get; set; }
        private readonly Dao _dao;
        public Auto()
        {
            _dao = new Dao();
        }
        public CancellationTokenSource TokenSource { get => tokenSource; set => tokenSource = value; }

        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public async void AutoReactFriends(PictureBox pic, string type, int delayTimeUser, int delayTimePost, int limitPost, CancellationToken ctoken)
        {
            //var cUser = GetCurrentUser();
            var friends = GetFriends();
            var lTasks = new List<Task<bool>>();
            foreach (var user in friends.data)
            {
                try
                {
                    var task = AutoReactionToUser(user, type, delayTimePost, limitPost, ctoken);
                    lTasks.Add(task);
                }
                catch (Exception e)
                {
                    WriteResultToFile(e.Message);
                }

                Thread.Sleep(delayTimeUser);
            }
            await Task.WhenAll(lTasks);
            pic.Image = global::FaceBookAutoLike.Properties.Resources.tick_green;

        }

        private Task<bool> AutoReactionToUser(User user, string type, int delayTime, int limit, CancellationToken ctoken)
        {
            var posts = GetPosts(user.Id, limit);
            var listPostDone = _dao.GetPostDoneOfF(user.Id);
            posts.data = posts.data.Where(x => !listPostDone.Contains(x.Id));
            if (!posts.data.Any())
            {
                return null;
            }

            foreach (var post in posts.data)
            {
                var message = React(user, post, type);
                WriteResultToFile(message);
                Thread.Sleep(delayTime);
            }
            return Task.Factory.StartNew(() => true, ctoken);
            //            return Task.Factory.StartNew(() => true);
        }

        private string React(User user, Post post, string typeReact)
        {
            var message = "";
            try
            {
                var fbClient = new FacebookClient()
                {
                    AccessToken = Token
                };
                var url = $"https://graph.facebook.com/{Version}/{post.Id}/reactions";
                var js = fbClient.Post(url, new { type = typeReact });
                var rs = JObject.FromObject(js).GetValue("success").ToString().ToLowerInvariant();
                if (rs.Equals("true"))
                {
                    _dao.InsertPostDone(post);
                }
                message = rs.Equals("true")
                   ? user.Name + "_" + post.Id + post.Message + " : OK"
                   : user.Name + "_" + post.Id + ": Fail";
            }
            catch (Exception e)
            {
                message = e.Message;
                // ignored
            }
            return message;
        }

        public bool Comment(Post post)
        {
            return false;
        }


        private Friends GetFriends()
        {
            Friends friends = new Friends();
            try
            {
                var url = $"https://graph.facebook.com/{Version}/me/friends?limit=100";
                var fbClient = new FacebookClient()
                {
                    AccessToken = Token
                };
                var js = fbClient.Get(url);
                dynamic page = JObject.FromObject(js).GetValue("paging");
                friends = JsonConvert.DeserializeObject<Friends>(js.ToString());
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
            }
            catch (Exception e)
            {
                WriteResultToFile(e.Message);
            }

            return friends;
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

        private Posts GetPosts(string userId, int limit)
        {
            var url = $"https://graph.facebook.com/{Version}/{userId}/posts?limit={limit}";
            var fbClient = new FacebookClient()
            {
                AccessToken = Token
            };
            var js = fbClient.Get(url);
            var posts = JsonConvert.DeserializeObject<Posts>(js.ToString());
            return posts;
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

        private Task<string> CommentGroupTask(string idTocomment, string uId, string message)
        {
            var rsm = "";
            try
            {
                var fbClient = new FacebookClient()
                {
                    AccessToken = Token
                };
                var url = $"https://graph.facebook.com/{Version}/{idTocomment}/comments";
                var js = fbClient.Post(url, new { message = message });
                var rs = JObject.FromObject(js).GetValue("success").ToString().ToLowerInvariant();
                if (rs.Equals("true"))
                {
                    var uCId = _dao.GetCurrentUserId(Token) ?? GetCurrentUser().Id;
                    _dao.InsertCommentDone(idTocomment, uId, uCId, message);
                }
                var ms = DateTime.Now.ToString(CultureInfo.CurrentCulture) + "-" + idTocomment;
                rsm = rs.Equals("true")
                   ? ms + " : OK"
                   : ms + ": Fail";
                WriteResultToFile(rsm);
            }
            catch (Exception e)
            {
                rsm = e.Message;
                // ignored
            }
            return Task.Factory.StartNew(() => rsm);
        }

        public async Task<string> AutoCommentPostOfGroup(string gId, int limit, string message, int delayTime, List<string> mFilter)
        {
            try
            {
                var gr = getGroupInfo(gId);
                var feeds = GetGroupFeeds(gId, limit, mFilter);
                List<Task> lstTasks = new List<Task>();
                Task<string> rs = null;
                foreach (var feed in feeds.data)
                {
                    rs = CommentGroupTask(feed.Id, feed.from.Id, message);
                    lstTasks.Add(rs);
                    lstTasks.Add(Task.Delay(delayTime));

                }
                await Task.WhenAll(lstTasks);
                WriteResultToFile($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}-Comment to {gr.Name}: done");
                return rs.Result;
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }


        }

        private Feeds GetGroupFeeds(string gId, int limit, List<string> mFilter)
        {
            try
            {
                var uCId = _dao.GetCurrentUserId(Token) ?? GetCurrentUser().Id;
                var url = $"https://graph.facebook.com/{Version}/{gId}/feed?fields=from,message,created_time&limit={limit}";
                var fbClient = new FacebookClient()
                {
                    AccessToken = Token
                };
                var js = fbClient.Get(url);
                var feeds = JsonConvert.DeserializeObject<Feeds>(js.ToString());
                var listCommentDone = _dao.GetCommentDoneList();
                var data = feeds.data.Where(x => mFilter.Any(mf => Utilities.convertToUnSign3(x.Message).Contains(mf))&& !x.from.Id.Contains(uCId)).ToList();
                feeds.data = data.Where(x => !listCommentDone.Contains(x.Id)).ToList();
                return feeds;
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }
        }

        private Group getGroupInfo(string gId)
        {
            try
            {
                var url = $"https://graph.facebook.com/{Version}/{gId}";
                var fbClient = new FacebookClient()
                {
                    AccessToken = Token
                };
                var js = fbClient.Get(url);
                var gr = JsonConvert.DeserializeObject<Group>(js.ToString());
                return gr;
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }
        }


    }
}
