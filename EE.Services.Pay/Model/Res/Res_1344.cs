using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1344
    {
        /// <summary>
        /// 指令流水号
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 处理状态 0：成功 3：待确认
        /// </summary>
        public int DealStatus { get; set; } = -1;
        /// <summary>
        ///  交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 平安易宝账号
        /// </summary>
        public string RelatedAcctId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        //public string Reserve { get; set; }       
    }
}
