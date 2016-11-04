using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4009
    {
        /// <summary>
        /// 转账凭证号
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
        /// 货币类型
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 转账类型
        /// </summary>
        public string OpFlag { get; set; }
        /// <summary>
        /// 银行结算账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 证券资金账号
        /// </summary>
        public string StockNo { get; set; }
        /// <summary>
        /// 转出金额
        /// </summary>
        public string TranAmount { get; set; }       
    }
}
