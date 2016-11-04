using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1313
    {
        /// <summary>
        /// 前置流水号 C(14) 必输
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 转账手续费 9(15) 必输
        /// </summary>
        public string HandFee { get; set; }
        /// <summary>
        ///  支付手续费子账号 9(15) 必输
        /// </summary>
        public string FeeOutCustId { get; set; }
        /// <summary>
        /// 保留域 可选
        /// </summary>
        public string Reserve { get; set; }      
    }
}
