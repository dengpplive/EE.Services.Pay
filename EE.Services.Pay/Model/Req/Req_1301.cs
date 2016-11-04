using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 会员开销户确认【1301】
    /// </summary>
    [Serializable]
    public partial class Req_1301
    {
        private string _CustFlag = "1";
        /// <summary>
        /// 功能标志1:开户 3：销户
        /// </summary>
        public int FuncFlag { get; set; }
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 子账户证件类型
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 子账户证件号码
        /// </summary>
        public string IdCode { get; set; }
        /// <summary>
        /// 子账户性质 1：虚拟户
        /// </summary>
        public string CustFlag { get { return _CustFlag; } set { _CustFlag = value; } }
        /// <summary>
        /// 初始总金额 子账户开户时的初始总金额，默认为0
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 初始可用余额 子账户开户时的初始总金额，默认为0
        /// </summary>
        public decimal TotalBalance { get; set; }
        /// <summary>
        /// 初始冻结金额 子账户开户时的初始总金额，默认为0
        /// </summary>
        public decimal TotalFreezeAmount { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }        
    }
}
