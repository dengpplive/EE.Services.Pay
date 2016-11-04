using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 入金（银行发起） [1310]
    /// </summary>
    [Serializable]
    public partial class Req_1310
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 入金金额
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 入金账号
        /// </summary>
        public string InAcctId { get; set; }
        /// <summary>
        /// 入金账户名称
        /// </summary>
        public string InAcctIdName { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 会计日期 即银行主机记账日期
        /// </summary>
        public string AcctDate { get; set; }
        /// <summary>
        /// 保留域 返回“交易网会员代码
        /// </summary>
        public string Reserve { get; set; }        
    }
}
