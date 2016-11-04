using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.16 代理行支付当日交易查询[4011]
    /// </summary>
    [Serializable]
    public partial class Req_4011
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 查询页码	Char(6)	N	按页码查询：第一次填0，后续页码递增1
        /// </summary>
        public string PageNo { get; set; } = "0";
        /// <summary>
        /// 日志号	Char(7)	N	第一次填0，后续输入为上次输出值
        /// </summary>
        public string JournalNo { get; set; } = "0";
        /// <summary>
        /// 偏移量	Char(3) 第一次填0，后续输入为上次输出值
        /// </summary>
        public string LogCount { get; set; } = "0";
        /// <summary>
        /// 币种	Char(3)	Y	不输入默认为RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";        
    }
}
