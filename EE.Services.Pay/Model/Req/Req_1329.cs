using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 子账户直接支付【1329】
    /// </summary>
    [Serializable]
    public partial class Req_1329
    {      
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 功能标志 1：可用支付 2：冻结支付
        /// </summary>
        public int FuncFlag { get; set; }
        /// <summary>
        /// 转出子账户
        /// </summary>
        public string OutCustAcctId { get; set; }
        /// <summary>
        /// 转出会员代码
        /// </summary>
        public string OutThirdCustId { get; set; }
        /// <summary>
        /// 转入子账户
        /// </summary>
        public string InCustAcctId { get; set; }
        /// <summary>
        /// 转入会员代码
        /// </summary>
        public string InThirdCustId { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 手续费金额
        /// </summary>
        public decimal HandFee { get; set; }
        /// <summary>
        /// 币种 默认：RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 支付指令号 根据该字段判断是否指令重复
        /// </summary>
        public string PaySerialNo { get; set; }
        /// <summary>
        /// 支付订单号
        /// </summary>
        public string ThirdHtId { get; set; }
        /// <summary>
        /// 支付订单内容
        /// </summary>
        public string ThirdHtCont { get; set; }
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
