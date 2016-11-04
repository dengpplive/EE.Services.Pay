using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4008
    {
        /// <summary>
        /// 账号	Char(14)	Y
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 币种	Char(3)	Y
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public string PageNo { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public string PageSize { get; set; }
        /// <summary>
        /// 主机记账日期	Char(8)	
        /// </summary>
        public string TranDate { get; set; }
        /// <summary>
        /// 数据结束标志	Char(1)	Y	“Y”---表示查询结果已全部输出完毕；
        ///“N”---表示查询结果只输出一部分，后续部分有待请求输出；
        /// </summary>
        public string EndFlag { get; set; }      
        /// <summary>
        /// 记录笔数	Char(2)		本次返回的笔数
        /// </summary>
        public string PageRecCount { get; set; }
        /// <summary>
        /// 日志号	Char(7)	Y	用于下次查询输入
        /// </summary>
        public string JournalNo { get; set; }
        /// <summary>
        /// 偏移量	Char(3)	Y	用于下次查询输入
        /// </summary>
        public string LogCount { get; set; }
        public List<Result_4008> list { get; set; } = new List<Result_4008>();       
    }

    [Serializable]
    public partial class Result_4008
    {
        /// <summary>
        /// 交易时间	Char(6)	N
        /// </summary>
        public string TranTime1 { get; set; }
        /// <summary>
        /// 主机流水号	Char(7)	N
        /// </summary>
        public string HostSeqNo { get; set; }
        /// <summary>
        /// 凭证号	Char(20)	N	银行返回传票号
        /// </summary>
        public string SummonNo { get; set; }
        /// <summary>
        /// 付款行名称	Char(120)	N
        /// </summary>
        public string SendBank { get; set; }
        /// <summary>
        /// 付款方账号	Char(32)	Y
        /// </summary>
        public string SendAccount { get; set; }
        /// <summary>
        /// 付款方户名	Char(120)	N
        /// </summary>
        public string SendName { get; set; }
        /// <summary>
        /// 交易金额	Char (15)	Y
        /// </summary>
        public string TxAmount { get; set; }
        /// <summary>
        /// 收款方行名	Char(120)	N
        /// </summary>
        public string AcctBank { get; set; }
        /// <summary>
        /// 收款方账号	Char(32)	N
        /// </summary>
        public string AcctAccount { get; set; }
        /// <summary>
        /// 收款方户名	Char(120)	N
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 借贷标志	Char(1)	Y
        /// </summary>
        public string TxType { get; set; }
        /// <summary>
        /// 摘要，未翻译的摘要如:TRS	Char(120)	Y
        /// </summary>
        public string AbstractStr { get; set; }
        /// <summary>
        /// 用途，附言	Char (100)	N
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 手续费	Char (15)	N
        /// </summary>
        public string Fee1 { get; set; }
        /// <summary>
        /// 邮电费	Char (15)	N
        /// </summary>
        public string Fee2 { get; set; }
        /// <summary>
        /// 中文摘要，AbstractStr的中文翻译	0	N	只有在xml报文中有返回，定长报文无返回
        /// </summary>
        public string AbstractStr_Desc { get; set; }
        /// <summary>
        /// 客户上送的转账流水号	0	N	目前返回为空
        /// </summary>
        public string CVoucherNo { get; set; }
        /// <summary>
        /// 客户自定义凭证号	0	N	目前返回为空
        /// </summary>
        public string CstInnerFlowNo { get; set; }      
    }
}
