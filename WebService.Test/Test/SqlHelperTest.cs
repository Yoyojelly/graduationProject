using Xunit;
using WebService.Sql;

namespace WebService.Test
{
    public class SqlTest
    {
        private readonly SqlHelper sqlHelper;

        public SqlTest()
        {
            sqlHelper = new SqlHelper();
        }

        [Fact]
        public void OpenTest()
        {
            var result = sqlHelper.Open();

            Assert.True(result,"Sql.Open is false");
        }
        
    }
}