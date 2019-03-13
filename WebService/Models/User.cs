using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebService.Models
{
    public class User : IFormattable
    {
        //
        public uint? user_id { get; set; }
        //昵称
        public string user_name { get; set; }
        //用户名
        public string user_code { get; set; }
        //密码
        public string user_pwd { get; set; }

        //字符串插值时根据传过来的东西动态生成语句

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "user_id":
                    if (this.user_id == null)
                    {
                        return "where user_id = '%'";
                    }
                    else
                    {
                        return $"where user_id = '{user_id}'";
                    }
                case "user_name":
                    if (this.user_name == null)
                    {
                        return "";
                    }
                    else
                    {
                        return $"and user_name = '{user_name}'";
                    }
                case "user_code":
                    if (this.user_code == null)
                    {
                        return "";
                    }
                    else
                    {
                        return $"and user_code = '{user_code}'";
                    }
                case "user_pwd":
                    if (this.user_pwd == null)
                    {
                        return "";
                    }
                    else
                    {
                        return $"and user_pwd = '{user_pwd}'";
                    }
                default:
                    throw new FormatException($"invalid format string {format}");
            }
        }
    }

    public class UserFunc : IMyFunc<User>
    {
        #region 字段和构造函数
        //连接字符串  "Server=(localdb)\\mssqllocalbd;Database=MyWebDb;uid=Fan;pwd=5220349"
        private string connectionStr { get; }
        public string ConnectionStr => connectionStr;

        public UserFunc()
        {
            connectionStr = "Server=127.0.0.1;Database=MyWebDb;uid=root;pwd=Fan5220349";
        }
        #endregion

        //通过id检索数据
        public bool SelectById(int id,User user)
        {
            var row = MySqlHelper.ExecuteReader(connectionStr, "select * from user where user_id=" + id);
            if (ParseRow(row,user))
            {
                row.Close();
                return true;
            }
            else
            {
                row.Close();
                return false;
            }
        }

        //通过对象来检索数据
        public bool SingleSelect(User user)
        {
            //动态生成查询语句，需要User类继承IFormattable接口，并实现ToString方法。
            var row = MySqlHelper.ExecuteReader(connectionStr,
            $"select * from user {user:user_id} {user:user_pwd} {user:user_name} {user:user_code}");
            if (ParseRow(row,user))
            {
                row.Close();
                return true;
            }
            else
            {
                row.Close();
                return false;
            }
        }

        ///<summary>
        ///把数据行转化成User对象
        ///把第一行转化成对象并返回给user。（只返回第一行）并将row的指针移动到下一行。
        ///转化成功返回true,转化失败返回false.
        ///</summary>
        public bool ParseRow(MySqlDataReader row,User user)
        {
            if (row.Read())
            {
                user.user_id = (UInt32)row["user_id"];
                user.user_name = (string)row["user_name"];
                user.user_code = (string)row["user_code"];
                user.user_pwd = (string)row["user_pwd"];
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}