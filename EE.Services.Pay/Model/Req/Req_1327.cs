using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 查询支付指令状态【1327】
    /// </summary>
    [Serializable]
    public partial class Req_1327
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 支付指令号
        /// </summary>
        public string PaySerialNo { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }       
    }
}
