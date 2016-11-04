using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4004
    {
        /// <summary>
        /// 转账凭证号
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 银行生成的转账流水号
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        ///客户自定义凭证号 用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 付款人账户名称
        /// </summary>
        public string OutAcctName { get; set; }
        /// <summary>
        /// 付款人账户
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 收款人账户
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款人账户户名
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 行内跨行标志	C(1)	必输	1：行内转账，0：跨行转账
        /// </summary>
        public string UnionFlag { get; set; }
        /// <summary>
        /// 手续费	C(13)	必输	转账手续费预算，实际手续费用以实际扣取的为准。
        /// </summary>
        public string Fee1 { get; set; }
        /// <summary>
        /// 邮电费	C(13)	非必输
        /// </summary>
        public string Fee2 { get; set; }
        /// <summary>
        /// 银行返回传票号	C(20)	 	转账成功后，银行返回传票号，等同交易明细返回的传票号。
        /// </summary>
        public string SOA_VOUCHER { get; set; }
        /// <summary>
        /// 银行返回流水号	C(10)		转账成功后，银行返回的流水号。
        /// </summary>
        public string hostFlowNo { get; set; }
        /// <summary>
        /// 转账短信通知手机号码	C(0) 格式为：“13412341123,12312341234”，多个手机号码之间使用半角逗号分隔.
        /// </summary>
        public string Mobile { get; set; }       
    }
}
