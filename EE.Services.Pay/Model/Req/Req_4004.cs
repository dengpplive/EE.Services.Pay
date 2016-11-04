using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 企业单笔资金划转[4004]
    /// </summary>
    [Serializable]
    public partial class Req_4004
    {
        /// <summary>
        /// 转账凭证号 标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位系列
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号 【可选】 用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 货币类型 RMB-人民币
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 付款人账户 扣款账户
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 付款人名称  付款账户户名
        /// </summary>
        public string OutAcctName { get; set; }
        /// <summary>
        /// 付款人地址 【可选】 建议填写付款账户的分行、网点名称
        /// </summary>
        public string OutAcctAddr { get; set; }
        /// <summary>
        /// 收款人开户行行号 【可选】 跨行转账建议必输。 为人行登记在册的商业银行号
        /// </summary>
        public string InAcctBankNode { get; set; }
        /// <summary>
        /// 接收行行号 【可选】 建议同收款人开户行行号
        /// </summary>
        public string InAcctRecCode { get; set; }
        /// <summary>
        /// 收款人账户
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款人账户户名
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 收款人开户行名称 建议格式：xxx银行
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 收款账户银行开户省代码或省名称【可选】 建议跨行转账输入；对照码参考“附录-省对照表”；也可输入“附录-省对照表”中的省名称。
        /// </summary>
        public string InAcctProvinceCode { get; set; }
        /// <summary>
        /// 收款账户开户市 【可选】 建议跨行转账输入
        /// </summary>
        public string InAcctCityName { get; set; }
        /// <summary>
        /// 转出金额 如为XML报文，则直接输入输出以元为单位的浮点数值，如2.50 (两元五角)
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 转出金额大写 【可选】 
        /// </summary>
        public string AmountCode { get; set; }
        /// <summary>
        /// 资金用途【可选】  30个汉字。现金管理代理结算时只能输入13个汉字。
        /// </summary>
        public string UseEx { get; set; }
        /// <summary>
        /// 行内跨行标志 1：行内转账，0：跨行转账
        /// </summary>
        public int UnionFlag { get; set; } = 1;
        /// <summary>
        /// 转账加急标志 【可选】 ‘1’—大额 ，等同Y  ‘2’—小额”等同N   Y：加急 N：普通S：特急 默认为N
        /// </summary>
        public string SysFlag { get; set; } = "N";
        /// <summary>
        /// 同城/异地标志 “1”—同城   “2”—异地
        /// </summary>
        public int AddrFlag { get; set; } = 1;
        /// <summary>
        /// 【可选】
        /// </summary>
        //public string RealFlag { get; set; }
        /// <summary>
        /// 虚子账户 【可选】 现金管理代理结算（不同与代理行支付功能）：填写虚子账号。虚子账户代理主账户付款。
        /// </summary>
        public string MainAcctNo { get; set; }
        /// <summary>
        /// 转账短信通知手机号码 【可选】 格式为：“13412341123,12312341234”，多个手机号码使用半角逗号分隔.如果为空或者手机号码长度不足11位，就不发送。
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 中登结算类型【可选】 转入中登备付金必输：1：上海登记公司－资金清算业务 2：上海登记公司－网下发行电子化业务 3：深圳登记公司－网上业务 4：深圳登记公司－网下IPO业务
        /// </summary>
        public string zdJType { get; set; }
        /// <summary>
        /// 资金类型【可选】
        /// </summary>
        public string zdZType { get; set; }
        /// <summary>
        /// 备付金账号【可选】 用于中登结算类型
        /// </summary>
        public string zdBAcc { get; set; }
        /// <summary>
        /// 代理人户名 【可选】 用于代理行支付功能，若为代理行付款，此信息必输
        /// </summary>
        public string ProxyPayName { get; set; }
        /// <summary>
        /// 代理人账号 【可选】用于代理行支付功能，若为代理行付款，此信息必输
        /// </summary>
        public string ProxyPayAcc { get; set; }
        /// <summary>
        /// 代理人银行名称 【可选】 用于代理行支付功能，若为代理行付款，此信息必输
        /// </summary>
        public string ProxyPayBankName { get; set; }
        /// <summary>
        /// 收款人证件类型 【可选】 参考附录-证件号码对照表  上送则验证证件号码是否一致， 只对行内个人借记卡收款账户有效（不支持信用卡）
        /// </summary>
        public string InIDType { get; set; }
        /// <summary>
        /// 收款人证件号码 【可选】
        /// </summary>
        public string InIDNo { get; set; }
        /// <summary>
        /// 备付金转账类型 【可选】 1、对外付款;2、利息结转;3、手续费结转;4、头寸调拨
        /// </summary>
        public string BFJTranType { get; set; }
        /// <summary>
        /// 备付金业务类型 【可选】 1-网络支付；2-银行卡收单；3-预付卡发行与受理；4-其他
        /// </summary>
        public string BFJBizType { get; set; }
    }
}
