using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 签到、签退【1330】
    /// </summary>
    [Serializable]
    public partial class Req_1330
    {
        /// <summary>
        /// 请求功能 1：签到 2：签退
        /// </summary>
        public int FuncFlag { get; set; } = 1;
        /// <summary>
        /// 交易日期 交易网签到或签退时的交易日期 yyyyMMdd
        /// </summary>
        public string TxDate { get; set; } = System.DateTime.Now.ToString("yyyyMMdd");
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }        
    }
}
