using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.19 混合批量转账接口[4027]
    /// </summary>
    [Serializable]
    public partial class Req_4027
    {
        private List<HOResultSet4018R> _HOResultSet4018R = new List<Req.HOResultSet4018R>();
        private int _totalCts = 500;
        private string _CcyCode = "RMB";
        /// <summary>
        /// 批量转账凭证号 标示交易唯一性，同一客户上送的不可重复，建议格式：yyyymmddHHSS+8位系列
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 总记录数 批量转账的笔数，笔数不大于500笔；
        /// </summary>
        public int totalCts { get { return _totalCts; } set { _totalCts = value; } }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal totalAmt { get; set; }
        /// <summary>
        /// 批次摘要 【可选】
        /// </summary>
        public string BatchSummary { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>

        public string CcyCode { get { return _CcyCode; } set { _CcyCode = value; } }
        /// <summary>
        /// 付款人账户 扣款账户
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 付款人名称 付款账户户名
        /// </summary>
        public string OutAcctName { get; set; }
        /// <summary>
        /// 付款人地址【可选】 建议填写付款账户的分行、网点名称
        /// </summary>
        public string OutAcctAddr { get; set; }
        /// <summary>
        /// 多条记录
        /// </summary>
        public List<HOResultSet4018R> HOResultSet4018R { get { return _HOResultSet4018R; } set { _HOResultSet4018R = value; } }       
    }
}
