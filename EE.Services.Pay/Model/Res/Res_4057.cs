using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4057
    {
        /// <summary>
        /// 转账凭证号	Char(20)	Y	此流水号由企业生成，保证唯一性
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 银行流水号	C(14)	Y	银行生成的转账流水
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 客户自定义流水号
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 总账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 总帐号户名
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 转出虚拟子帐号
        /// </summary>
        public string TranOutVirAcc { get; set; }
        /// <summary>
        /// 转出虚拟子账号户名
        /// </summary>
        public string TranOutVirAccName { get; set; }
        /// <summary>
        /// 转入虚拟子帐号
        /// </summary>
        public string TranInVirAcc { get; set; }
        /// <summary>
        /// 转入虚拟子账号户名
        /// </summary>
        public string TranInVirAccName { get; set; }
        /// <summary>
        /// 银行主机流水号	Char(10)		转账成功后，银行主机返回的流水号
        /// </summary>
        public string HostFlowNo { get; set; }
        /// <summary>
        /// 金额	C(13,2)	Y	13位整数，2位小数
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string UseEx { get; set; }       
    }
}
