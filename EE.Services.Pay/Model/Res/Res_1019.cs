using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1019
    {
        /// <summary>
        /// 子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 账户总余额 以分为单位，例如100.01元，则填：10001（此处特殊，其它接口的金额都以元为单位）
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 账户可用余额 以分为单位，例如100.01元，则填：10001（此处特殊，其它接口的金额都以元为单位）
        /// </summary>
        public decimal TotalBalance { get; set; }
        /// <summary>
        /// 账户总冻结金额 以分为单位，例如100.01元，则填：10001（此处特殊，其它接口的金额都以元为单位）
        /// </summary>
        public decimal TotalFreezeAmount { get; set; }
        /// <summary>
        /// 维护日期 开户日期或修改日期
        /// </summary>
        public string TranDate { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }       
    }
}
