using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    ///企业大批量资金划转[4018]
    /// </summary>
    [Serializable]
    public partial class Req_4018
    {
        /// <summary>
        /// 批量转账凭证号 标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位系列
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        ///  总记录数 批量转账的笔数，笔数不大于500笔；
        /// </summary>
        public int totalCts { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal totalAmt { get; set; }
        /// <summary>
        /// 批次摘要
        /// </summary>
        public string BatchSummary { get; set; }
        /// <summary>
        /// 整批转账加急标志 
        /// Y:加急 
        /// N:不加急
        /// S:特急（汇总扣款模式不支持）
        /// </summary>
        public string BSysFlag { get; set; } = "N";
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 付款人账户 扣款账户
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 付款人名称 付款账户户名
        /// </summary>
        public string OutAcctName { get; set; }
        /// <summary>
        /// 付款人地址 【可选】 建议填写付款账户的分行、网点名称
        /// </summary>
        public string OutAcctAddr { get; set; }
        /// <summary>
        /// 扣款类型 【可选】默认为0 
        /// 0：单笔扣划
        /// 1：汇总扣划
        ///BizFlag1 = 1时只支持0单笔扣划
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 业务标识1 【可选】 1：转信托网银落地划款 0或其他为普通直连交易
        /// </summary>
        public int BizFlag1 { get; set; }
        /// <summary>
        /// 预约日期 格式yyyyMMdd
        ///只在BizFlag1=1且大于当前日期才有效 【可选】
        /// </summary>
        public string BookingDate { get; set; }
        /// <summary>
        /// 多条记录
        /// </summary>
        public List<HOResultSet4018R> HOResultSet4018R { get; set; } = new List<Req.HOResultSet4018R>();
    }
    [Serializable]
    public partial class HOResultSet4018R
    {
        /// <summary>
        /// 单笔转账凭证号(批次中的流水号)/序号 同一个批次内不能重复，建议按顺序递增生成，若上送返回则按此字段递增排序。；建议为递增序号，如从1开始
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号【可选】 用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 收款人开户行行号 【可选】 跨行转账不落地，则必输。为人行登记在册的商业银行号
        /// </summary>
        public string InAcctBankNode { get; set; }
        /// <summary>
        /// 接收行行号【可选】 跨行转账不落地，则必输。为人行登记在册的商业银行号
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
        /// 收款人开户行名称 建议格式：xxx银行xx分行xx支行
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 收款账户开户省代码 【可选】 建议上送，减少跨行转账落单率。对照码参考“附录-省对照表”
        /// </summary>
        public string InAcctProvinceCode { get; set; }
        /// <summary>
        /// 收款账户开户市【可选】 建议上送，减少跨行转账落单率。
        /// </summary>
        public string InAcctCityName { get; set; }
        /// <summary>
        /// 转出金额 如为XML报文，则直接输入输出以元为单位的浮点数值，如2.50 (两元五角)
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 资金用途
        /// </summary>
        public string UseEx { get; set; }
        /// <summary>
        /// 行内跨行标志 1：行内转账， 0：跨行转账
        /// </summary>
        public int UnionFlag { get; set; } = 1;
        /// <summary>
        /// 同城/异地标志 1-同城 2-异地
        /// </summary>
        public int AddrFlag { get; set; } = 1;
        /// <summary>
        /// 加急标志 N为普通（默认）, Y为加急 S为特急
        /// </summary>
        public string SysFlag { get; set; } = "N";
        /// <summary>
        /// 【可选】
        /// </summary>
        //public string RealFlag { get; set; }
        /// <summary>
        /// 主账户 【可选】 券商资金结算时，填写“法人清算号”
        /// </summary>
        public string MainAcctNo { get; set; }


    }
}
