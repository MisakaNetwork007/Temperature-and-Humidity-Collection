using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temperature_and_Humidity_Collection.Data;
using Temperature_and_Humidity_Collection.Models;

namespace Temperature_and_Humidity_Collection
{
    internal class LogManagent
    {
        private static readonly Lazy<LogManagent> _instanceHolder = new(() => new LogManagent());
        public static LogManagent Instance = _instanceHolder.Value;
        
        /// <summary>
        /// 上传登录信息日志
        /// </summary>
        /// <param name="loginInformation"></param>
        public void UploadLoginInformation(LoginInformationTable loginInformation)
        {
            using(var context = new MyDbContext())
            {
                var user = context.UserInformationTables.FirstOrDefault(e => e.Uid == loginInformation.Uid);
                user.LoginInformationTables.Add(loginInformation);
                context.LoginInformationTables.Add(loginInformation);
                int n = context.SaveChanges();
                if(n <= 0)
                {
                    //上传错误信息
                }
            }
        }

        /// <summary>
        /// 上传操作和错误日志
        /// </summary>
        /// <param name="operationLog"></param>
        public void UploadOperationLog(OperationLogTable operationLog)
        {
            using(var context = new MyDbContext())
            {
                var user = context.UserInformationTables.FirstOrDefault(e => e.Uid == operationLog.Uid);
                user.OperationLogTables.Add(operationLog);
                context.OperationLogTables.Add(operationLog);
                int n = context.SaveChanges();
                if( n <= 0)
                {
                    //上传错误信息
                }
            }
        }
    }
}
