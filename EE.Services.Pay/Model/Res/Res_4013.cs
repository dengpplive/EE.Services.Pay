using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4013
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 数据结束标志		“Y”---表示查询结果已全部输出完毕；
        ///“N”---表示查询结果只输出一部分，后续部分有待请求输出；
        /// </summary>
        public string EndFlag { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string Reserve { get; set; }
        /// <summary>
        /// 查询页码
        /// </summary>
        public string PageNo { get; set; }
        /// <summary>
        /// 记录笔数	Char(2)		本次返回的笔数
        /// </summary>
        public string PageRecCount { get; set; }
        /// <summary>
        /// 结果列表
        /// </summary>
        public List<Result_4013> list { get; set; } = new List<Result_4013>();
    }

    [Serializable]
    public partial class Result_4013
    {
        /// <summary>
        /// 主机记账日期
        /// </summary>
        public string AcctDate { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public string TxTime { get; set; }
        /// <summary>
        /// 主机流水号
        /// </summary>
        public string HostTrace { get; set; }
        /// <summary>
        /// 付款方网点号
        /// </summary>
        public string OutNode { get; set; }
        /// <summary>
        /// 付款方联行号
        /// </summary>
        public string OutBankNo { get; set; }
        /// <summary>
        /// 付款行名称
        /// </summary>
        public string OutBankName { get; set; }
        /// <summary>
        /// 付款方账号
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 付款方户名
        /// </summary>
        public string OutAcctName { get; set; }
        /// <summary>
        /// 结算币种
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 收款方网点号
        /// </summary>
        public string InNode { get; set; }
        /// <summary>
        /// 收款方联行号
        /// </summary>
        public string InBankNo { get; set; }
        /// <summary>
        /// 收款方行名
        /// </summary>
        public string InBankName { get; set; }
        /// <summary>
        /// 收款方账号
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款方户名
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 借贷标志
        /// </summary>
        public string DcFlag { get; set; }
        /// <summary>
        /// 摘要，未翻译的摘要，如TRS
        /// </summary>
        public string AbstractStr { get; set; }
        /// <summary>
        /// 凭证号		银行返回传票号
        /// </summary>
        public string VoucherNo { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public string TranFee { get; set; }
        /// <summary>
        /// 邮电费
        /// </summary>
        public string PostFee { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        public string AcctBalance { get; set; }
        /// <summary>
        /// 用途，附言	0		只有在xml报文中有返回，定长报文无返回；客户端上送的用途。
        /// </summary>
        public string Purpose { get; set; }
        /// <summary>
        /// 客户自定义凭证号 目前返回为空
        /// </summary>
        public string CVoucherNo { get; set; }
        /// <summary>
        /// 中文摘要，AbstractStr的中文翻译	0		只有在xml报文中有返回，定长报文无返回
        /// </summary>
        public string AbstractStr_Desc { get; set; }
        /// <summary>
        /// 代理人户名	0	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayName { get; set; }
        /// <summary>
        /// 代理人账号	0	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayAcc { get; set; }
        /// <summary>
        /// 代理人银行名称	0	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayBankName { get; set; }
    }

}
