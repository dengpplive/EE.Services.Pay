using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    public partial class Res_1333
    {
        /// <summary>
        /// 指令结果 0：成功 1：失败 2：异常
        /// </summary>
        public string SerialResult { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 手续费金额
        /// </summary>
        public string HandFee { get; set; }
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
        /// 支付订单号
        /// </summary>
        public string ThirdHtId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}
