using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Model
{
    [Serializable]
    public class ReqView_1020
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 子账户
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>

        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>

        public string CustName { get; set; }
        /// <summary>
        /// 出入金账号
        /// </summary>

        public string AcctNo { get; set; }
    }
}