using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 出金（银行发起）【1312】
    /// </summary>
    [Serializable]
    public partial class Req_1312
    {
        /// <summary>
        /// 交易网名称
        /// </summary>
        public string TranWebName { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 子账户名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 出金账号 即收款账户，必须是在系统中维护的出金账号
        /// </summary>
        public string OutAcctId { get; set; }
        /// <summary>
        /// 出金账户名称
        /// </summary>
        public string OutAcctIdName { get; set; }
        /// <summary>
        /// 币种 默认为RMB
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 申请出金金额
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 转账手续费
        /// </summary>
        public decimal HandFee { get; set; }
        /// <summary>
        /// 支付手续费子账号
        /// </summary>
        public string FeeOutCustId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }        
    }
}
