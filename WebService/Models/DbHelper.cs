using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebService
{
    class SqlHelper
    {
        private string connectionString = @"server=58.87.111.166:3306;uid=FanGuodong;password=123456;database=MyTest";

        public bool MyTest()
        {
            var connection = new SqlConnection(connectionString);
            try{
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}