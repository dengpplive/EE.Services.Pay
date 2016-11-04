using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 企业当日交易明细查询[4002]
    /// </summary>
    [Serializable]
    public partial class Req_4002
    {
        /// <summary>
        /// 账户	C(14)	必输
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 货币类型 默认RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";     
    }
}
