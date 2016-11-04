using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 入金（交易网发起）【1316】
    /// </summary>
    [Serializable]
    public partial class Req_1316
    {
        private string _CcyCode = "RMB";
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 会员证件类型
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 会员证件号码
        /// </summary>
        public string IdCode { get; set; }
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
        /// 币种 默认"RMB" 人民币
        /// </summary>
        public string CcyCode { get { return _CcyCode; } set { _CcyCode = value; } }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }     
    }
}
