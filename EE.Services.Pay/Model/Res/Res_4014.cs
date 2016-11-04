using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4014
    {
        /// <summary>
        /// 批量转账凭证号	C(20)	必输	同上送的批次号
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 成功笔数	C(5)	非必输	BigFlag=1时非必输
        /// </summary>
        public string successCts { get; set; }
        /// <summary>
        /// 成功金额	C(13,2)	非必输	BigFlag=1时非必输
        /// </summary>
        public string successAmt { get; set; }
        /// <summary>
        /// 失败笔数	C(5)	非必输	BigFlag=1时非必输
        /// </summary>
        public string faildCts { get; set; }
        /// <summary>
        /// 失败金额	C(13,2)	非必输	BigFlag=1时非必输
        /// </summary>
        public string faildAmt { get; set; }
        /// <summary>
        /// 标签名：list    BigFlag=1时非必输
        /// </summary>
        public List<Result_4014> list { get; set; } = new List<Result_4014>();       
    }

    [Serializable]
    public partial class Result_4014
    {
        /// <summary>
        /// 转账结果	C(6)	必输	000000 表示成功，其他为错误码。
        /// </summary>
        public string stt { get; set; }
        /// <summary>
        /// 结果描述	C(40)	必输	Stt的代码描述
        /// </summary>
        public string sttDesc { get; set; }
        /// <summary>
        /// 单笔转账凭证号(批次中的流水号)	C(20)	必输	客户输入则返回，若不输入，返回同FrontLogNo
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	非必输	用于客户转账登记和内部识别，通过转账结果查询可以返回。银行不检查唯一性
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 银行流水号	C(14)	必输	银行生成的转账流水
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 货币类型	C(3)	必输
        /// </summary>
        public string CcyCode { get; set; }
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
        public string TranAmount { get; set; }
        /// <summary>
        /// 交易标志域	C(1)	必输
        /// </summary>
        public string UnionFlag { get; set; }
        /// <summary>
        /// 手续费	C(13)
        /// </summary>
        public string Fee1 { get; set; }
        /// <summary>
        /// 邮电费	C(13)
        /// </summary>
        public string Fee2 { get; set; }
        /// <summary>
        /// 银行返回传票号	C(20)	必输	转账成功后，银行返回传票号，等同交易明细返回的传票号。
        /// </summary>
        public string SOA_VOUCHER { get; set; }
        /// <summary>
        /// 银行返回核心流水号	C(10)		转账成功后，银行返回的核心系统流水号。
        /// </summary>
        public string hostFlowNo { get; set; }        
    }

}
