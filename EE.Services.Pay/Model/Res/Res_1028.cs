using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1028
    {
        /// <summary>
        /// 前置流水号
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 转入方余额 付款方
        /// </summary>
        public decimal InCustBalance { get; set; }
        /// <summary>
        /// 转出方余额 收款方
        /// </summary>
        public decimal OutCustBalance { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }

    }
}
