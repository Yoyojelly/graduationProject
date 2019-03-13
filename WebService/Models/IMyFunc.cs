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
        //对象是按引用传递的，所以调用的时候先实例化一个T。
        bool SelectById(int id,T t);
        //把检索到的数据转化成对象
        bool ParseRow(MySqlDataReader row,T t);
        //通过对象检索数据
        //填充该对象
        bool SingleSelect(T t);
    }
 
}