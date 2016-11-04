using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 集团内虚拟子账户余额调整[4057] 
    /// </summary>
    [Serializable]
    public partial class Req_4057
    {
        /// <summary>
        /// 转账凭证号 此流水号由企业生成，保证唯一性
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义流水号 【可选】
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 总账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 转出虚拟子帐号 填写14个9，则为主账户；
        /// </summary>
        public string TranOutVirAcc { get; set; }
        /// <summary>
        /// 转出虚拟子账号户名
        /// </summary>
        public string TranOutVirAccName { get; set; }
        /// <summary>
        /// 转入虚拟子帐号 填写14个9，则为主账户；
        /// </summary>
        public string TranInVirAcc { get; set; }
        /// <summary>
        /// 转入虚拟子账号户名
        /// </summary>
        public string TranInVirAccName { get; set; }
        /// <summary>
        /// 金额 13位整数，2位小数
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string UseEx { get; set; }       
    }
}
