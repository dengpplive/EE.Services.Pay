using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1350
    {
        /// <summary>
        /// 前置流水号
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 最新可用金额
        /// </summary>
        public string TotalBalance { get; set; }
        /// <summary>
        /// 最新冻结金额
        /// </summary>
        public string TotalFreezeAmount { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}
