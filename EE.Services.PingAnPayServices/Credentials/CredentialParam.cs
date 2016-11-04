using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Credentials
{
    /// <summary>
    /// 认证输入参数
    /// </summary>
    public class CredentialParam
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 时间擢
        /// </summary>
        public string TimeTick = System.DateTime.Now.Ticks.ToString();

    }
}