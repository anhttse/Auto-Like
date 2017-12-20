using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FaceBookAutoLike
{
    public class DAO
    {



        private SqlConnection _cnn;

        public DAO(string dataSource, string dbName, string username, string pwd)
        {
            _cnn = GetConnection(dataSource, dbName, username, pwd);
        }
        


        private SqlConnection GetConnection(string dataSource, string dbName, string username, string pwd)
        {
            try
            {
                var scnn = $"Data Source={dataSource};Initial Catalog={dbName};Persist Security Info=True;User ID={username};Password={pwd}";
                return new SqlConnection(scnn);
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            
        }

        private SqlDataReader Reader(string query)
        {
            try
            {
                if (_cnn.State == System.Data.ConnectionState.Closed)
                {
                    _cnn.Open();
                }
                SqlCommand cmm = new SqlCommand(query, _cnn);
                var reader = cmm.ExecuteReader();

                if (_cnn.State == System.Data.ConnectionState.Open)
                {
                    _cnn.Close();
                }
                return reader;
            }catch(Exception e)
            {

            }
        }
    }
}
