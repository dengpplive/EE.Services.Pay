using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 出入金账户维护【1315】
    /// </summary>
    [Serializable]
    public partial class Req_1315
    {
        /// <summary>
        /// 功能标志1:新增 2：修改
        /// </summary>
        public int FuncFlag { get; set; }
        /// <summary>
        /// 子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 出/入金账号
        /// </summary>
        public string RelatedAcctId { get; set; }
        /// <summary>
        /// 账号性质 3：出金账号&入金账号
        /// </summary>
        public string AcctFlag { get; set; }
        /// <summary>
        /// 转账方式 1：本行
        /// </summary>
        public string TranType { get; set; }
        /// <summary>
        /// 账号名称
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 联行号 本行为分行号
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 开户行名称
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 付款人/收款人地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 原出入金账号 若FuncFlag为1时为空
        /// </summary>
        public string OldRelatedAcctId { get; set; }
        /// <summary>
        /// 保留域 此处为“交易网会员代码”
        /// </summary>
        public string Reserve { get; set; }        
    }
}
