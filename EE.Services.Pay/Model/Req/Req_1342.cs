using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1342
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 功能标志 
        /// 1：收费 
        /// 2：退费 
        /// 3：冻结收费
        /// 4：会员支付到市场
        /// 5：市场支付到会员
        /// 6：会员冻结支付到市场
        /// 7：子账户划转
        /// </summary>
        public int FuncFlag { get; set; } = 1;
        /// <summary>
        /// 订单号
        /// </summary>
        public string ThirdHtId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}