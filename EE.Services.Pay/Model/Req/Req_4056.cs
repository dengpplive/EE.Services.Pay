using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.4.5 结息查询[4056]
    /// </summary>
    [Serializable]
    public partial class Req_4056
    {
        /// <summary>
        /// 上级账户 当子账户的为虚账户时必须输入
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 账号 输入子账户的账号：子账户为实账户的，输入实账户账号；子账户为虚账户的，输入虚账户账号
        /// </summary>
        public string accountNo { get; set; }
        /// <summary>
        /// 交易日期 不输默认为当前会计日前3个月
        /// </summary>
        public string TxDate { get; set; }
        /// <summary>
        /// 结束日期 与交易日期的间隔不能超过12个月。不输WS-AUTO-CD-A默认为会计日。
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 日志号 翻页查询用
        /// </summary>
        public string HostSeqNo { get; set; }       
    }
}
