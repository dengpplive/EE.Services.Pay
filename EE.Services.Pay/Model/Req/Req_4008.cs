using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    ///  企业当日交易详情查询[4008]
    /// </summary>
    [Serializable]
    public partial class Req_4008
    {
        /// <summary>
        /// 账号	Char(14)	Y
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 币种	Char(3)	Y	不输入默认为RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 查询页码	Char(6)	N	按页码查询：第一次填0，后续页码递增1
        /// </summary>
        public int PageNo { get; set; }
        /// <summary>
        /// 日志号	Char(7)	N	第一次填0，后续输入为上次输出值
        /// </summary>
        public string JournalNo { get; set; } = "0";
        /// <summary>
        /// 偏移量	Char(3)	N 第一次填0，后续输入为上次输出值
        /// </summary>
        public string LogCount { get; set; } = "0";       
    }
}
