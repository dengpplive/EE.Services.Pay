using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 汇总批量付款电子回单查询[401802]
    /// </summary>
    [Serializable]
    public partial class Req_401802
    {
        /// <summary>
        /// 批量转账凭证号/文件名称 401801上送
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 单笔转账凭证号(批次中的流水号)/序号 401801上送
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 付款人账户 扣款账户
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 收款人账户
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款人账户户名
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 转出金额
        /// </summary>
        public decimal TranAmount { get; set; }      
    }
}
