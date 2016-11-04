using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 子账户冻结解冻【1029】
    /// </summary>
    [Serializable]
    public partial class Req_1029
    {
        private string _CcyCode = "RMB";
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        ///  功能标志 1：冻结 2：解冻
        /// </summary>
        public int FuncFlag { get; set; }

        /// <summary>
        /// 子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal TranAmount { get; set; }

        /// <summary>
        /// 币种  默认：RMB
        /// </summary>
        public string CcyCode { get { return _CcyCode; } set { _CcyCode = value; } }
        /// <summary>
        /// 订单号
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
