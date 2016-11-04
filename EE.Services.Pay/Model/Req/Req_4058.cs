using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 现金管理虚帐户合约建立/修改/删除(4058)
    /// </summary>
    [Serializable]
    public partial class Req_4058
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
        ///功能码   I-增加；U-修改； D-删除 
        /// /// </summary>
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
        /// 结息周期   D-按日 M-按月 Q-按季 Y-按年
        /// </summary>
        public string feeType { get; set; }
        /// <summary>
        /// 上存利率
        /// </summary>
        public decimal upFee { get; set; }
        /// <summary>
        /// 下拨利率
        /// </summary>
        public decimal dwFee { get; set; }
        /// <summary>
        /// Y-是   N-否 是否授权上级帐户修改合约
        /// </summary>
        public string mFlag { get; set; }       
    }
}
