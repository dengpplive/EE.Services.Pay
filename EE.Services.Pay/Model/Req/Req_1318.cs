using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 出金（交易网发起）【1318】
    /// </summary>
    [Serializable]
    public partial class Req_1318
    {
        private int _TranOutType = 1;
        private int _TranType = 1;

        /// <summary>
        /// 交易网名称
        /// </summary>
        public string TranWebName { get; set; }
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
        /// 出金类型 1：会员出金
        /// </summary>
        public int TranOutType { get { return _TranOutType; } set { _TranOutType = value; } }
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 转账方式 1：行内转账
        /// </summary>
        public int TranType { get { return _TranType; } set { _TranType = value; } }
        /// <summary>
        /// 出金账号 即收款账户
        /// </summary>
        public string OutAcctId { get; set; }
        /// <summary>
        /// 出金账户名称 与会员名称一致
        /// </summary>
        public string OutAcctIdName { get; set; }
        /// <summary>
        /// 出金账号开户行名 填“平安银行”
        /// </summary>
        public string OutAcctIdBankName { get; set; }
        /// <summary>
        /// 出金账号开户联行号
        /// </summary>
        public string OutAcctIdBankCode { get; set; }
        /// <summary>
        /// 出金账号开户行地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///币种 默认为RMB
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 申请出金金额 不包括转账手续费
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 支付转账手续费的子账户 预留字段，无实际作用
        /// </summary>
        public string FeeOutCustId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }      
    }
}
