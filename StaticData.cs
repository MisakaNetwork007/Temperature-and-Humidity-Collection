using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temperature_and_Humidity_Collection.Models;

namespace Temperature_and_Humidity_Collection
{
    public static class StaticData
    {
        public static UserInformationTable currentUser = new UserInformationTable();
        public static SynchronizationContext? uiSyncContext;

        public static string GetIdentityName(int level)
        {
            switch (level)
            {
                case 1:
                    return "组员";
                case 2:
                    return "组长";
                case 3:
                    return "管理员";
                default:
                    return "";
            }
        }

        public static byte GetIdentityLevel(string identityName)
        {
            switch (identityName)
            {
                case "管理员":
                    return 3;
                case "组长":
                    return 2;
                case "组员":
                    return 1;
                default:
                    return 0;
            }
        }
    }

    public enum ErrorCode
    {
        None = 100,
        AccountError = 101,  //登录账号错误
        PasswordError = 102,  //登录密码错误
        AccessLevelError = 201,  //权限不足
        PAccountError = 301,  //被操作者账号已存在
        DBTableError = 501,  //数据表错误
        DBConncetError = 502,   //数据库连接错误
        DBSaveChangesError = 503    //保存更改错误
    }

    public enum OperationCode
    {
        Login = 100,    //登录
        Logout = 101,   //登出
        MonitorData = 200,  //监控数据，主界面
        InspectData = 201,  //检查数据，往期数据
        AddUser = 301,  //添加用户
        UpdateUser = 302,  //更新用户
        DeleteUser = 303   //删除用户
    }

    /// <summary>
    /// 当前界面
    /// </summary>
    public enum CurrentInterface
    {
        NowData,
        HistoricalTrend,
        DisplayLog,
        UserManagent
    }
}
