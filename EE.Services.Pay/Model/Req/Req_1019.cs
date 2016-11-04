using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 查交易网端会员管理账户余额【1019】
    /// </summary>
    [Serializable]
    public partial class Req_1019
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }      
    }
}
