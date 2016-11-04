using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1333
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
        /// 交易日期
        /// </summary>
        public string TranDate { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}
