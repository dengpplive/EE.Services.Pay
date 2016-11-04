using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_KHKF03
    {       
        /// <summary>
        /// 订单号	C(20)
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 企业签约帐号	C(32)
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 费项代码	C(10)
        /// </summary>
        public string BusiType { get; set; }
        /// <summary>
        /// 单位代码	C(32) 【可选】
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 币种	C(3)	【可选】	默认RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 金额	Number(14,2)	元为单位，2位小数
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 收款卡号	C(20)
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款户名	C(32)
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 收款方银行名称	C(20) 【可选】
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 收款方联行号	C(12) 【可选】
        /// </summary>
        public string InAcctBankNode { get; set; }
        /// <summary>
        /// 收款方手机号	C(11) 【可选】
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 用途/备注	C(30) 【可选】
        /// </summary>
        public string Remark { get; set; }       
    }
}
