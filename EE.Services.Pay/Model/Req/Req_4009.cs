using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.16 银证转账[4009]
    /// </summary>
    [Serializable]
    public partial class Req_4009
    {
        private string _CcyCode = "RMB";

        /// <summary>
        /// 转账凭证号 标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位系列
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号 用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性 【可选】
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 货币类型 RMB-人民币 
        /// </summary>
        public string CcyCode { get { return _CcyCode; } set { _CcyCode = value; } }
        /// <summary>
        ///  转账类型 0: 银行转证券; 1: 证券转银行
        /// </summary>
        public int OpFlag { get; set; }
        /// <summary>
        /// 银行结算账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 证券资金账号
        /// </summary>
        public string StockNo { get; set; }
        /// <summary>
        /// 证券资金密码加密类型 0或空:明文；1: 使用公钥加密（公钥请联系银行） 默认为空或0； 【可选】
        /// </summary>
        public int PwdEncryType { get; set; }
        /// <summary>
        /// 券资金密码 OpFlag =1 证券转银行 时必输。  【可选】
        /// </summary>
        public string StockAccPwd { get; set; }
        /// <summary>
        /// 转出金额 如为XML报文，则直接输入输出以元为单位的浮点数值，如2.50 (两元五角)
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 资金用途 【可选】
        /// </summary>
        public string UseEx { get; set; }       
    }
}
