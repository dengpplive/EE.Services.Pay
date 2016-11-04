using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1327
    {
        /// <summary>
        /// 指令状态  1：待复核 2：已复核 3：已撤销4：处理中
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 转出子账户 即付款方
        /// </summary>
        public string OutCustAcctId { get; set; }

        /// <summary>
        /// 转出会员代码 
        /// </summary>
        public string OutThirdCustId { get; set; }
        /// <summary>
        /// 转入子账户 即收款方
        /// </summary>
        public string InCustAcctId { get; set; }
        /// <summary>
        /// 转入会员代码
        /// </summary>
        public string InThirdCustId { get; set; }
        /// <summary>
        /// 支付订单号
        /// </summary>
        public string ThirdHtId { get; set; }
        /// <summary>
        /// 指令变动日期 若已复核或撤销，则返回指令变动的日期，若未变动则返回为空。
        /// </summary>
        public string ChangeDate { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }      
    }
}
