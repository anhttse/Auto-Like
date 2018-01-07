using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using FaceBookAutoLike.FaceBookModels;
using Newtonsoft.Json;

namespace FaceBookAutoLike.FaceBookFuncs
{
    public static class FaceBook
    {

        //GET...
        public static Post GetPost(string id)
        {
            try
            {
                var fb = new FacebookClient {AccessToken = Common.Token};
                var curl = Common.CUrl(id, null);
                var rs = fb.Get(curl);
                return JsonConvert.DeserializeObject<Post>(rs.ToString());
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public static Posts GetPosts(string id,string limit)
        {
            try
            {
                var fb = new FacebookClient { AccessToken = Common.Token };
                var curl = Common.CUrl(id, $"posts?limit={limit}");
                var rs = fb.Get(curl);
                return JsonConvert.DeserializeObject<Posts>(rs.ToString());
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public static Feeds GetFeeds(string target, string limit)
        {
            try
            {
                var fb = new FacebookClient {AccessToken = Common.Token};
                var curl = Common.CUrl($"{target}", $"feed?fields=from,message,created_time&limit={limit}");
                var rs = fb.Get(curl);
                return JsonConvert.DeserializeObject<Feeds>(rs.ToString());
            }
            catch (Exception e)
            {

                return null;
            }
            
        }
        public static Feeds GetHome(Friends friends, string limit)
        {
            try
            {
                var fb = new FacebookClient { AccessToken = Common.Token };
                var curl = Common.CUrl($"me", $"home?fields=from,message,created_time&limit={limit}");
                var rs = fb.Get(curl);
                var frIds = friends.data.Select(x => x.Id).ToList();
                var home = JsonConvert.DeserializeObject<Feeds>(rs.ToString());
                var ids = home.data.Select(x => x.from.Id).ToList();
                
                //home.data = data;
                return home;
            }
            catch (Exception e)
            {

                return null;
            }

        }
        public static Friends GetFriends(string target, string limit)
        {
            try
            {
                var fb = new FacebookClient { AccessToken = Common.Token };
                var curl = Common.CUrl($"{target}", $"friends?limit={limit}");
                var rs = fb.Get(curl);
                return JsonConvert.DeserializeObject<Friends>(rs.ToString());
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public static Comments GetComments(string target, string limit)
        {
            try
            {
                var fb = new FacebookClient { AccessToken = Common.Token };
                var curl = Common.CUrl($"{target}", $"commens?limit={limit}");
                var rs = fb.Get(curl);
                return JsonConvert.DeserializeObject<Comments>(rs.ToString());
            }
            catch (Exception e)
            {

                return null;
            }
        }
        
    }
}
