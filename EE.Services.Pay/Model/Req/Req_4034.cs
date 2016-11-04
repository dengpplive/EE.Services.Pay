using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.8 企业汇总资金划转[4034]
    /// </summary>
    [Serializable]
    public partial class Req_4034
    {
        /// <summary>
        /// 批量转账凭证号	C(20)	必输	标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位系列
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 总记录数	C(5)	必输	最大500笔
        /// </summary>
        public int totalCts { get; set; } = 500;
        /// <summary>
        /// 总金额	C(13,2)	必输	如为XML报文，则直接输入输出以元为单位的浮点数值，如2.50 (两元五角)
        /// </summary>
        public decimal totalAmt { get; set; }
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
        /// 转账加急标志	C(1) 
        ///必输 Y：加急
        ///N：不加急-普通
        /// </summary>
        public string BSysFlag { get; set; } = "N";
        /// <summary>
        /// 批次摘要	C(30)	非必输
        /// </summary>
        public string BatchSummary { get; set; }
        public List<HOResultSet4018R> HOResultSet4018R { get; set; } = new List<Req.HOResultSet4018R>();       
    }
}
