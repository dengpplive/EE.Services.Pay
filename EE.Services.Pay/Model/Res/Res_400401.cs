using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_400401
    {
        /// <summary>
        /// 转账凭证号	C(20)	必输	同上送
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 银行流水号	C(14)	必输	银行生成的转账流水
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	非必输	用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 货币类型	C(3)	必输
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 付款人账户名称	C(60)	必输
        /// </summary>
        public string OutAcctName { get; set; }
        /// <summary>
        /// 付款人账户	C(14)	必输
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 收款人开户行名称	C(60)	必输
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 收款人账户	C(32)	必输
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款人账户户名	C(60)	必输
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 交易金额	C(13)	必输
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 行内跨行标志	C(1)	必输	1：行内转账，0：跨行转账
        /// </summary>
        public int UnionFlag { get; set; } = 1;       
    }
}
