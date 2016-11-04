using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 单笔提交转汇总批量[400401]
    /// </summary>
    [Serializable]
    public partial class Req_400401
    {
        /// <summary>
        /// 转账凭证号	C(20)	必输	标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位系列
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	非必输	用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 货币类型	C(3)	必输	RMB-人民币
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
        /// 收款人开户行行号	C(12)	非必输	跨行转账建议必输。
        ///为人行登记在册的商业银行号
        /// </summary>
        public string InAcctBankNode { get; set; }
        /// <summary>
        /// 接收行行号	C(12)	非必输	建议同收款人开户行行号
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
        /// 收款人开户行名称	C(60)	必输	建议格式：xxx银行
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 收款账户银行开户省代码或省名称	C(10)	非必输	建议跨行转账输入；对照码参考“附录-省对照表”；也可输入“附录-省对照表”中的省名称。
        /// </summary>
        public string InAcctProvinceCode { get; set; }
        /// <summary>
        /// 收款账户开户市	C(12)	非必输	建议跨行转账输入； 
        /// </summary>
        public string InAcctCityName { get; set; }
        /// <summary>
        /// 转出金额	C(13,2)	必输	如为XML报文，则直接输入输出以元为单位的浮点数值，如2.50 (两元五角)
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 转出金额大写	C(48)	非必须
        /// </summary>
        public string AmountCode { get; set; }
        /// <summary>
        /// 资金用途	C(30)	非必输	30个汉字。现金管理代理结算时只能输入13个汉字。
        /// </summary>
        public string UseEx { get; set; }
        /// <summary>
        /// 行内跨行标志	C(1)	必输	1：行内转账，0：跨行转账
        /// </summary>
        public int UnionFlag { get; set; } = 1;
        /// <summary>
        /// 转账加急标志	C(1) 
        /// 非必输 N：普通 目前只支持普通
        /// </summary>
        public string SysFlag { get; set; }
        /// <summary>
        /// 同城/异地标志	C(1) 
        /// 必输	“1”—同城   “2”—异地
        /// </summary>
        public int AddrFlag { get; set; } = 1;
        /// <summary>
        /// 备付金转账类型	C(1)	非必输	1、对外付款;2、利息结转;3、手续费结转;4、头寸调拨
        /// 备付金账户必输
        /// </summary>
        public string BFJTranType { get; set; }
        /// <summary>
        /// 备付金业务类型	C(1)	非必输	1-	网络支付；2-	银行卡收单；3-	预付卡发行与受理；4-	其他
        /// 备付金账户必输
        /// </summary>
        public string BFJBizType { get; set; }        
    }
}
