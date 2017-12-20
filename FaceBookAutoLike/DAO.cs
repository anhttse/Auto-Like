using System.Collections.Generic;
using System.Data.SqlClient;

namespace FaceBookAutoLike
{
    public class DAO
    {
//        public DAO(string dbSource, string dbName, string user, string pwd)
//        {
//        }
        //public Friends GetFriends(string token)
        //{
            
        //}


        

        private SqlConnection GetConnection(string dbSource, string dbName, string user, string pwd)
        {
            var cnnS = $"Data Source={dbSource};Initial Catalog={dbName};Persist Security Info=True;User ID={user};Password={pwd}";
            return new SqlConnection(cnnS);
        }

        private SqlDataReader Reader(SqlConnection sqlC, string queryString)
        {
            SqlCommand command = new SqlCommand(queryString, sqlC);
            return command.ExecuteReader();
        }


        public Posts GetPosts(string token, string dbSource, string dbName, string user, string pwd)
        {
            List<Post> lP = new List<Post>();

            using (var cnn = GetConnection(dbSource, dbName, user, pwd) )
            {
                
            }
        }



    }
}
