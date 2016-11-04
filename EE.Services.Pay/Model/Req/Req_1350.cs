using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1350
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 功能标志
        /// </summary>
        public int FuncFlag { get; set; }
        /// <summary>
        /// 会员子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string ThirdHtId { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}
