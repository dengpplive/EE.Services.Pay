using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1028
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 1：支付
        /// </summary>
        public int FuncFlag { get; set; } = 1;
        /// <summary>
        /// 转出子账号 付款方
        /// </summary>
        public string OutCustAcctId { get; set; }
        /// <summary>
        /// 转出会员代码
        /// </summary>
        public string OutThirdCustId { get; set; }
        /// <summary>
        /// 转入子账号  收款方
        /// </summary>
        public string InCustAcctId { get; set; }
        /// <summary>
        /// 转入会员代码
        /// </summary>
        public string InThirdCustId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 币种 默认：RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 支付订单号
        /// </summary>
        public string ThirdHtId { get; set; }
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
