using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_401802
    {
        /// <summary>
        /// 批量转账凭证号
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 单笔转账凭证号(批次中的流水号)/序号
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 付款人账户
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
        public string TranAmount { get; set; }
        /// <summary>
        /// 电子回单号
        /// </summary>
        public string CheckNo { get; set; }
        /// <summary>
        /// 回单验证码
        /// </summary>
        public string CheckCode { get; set; }      
    }
}
