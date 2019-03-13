using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebService.Models
{
    public interface IMyFunc<T>
    {
        //连接字符串
        string ConnectionStr {get;}
        //通过ID搜索模型并返回模型
        bool SelectById(int id,out T t);
        //把检索到的数据转化成对象
        bool ParseRow(MySqlDataReader row,out T t);
        //通过对象检索数据
        bool Select(T t);
    }
 
}