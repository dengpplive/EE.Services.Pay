using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 监管账户信息查询【1021】
    /// </summary>
    [Serializable]
    public partial class Req_1021
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string AcctId { get; set; }
        /// <summary>
        /// 交易网代码
        /// </summary>
        public string TranWebCode { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }       
    }
}
