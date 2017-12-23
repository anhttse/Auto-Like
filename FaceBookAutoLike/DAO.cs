using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace FaceBookAutoLike
{
    public class Dao
    {
        /*
        public string DbSource { get; set; }
        public string DbName { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }

        private SqlConnection GetConnection()
        {
            try
            {
                var cnnS =
                    $"Data Source={DbSource};Initial Catalog={DbName};Persist Security Info=True;User ID={User};Password={Pwd}";
                return new SqlConnection(cnnS);
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }

        }

        private SqlDataReader Reader(string queryString)
        {
            try
            {
                using (var cnn = GetConnection())
                {
                        cnn.Open();
                    var command = new SqlCommand(queryString, cnn);

                    var reader = command.ExecuteReader();
                    return reader;
                }

            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }
        }

        #region POSTS

        public Posts GetTopIdPostsFromDb(int topLimit)
        {
            var qr = $"select top {topLimit} P_ID,P_Time,Message from PL where Done <> 1 orderby P_Time";
            var lP = new List<Post>();
            try
            {
                using (var reader = Reader(qr))
                {
                    if (!reader.HasRows)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        lP.Add(new Post(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                    }
                    return new Posts { data = lP };
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }

        }
        public Posts GetidPostsFromDbByFId(string fid,int limit)
        {
            var qr = $"select top {limit} P_ID,P_Time,Message from PL where F_ID = '{fid}' and Done <> 1 orderby P_Time";
            var lP = new List<Post>();
            try
            {
                using (var reader = Reader(qr))
                {
                    if (!reader.HasRows)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        lP.Add(new Post(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                    }
                    return new Posts { data = lP };
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }

        }

        public bool InsertPost(string pId, string pTime, string fId, string message)
        {
            try
            {
                var qr = $"insert into PL(P_ID,P_Time,F_ID, Message) select '{pId}','{pTime}','{fId}','{message}'"
                         + $" where not exists (select P_ID from PL where P_ID = '{pId}')";
                using (var cnn = GetConnection())
                {
                    cnn.Open();
                    var cmm = new SqlCommand(qr, cnn);
                    var rs = cmm.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return false;
            }
        }

        public bool UpdatePost(string pId, bool done)
        {
            try
            {
                var qr = "Update PL "
                        + $"Set Done = {done},Done_Time = '{DateTime.Now}'"
                        +$"where P_ID = '{pId}'";
                using (var cnn = GetConnection())
                {
                    cnn.Open();
                    var cmm = new SqlCommand(qr, cnn);
                    var rs = cmm.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return false;
            }
        }
        #endregion

        #region Friends


        public Friends GetidFriendsFromDb(string fId)
        {
            var qr = $"select F_ID,Name from FL where F_OF_ID = '{fId}'";
            var lP = new List<User>();
            try
            {
                using (var reader = Reader(qr))
                {
                    //if (!reader.HasRows)
                    //{
                    //    return null;
                    //}
                    while (reader.Read())
                    {
                        lP.Add(new User(reader.GetString(0), reader.GetString(1)));
                    }
                    return new Friends() { data = lP };
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return null;
            }

        }

        public bool InserFriend(string fid, string name, string userId)
        {
            try
            {
                var qr = $"insert into FL(F_ID,Name,F_OF_ID) select '{fid}',N'{name.Replace("'","''")}','{userId}'"
                         + $" where  not exists (select F_ID from FL where F_ID = '{fid}')";
                using (var cnn = GetConnection())
                {
                    cnn.Open();
                    var cmm = new SqlCommand(qr, cnn);
                    var rs = cmm.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return false;
            }
        }

        public bool UpdateFriendLikeCount(string fId)
        {
            try
            {
                var qr = "Update FL "
                        + $"Set LC = (LC+1) where F_ID = '{fId}'";
                using (var cnn = GetConnection())
                {
                    cnn.Open();
                    var cmm = new SqlCommand(qr, cnn);
                    var rs = cmm.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return false;
            }
        }

        #endregion

        #region Token

        public bool InserToken(string userId, string name, string token)
        {
            try
            {
                var qr = $"insert into Token(User_ID,Name,Token) select '{userId}' as user_id,'{name}' as name,'{token}' as token"
                         + $" where not exists (select User_ID from Token where user_id = '{userId}')";
                using (var cnn = GetConnection())
                {
                    cnn.Open();
                    var cmm = new SqlCommand(qr, cnn);
                    var rs = cmm.ExecuteNonQuery();
                    return rs > 0;
                }
            }
            catch (Exception e)
            {
                Utilities.WriteLog(e.Message);
                return false;
            }
        }

        public string GetUId(string token)
        {
            using (var cnn = GetConnection())
            {
                if(cnn.State == ConnectionState.Closed) cnn.Open();
                var query = $"select top 1 User_ID from Token where Token like '{token}'";
                var cmm = new SqlCommand(query, cnn);
                var reader = cmm.ExecuteReader();
                if (reader.Read())
                    return reader.GetString(0);
                return null;
            }
        }

        #endregion
    */

        public void InsertToken(Token token)
        {
            using (var db = new FBLEntities())
            {
                db.Tokens.Add(token);
                db.SaveChanges();
            }
        }

        public string GetCurrentUserId(string token)
        {
            using (var db = new FBLEntities())
            {
                try
                {
                    var user = db.Tokens.FirstOrDefault(x => x.Token1.Contains(token));
                    return user?.User_ID;
                }
                catch (Exception e)
                {
                    Utilities.WriteLog(e.Message);
                    return null;
                }
                
            }
        }

        public void InsertFriends(Friends friends, string cUId)
        {
            using (var db = new FBLEntities())
            {
                var frs = friends.data;
                foreach (var f in frs)
                {
                    if (!db.FLs.Any(x => x.F_ID == f.Id))
                    {
                        db.FLs.Add(new FL() {F_ID = f.Id, F_OF_ID = cUId, Name = f.Name});
                    }
                }
                db.SaveChanges();
            }
           
        }

        public void UpdateLc(string fId)
        {
            using (var db = new FBLEntities())
            {
                var en = db.FLs.FirstOrDefault(x => x.F_ID == fId);
                if (en != null) en.LC = ++en.LC;
                db.SaveChanges();
            }
        }

        public IEnumerable<string> GetFriendIdList(string cUId)
        {
            using (var db = new FBLEntities())
            {
                return db.FLs.Where(x => x.F_ID == cUId).Select(x => x.F_ID).ToList();
            }
        }

        public void InsertPostDone(Post post)
        {
            using (var db = new FBLEntities())
            {
                if (!db.PLs.Any(x => x.P_ID == post.Id))
                {
                    db.PLs.Add(new PL() { P_ID = post.Id,  P_Time = post.Created_time,F_ID = post.Id.Substring(0, post.Id.IndexOf("_")),Message = post.Message,Done_Time = DateTime.Now.ToString()});
                }
                db.SaveChanges();
            }
        }

        public List<string> GetPostDoneOfF(string fId)
        {
            using (var db = new FBLEntities())
            {
                return db.PLs.Where(x => string.Equals(x.F_ID, fId)).Select(x => x.P_ID).ToList();
            }
        }

        public void UpdatePostStatus(string pId)
        {
            using (var db = new FBLEntities())
            {
                var p = db.PLs.FirstOrDefault(x => x.P_ID == pId);
                if (p != null)
                {
                    p.Done = true;
                    p.Done_Time = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                    db.SaveChanges();
                }
            }
        }
        public IEnumerable<string> GetIdPostListByFId(string fId,int limit)
        {
            using (var db = new FBLEntities())
            {
                return db.PLs.Where(x => x.F_ID == fId).OrderBy(x=>x.P_Time).Take(limit).Select(x => x.P_ID).ToList();
            }
        }

        internal void InsertCommentDone(string idTocomment, string uId, string uCId,  string message, int cltype)
        {
            var cl = new CL() { P_ID = idTocomment, P_OF_ID = uId, U_CM_ID = uCId,Message = message, CL_TYPE = cltype};
            using (var db = new FBLEntities())
            {
                if(!db.CLs.Any(x=>string.Equals(x.P_ID, idTocomment)))
                    db.CLs.Add(cl);
                db.SaveChanges();
            }
        }

        public List<string> GetCommentDoneList(int typeC)
        {
            using (var db = new FBLEntities())
            {
                var lst = db.CLs.Where(c=>c.CL_TYPE==typeC).Select(x => x.P_ID).ToList();
                return lst;
            }
        }
        public string GetCurrentIdDb(string token)
        {
            using (var db = new FBLEntities())
            {
                return db.Tokens.FirstOrDefault(x => string.Equals(x.Token1, token))?.User_ID;
            }
        }
    }
    
}
