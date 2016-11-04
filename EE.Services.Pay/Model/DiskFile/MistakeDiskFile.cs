using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.DiskFile
{
    /// <summary>
    /// 差错文件
    /// </summary>
    [Serializable]
    public partial class MistakeDiskFile
    {        
        public partial class SummaryFiled
        {
            /// <summary>
            /// 差错退回日期 字符	8	★	YYYYMMDD
            /// </summary>
            public string MistakeReturnDate { get; set; }
            /// <summary>
            /// 总笔数 	数字	17	★
            /// </summary>
            public int TotalNum { get; set; }
            /// <summary>
            /// 总金额 数字	10	★	以元为单位，保留2位小数
            /// </summary>
            public decimal TotalMoney { get; set; }
            /// <summary>
            /// 备注	数字	17	☆
            /// </summary>
            public string Note { get; set; }

        }
        public partial class DetailFiled
        {
            /// <summary>
            /// 差错退回日期 字符	8	★	YYYYMMDD
            /// </summary>
            public string MistakeReturnDate { get; set; }
            /// <summary>
            /// 原交易清算日期 字符	8	★	YYYYMMDD
            /// </summary>
            public string OldTradeSettleDate { get; set; }
            /// <summary>
            /// 收款人帐号 数字	20	☆
            /// </summary>
            public string PayeeAccount { get; set; }
            /// <summary>
            /// 收款人名称
            /// </summary>
            public string PayeeAccountName { get; set; }
            /// <summary>
            /// 银行交易流水 字符	32	☆
            /// </summary>
            public string BankTradeSerialNumber { get; set; }

            /// <summary>
            /// 金额 数字	15,2	★	以元为单位，保留2位小数
            /// </summary>
            public decimal Money { get; set; }

            /// <summary>
            /// 请求方交易日期 字符	8	★	YYYYMMDD
            /// </summary>
            public string ReqTradeDate { get; set; }
            /// <summary>
            /// 请求方交易流水号 字符	20	★	商户订单号
            /// </summary>
            public string ReqTradeSerialNumber { get; set; }
            /// <summary>
            /// 原送盘批次号 字符	20	☆	BatchNo
            /// </summary>
            public string OldSendDiskBatchNumber { get; set; }
            /// <summary>
            /// 差错状态 字符		★
            /// </summary>
            public string MistakeStatus { get; set; }
            /// <summary>
            /// 原代付交易附言 字符	20汉字	☆
            /// </summary>
            public string OldPayedTradeNote { get; set; }
            /// <summary>
            /// 备注 字符		☆	差错退回原因
            /// </summary>
            public string Note { get; set; }
        }
    }
}
