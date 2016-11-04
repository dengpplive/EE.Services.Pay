using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.DiskFile
{
    /// <summary>
    /// 对账文件
    /// </summary>
    [Serializable]
    public partial class CheckBillDiskFile
    {                       
        public partial class SummaryFiled
        {
            /// <summary>
            /// 总笔数 数字	10	★
            /// </summary>
            public int TotalNum { get; set; }
            /// <summary>
            /// 总金额 数字	17	★	以元为单位，保留2位小数
            /// </summary>
            public decimal TotalMoney { get; set; }
            /// <summary>
            ///成功笔数 10	★
            /// </summary>
            public int SuccessNum { get; set; }
            /// <summary>
            ///成功金额 17	★
            /// </summary>
            public decimal SuccessMoney { get; set; }

            /// <summary>
            ///失败笔数 10	★
            /// </summary>
            public int FailNum { get; set; }
            /// <summary>
            ///失败金额 17	★
            /// </summary>
            public decimal FailMoney { get; set; }

        }
        public partial class DetailFiled
        {
            /// <summary>
            /// 交易日期 字符	8	★
            /// </summary>
            public string TradeDate { get; set; }
            /// <summary>
            /// 交易时间 字符	8	★
            /// </summary>
            public string TradeTime { get; set; }
            /// <summary>
            /// 清算日期 字符 8	★
            /// </summary>
            public string SettleDate { get; set; }
            /// <summary>
            /// 订单号  字符	16-20位	★	第三方流水号一般为16-20位，同一个商户第三方流水号重复交易不允许付款
            /// </summary>
            public string OrderId { get; set; }
            /// <summary>
            ///  批次号	字符	20	☆
            /// </summary>
            public string BatchNumber { get; set; }
            /// <summary>
            /// 收款借记卡/账号
            /// </summary>
            public string RecvAcctId { get; set; }
            /// <summary>
            /// 金额 	12位	★	以元为单位，保留2位小数
            /// </summary>
            public decimal Money { get; set; }
            /// <summary>
            /// 实收手续费 12位	★	以元为单位，保留2位小数
            /// </summary>
            public decimal CounterFeeMoney { get; set; }
            /// <summary>
            /// 记账日期 8	★
            /// </summary>
            public string RecordBillDate { get; set; }
            /// <summary>
            /// 记账流水号 字符	32	★
            /// </summary>
            public string RecordBillSerialNumber { get; set; }
            /// <summary>
            /// 错误码 8位	★	0000	 成功 其余为失败
            /// </summary>
            public string ErrorCode { get; set; }
            /// <summary>
            /// 错误消息 64个汉字	☆
            /// </summary>
            public string ErrorMsg { get; set; }
            /// <summary>
            /// 备注	字符	20	☆
            /// </summary>
            public string Note { get; set; }
        }
    }
}
