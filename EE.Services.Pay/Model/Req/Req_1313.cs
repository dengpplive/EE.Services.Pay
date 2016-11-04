using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1313
    {
        /// <summary>
        /// 交易网名称 必输  C(120)
        /// </summary>
        public string TranWebName { get; set; }
        /// <summary>
        /// 交易网会员代码 C(32) 必输
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 出金类型 1：会员出金 C（2）  必输
        /// </summary>
        public int TranOutType { get; set; } = 1;
        /// <summary>
        /// 子账户账号 C(32)   必输
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 子账户名称 C(120) 必输
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 上级监管账号 C(32) 必输
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 转账方式 C(1) 3：行外转账 必输
        /// </summary>
        public int TranType { get; set; } = 3;
        /// <summary>
        /// 出金账号 必输  C(32) 即收款账户，必须是在系统中维护的出金账号 
        /// </summary>
        public string OutAcctId { get; set; }
        /// <summary>
        /// 出金账户名称 C(120) 必输 与子账户名称一致
        /// </summary>
        public string OutAcctIdName { get; set; }
        /// <summary>
        /// 出金账号开户行名 C(120) 必输
        /// </summary>
        public string OutAcctIdBankName { get; set; }
        /// <summary>
        /// 出金账号开户联行号 C(12)  可选
        /// </summary>
        public string OutAcctIdBankCode { get; set; }
        /// <summary>
        /// 出金账号开户行地址 C(120)可选 
        /// </summary>
        public string Address { get; set; }
        /// <summary> 
        /// 币种 C(3)  可选  默认为RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 申请出金金额 9(15) 必输 不包括转账手续费
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 支付转账手续费的子账号  C(32) 可选 保留字段,暂时不用
        /// </summary>
        public string FeeOutCustId { get; set; }
        /// <summary>
        ///  保留域 C(120) 可选
        /// </summary>
        public string Reserve { get; set; }       
    }
}
