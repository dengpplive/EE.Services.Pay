using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4059
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 钞汇标志
        /// </summary>
        public string CcyType { get; set; }
        /// <summary>
        /// 账户户名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 可用余额
        /// </summary>
        public string Balance { get; set; }
        /// <summary>
        /// 账面余额
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 上日余额
        /// </summary>
        public string LastBalance { get; set; }
        /// <summary>
        /// 冻结余额
        /// </summary>
        public string HoldBalance { get; set; }        
    }
}
