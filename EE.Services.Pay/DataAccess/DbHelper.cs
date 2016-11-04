using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.DataAccess
{
    public class DbHelper
    {
        /// <summary>
        /// 获取Db连接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetDbConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
