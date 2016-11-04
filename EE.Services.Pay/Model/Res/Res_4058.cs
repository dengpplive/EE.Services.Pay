using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4058
    {
        /// <summary>
        /// 总账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 子账号
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// I-增加；U-修改；D-删除 功能码
        /// </summary>
        public string opType { get; set; }
        /// <summary>
        /// 子账户户名
        /// </summary>
        public string subAccountName { get; set; }
        /// <summary>
        /// 是否计息
        /// </summary>
        public string feeFlag { get; set; }
        /// <summary>
        /// 结息周期 D-按日 M-按月 Q-按季 Y-按年
        /// </summary>
        public string feeType { get; set; }
        /// <summary>
        /// 上存利率
        /// </summary>
        public string upFee { get; set; }
        /// <summary>
        /// 下拨利率
        /// </summary>
        public string dwFee { get; set; }
        /// <summary>
        /// Y-是N-否 是否授权上级帐户修改合约
        /// </summary>
        public string mFlag { get; set; }        
    }
}
