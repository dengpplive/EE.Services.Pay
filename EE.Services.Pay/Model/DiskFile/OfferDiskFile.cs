using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.DiskFile
{
    /// <summary>
    /// 回盘文件
    /// </summary>
    [Serializable]
    public partial class OfferDiskFile
    {       
        public partial class SummaryFiled
        {
            /// <summary>
            /// 总笔数 	10	★
            /// </summary>
            public int TotalNum { get; set; }
            /// <summary>
            /// 总金额 17	★	以元为单位，保留2位小数
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

            /// <summary>
            ///异常笔数 10	★
            /// </summary>
            public int ExceptionNum { get; set; }
            /// <summary>
            ///异常金额 17	★
            /// </summary>
            public decimal ExceptionMoney { get; set; }

        }
        public partial class DetailFiled
        {
            /// <summary>
            /// 第三方流水号 16-20位	★	第三方流水号一般为16-20位，同一个商户第三方流水号重复交易不允许付款
            /// </summary>
            public string ThirdSerialNumber { get; set; }
            /// <summary>
            /// 收款借记卡/账号 20位	★
            /// </summary>
            public string RecvAcctId { get; set; }
            /// <summary>
            /// 收款人户名 32位	★
            /// </summary>
            public string RecvAcctName { get; set; }

            /// <summary>
            /// 金额 12位	★	以元为单位，保留2位小数
            /// </summary>
            public decimal Money { get; set; }
            /// <summary>
            /// 实收手续费 50个汉字	★
            /// </summary>
            public decimal CounterFeeMoney { get; set; }
            /// <summary>
            /// 返回码 8位	★	0000	 成功9001	 不明确 其余为失败
            /// </summary>
            public string RetCode { get; set; }
            /// <summary>
            /// 返回消息 64个汉字	☆
            /// </summary>
            public string RetMessage { get; set; }

        }
    }
}
