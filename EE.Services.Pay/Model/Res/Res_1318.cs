using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1318
    {
        /// <summary>
        /// 前置流水号
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 转账手续费
        /// </summary>
        public decimal HandFee { get; set; }
        /// <summary>
        /// 支付手续费子账户
        /// </summary>
        public string FeeOutCustId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }       
    }
}
