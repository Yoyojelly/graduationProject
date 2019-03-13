using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebService.Models
{
    public interface IMyFunc<T>
    {
        ///<summary>
        ///连接字符串属性
        ///</summary>
        string ConnectionStr {get;}
        ///<summary>
        ///通过ID搜索模型并返回模型
        ///对象是按引用传递的，所以调用的时候先实例化一个T。
        ///</summary>
        bool SelectById(int id,T t);
        ///<summary>
        ///通过对象检索数据
        ///填充该对象
        ///</summary>
        bool SingleSelect(T t);


        ///<summary>
        ///
        ///</summary>
    }
 
    //解析各种数据行
    public interface IMyParse<T>
    {
        ///<summary>
        ///把检索到的第一行数据转化成T对象
        ///</summary>
        bool ParseRow(MySqlDataReader row,T t);
        ///<summary>
        ///把检索到的所有数据转化成List<T>
        ///</summary>
        bool ParseRow(MySqlDataReader row,List<T> t);

    }
}