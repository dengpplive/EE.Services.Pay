using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4011
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 主机记账日期
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
        /// 日志号	Y	用于下次查询输入
        /// </summary>
        public string JournalNo { get; set; }
        /// <summary>
        /// 偏移量		Y	用于下次查询输入
        /// </summary>
        public string LogCount { get; set; }

        public List<Result_4011> list { get { return _list; } set { _list = value; } }
        private List<Result_4011> _list = new List<Result_4011>();        
    }
    [Serializable]
    public partial class Result_4011
    {
        /// <summary>
        /// 交易时间
        /// </summary>
        public string TranTime1 { get; set; }
        /// <summary>
        /// 主机流水号
        /// </summary>
        public string HostSeqNo { get; set; }
        /// <summary>
        /// 凭证号
        /// </summary>
        public string SummonNo { get; set; }
        /// <summary>
        /// 付款行名称
        /// </summary>
        public string SendBank { get; set; }
        /// <summary>
        /// 付款方账号
        /// </summary>
        public string SendAccount { get; set; }
        /// <summary>
        /// 付款方户名
        /// </summary>
        public string SendName { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string TxAmount { get; set; }
        /// <summary>
        /// 收款方行名
        /// </summary>
        public string AcctBank { get; set; }
        /// <summary>
        /// 收款方账号
        /// </summary>
        public string AcctAccount { get; set; }
        /// <summary>
        /// 收款方户名
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 借贷标志
        /// </summary>
        public string TxType { get; set; }
        /// <summary>
        /// 摘要，未翻译的摘要如:TRS
        /// </summary>
        public string AbstractStr { get; set; }
        /// <summary>
        /// 用途，附言
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public string Fee1 { get; set; }
        /// <summary>
        /// 邮电费
        /// </summary>
        public string Fee2 { get; set; }
        /// <summary>
        /// 中文摘要，AbstractStr的中文翻译 只有在xml报文中有返回，定长报文无返回
        /// </summary>
        public string AbstractStr_Desc { get; set; }
        /// <summary>
        /// 客户上送的转账流水号 目前返回为空
        /// </summary>
        public string CVoucherNo { get; set; }
        /// <summary>
        /// 客户自定义凭证号 目前返回为空
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 代理人户名 非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayName { get; set; }
        /// <summary>
        /// 代理人账号 非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayAcc { get; set; }
        /// <summary>
        /// 代理人银行名称 非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayBankName { get; set; }        
    }

}
