using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 平台操作支付【1331】
    /// </summary>
    [Serializable]
    public partial class Req_1331
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 功能标志 1：代理复核 2：强制支付
        /// </summary>
        public int FuncFlag { get; set; }
        /// <summary>
        /// 支付指令号 
        /// </summary>
        public string PaySerialNo { get; set; }
        /// <summary>
        /// 支付订单号
        /// </summary>
        public string ThirdHtId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 支付手续费
        /// </summary>
        public decimal PayFee { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }       
    }
}
