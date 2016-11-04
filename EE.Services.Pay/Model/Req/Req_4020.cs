using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    ///  离岸账户转账[4020]
    /// </summary>
    [Serializable]
    public partial class Req_4020
    {
        private int _TranType = 1;
        private int _feeType = 1;
        /// <summary>
        /// 转账凭证号 标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位系列
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 交易类型  1-离岸网点内转账 2-行内转账 3-境外汇款 4-转汇他行 默认1-离岸网点内转账
        /// </summary>
        public int TranType { get { return _TranType; } set { _TranType = value; } }
        /// <summary>
        /// 汇款人账号
        /// </summary>
        public string PayerAcctNo { get; set; }
        /// <summary>
        /// 币种 支持除人民币外的币种；USD-美元； HKD-港币； EUR-欧元； JPY-日元
        /// </summary>
        public string AcctCurrencyNo { get; set; }
        /// <summary>
        /// 汇款人名称
        /// </summary>
        public string PayerName { get; set; }
        /// <summary>
        /// 汇款币种
        /// </summary>
        public string RemitterCurrency { get; set; }
        /// <summary>
        /// 汇款金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 收款人账号
        /// </summary>
        public string RemitteeAcctNo { get; set; }
        /// <summary>
        /// 收款人名称
        /// </summary>
        public string RemitteeName { get; set; }
        /// <summary>
        /// 收款人地址【可选】 行内转账、境外才需此项
        /// </summary>
        public string RemitteeAddr { get; set; }
        /// <summary>
        /// 汇入行SWIFTNO号 【可选】 境外才需此项
        /// </summary>
        public string SwiftNo { get; set; }
        /// <summary>
        /// 7位的银行代码 【可选】境外才需此项
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 汇入行名称
        /// </summary>

        public string RemitteeBankName { get; set; }
        /// <summary>
        /// 汇入行地址 【可选】 行内转账、境外才需此项	
        /// </summary>
        public string RemitteeBankAddr { get; set; }

        /// <summary>
        /// 汇入行网点号 【可选】 境外不需此项
        /// </summary>
        public string RemitteeBankUnitNo { get; set; }
        /// <summary>
        /// 中间行号 【可选】
        /// </summary>
        public string Intermediary { get; set; }
        /// <summary>
        /// 合同号【可选】 行内转账、境外才需此项
        /// </summary>
        public string ContractNo { get; set; }
        /// <summary>
        /// 发票号 【可选】 行内转账、境外才需此项
        /// </summary>
        public string InvoiceNo { get; set; }
        /// <summary>
        ///  汇款费用选择 1=付款人付费 2=收款人付费 3=所有费用由付款人支付 4=所有费用由收款人支付 5=其他
        /// </summary>
        public int feeType { get { return _feeType; } set { _feeType = value; } }
        /// <summary>
        /// 加急标志 【可选】 1-普通，2-加急 行内转账、境外才需此项
        /// </summary>
        public string UrgentMark { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 联系人【可选】 行内转账、境外才需此项
        /// </summary>
        public string Contactman { get; set; }
        /// <summary>
        /// 电话 【可选】行内转账、境外才需此项
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 电话确认起证金额 【可选】用于大额转账汇款电话证实的金额区间最低值, 单位：美元(USD)
        /// </summary>
        public string AcctBalance { get; set; }        
    }
}
