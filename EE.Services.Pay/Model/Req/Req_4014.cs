using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.6 企业批量实时资金划转[4014]
    /// </summary>
    [Serializable]
    public partial class Req_4014
    {
        /// <summary>
        /// 批量转账凭证号	C(20)	必输	标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位序列号
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 总记录数	C(5)	必输	批量转账的笔数，笔数不能大于10笔；
        /// </summary>
        public int totalCts { get; set; }
        /// <summary>
        /// 总金额	C(13,2)	必输	如为XML报文，则直接输入输出以元为单位的浮点数值，如2.50 (两元五角)
        /// </summary>
        public decimal totalAmt { get; set; }
        /// <summary>
        /// 批次摘要	C(30)	非必输
        /// </summary>
        public string BatchSummary { get; set; }
        /// <summary>
        /// 业务标识1	C(1)	非必输	0:普通支付，实时处理。
        ///1：转信托网银落地划款
        ///在业务标识1 = 1的情况下，此批量接口的允许的明细笔数小于等于500笔，业务处理采用异步处理方式。
        /// </summary>
        public int BizFlag1 { get; set; }
        /// <summary>
        /// 多条记录 标签名HOResultSet4014R
        /// </summary>
        public List<HOResultSet4014R> HOResultSet4014R { get; set; } = new List<Req.HOResultSet4014R>();       
    }
    [Serializable]
    public partial class HOResultSet4014R
    {
        /// <summary>
        /// 单笔转账凭证号(批次中的流水号)	C(20)	非必输	建议必输，在4015查询时返回；若输入，必须保证同一批次内唯一；建议为递增序号
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	非必输	用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 货币类型	C(3)	必输
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 付款人账户	C(14)	必输	扣款账户
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 付款人名称	C(60)	必输	付款账户户名
        /// </summary>
        public string OutAcctName { get; set; }
        /// <summary>
        /// 付款人地址	C(60)	非必输	建议填写付款账户的分行、网点名称
        /// </summary>
        public string OutAcctAddr { get; set; }
        /// <summary>
        /// 收款人开户行行号	C(12)	非必输	跨行转账不落地，则必输。为人行登记在册的商业银行号
        /// </summary>
        public string InAcctBankNode { get; set; }
        /// <summary>
        /// 接收行行号	C(12)	非必输	跨行转账不落地，则必输。为人行登记在册的商业银行号
        /// </summary>
        public string InAcctRecCode { get; set; }
        /// <summary>
        /// 收款人账户	C(32)	必输
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款人账户户名	C(60)	必输
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 收款人开户行名称	C(60)	必输	建议格式：xxx银行xx分行xx支行
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 收款账户开户省代码	C(2)	非必输	建议上送，减少跨行转账落单率。对照码参考“附录-省对照表”
        /// </summary>
        public string InAcctProvinceCode { get; set; }
        /// <summary>
        /// 收款账户开户市	C(12)	非必输	建议上送，减少跨行转账落单率。
        /// </summary>
        public string InAcctCityName { get; set; }
        /// <summary>
        /// 转出金额	C(13,2)	必输	如为XML报文，则直接输入输出以元为单位的浮点数值，如2.50 (两元五角)
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 转出金额大写	C(48)	非必输
        /// </summary>
        public string AmountCode { get; set; }
        /// <summary>
        /// 资金用途	C(30)	必输
        /// </summary>
        public string UseEx { get; set; }
        /// <summary>
        /// 行内跨行标志	C(1)	必输	1：行内转账，0：跨行转账
        /// </summary>
        public int UnionFlag { get; set; } = 1;
        /// <summary>
        /// 转账加急标志	C(1) 
        ///非必输	‘1’—大额 ，等同Y  ‘2’—小额”等同N Y：加急 N：普通S：特急默认为N
        /// </summary>
        public string SysFlag { get; set; } = "N";
        /// <summary>
        /// 同城/异地标志	C(1) 
        /// 必输	“1”—同城   “2”—异地 N – 内部转账
        /// </summary>
        public string AddrFlag { get; set; } = "1";
        /// <summary>
        /// 主账户	C(32)	非必输	券商资金结算时，填写“法人清算号”
        /// </summary>
        public string MainAcctNo { get; set; }
        /// <summary>
        /// 预约日期	C(8)	非必输	格式yyyyMMdd
        ///只有在BizFlag1=1有效
        /// </summary>
        public string BookingDate { get; set; }
        /// <summary>
        /// 代理人户名	C(60)	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayName { get; set; }
        /// <summary>
        /// 代理人账号	C(30)	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayAcc { get; set; }
        /// <summary>
        /// 代理人银行名称	C(30)	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayBankName { get; set; }
        /// <summary>
        /// 备付金转账类型	C(1)	非必输	1、对外付款;2、利息结转;3、手续费结转;4、头寸调拨
        /// </summary>
        public string BFJTranType { get; set; }
        /// <summary>
        /// 备付金业务类型	C(1)	非必输	1-	网络支付；2-	银行卡收单；3-	预付卡发行与受理；4-	其他
        /// </summary>
        public string BFJBizType { get; set; }       
    }
}
