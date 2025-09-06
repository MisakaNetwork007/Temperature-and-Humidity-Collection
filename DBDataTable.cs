using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature_and_Humidity_Collection
{
    internal class DBDataTable
    {
    }


    #region 无用，仅作对照说明
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("UserInformationTable")]
    public class UserInformation
    {
        public int uid;                 //账户uid，自增主键
        public string user_account;     //账号
        public string user_password;    //密码
        public string user_name;        //昵称
        public byte user_access_level;  //权限等级 1:普通， 2：高级， 3：管理员
    }

    /// <summary>
    /// 数据信息
    /// </summary>
    [Table("DataTable")]
    public class Data1111
    {
        public int id;                  //自增主键
        public float temperature;       //温度
        public float humidity;          //湿度
        public DateTime datetime;       //时间
    }

    /// <summary>
    /// 登录登出信息
    /// </summary>
    [Table("LoginInformationTable")]
    public class LoginInformation
    {
        public int uid;                 //账户uid
        public DateTime datetime;       //时间
        public bool login_or_logout;    //登录 = 1 ， 登出 = 0
        public bool status;             //状态，失败 = 0，成功 = 1
        public short error_code;        //错误码
    }

    /// <summary>
    /// 操作日志信息
    /// </summary>
    [Table("OperationLogTable")]
    public class OperationLog
    {
        public int id;                  //自增主键
        public int uid;                 //操作者uid
        public DateTime dateTime;       //时间
        public short operation_code;     //操作码
        public bool status;             //状态，失败 = 0， 成功 = 1
        public int? p_uid;              //被操作者uid
        public string? p_user_account;   //被操作者账号
        public string? p_user_password;  //被操作者密码
        public string? p_user_name;      //被操作者昵称
        public byte? p_user_access_level;//被操作者权限等级 1:普通， 2：高级， 3：管理员
        public short error_code;        //错误码
    }

    #endregion
}
