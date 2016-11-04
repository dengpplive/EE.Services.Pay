using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.DiskFile
{
    /// <summary>
    /// 送盘文件
    /// </summary>
    [Serializable]
    public partial class SendDiskFile
    {        
        public partial class SummaryFiled
        {
            /// <summary>
            /// 委托单位签约账号 字符	32	★
            /// </summary>
            public string EntrustUintContractAccount { get; set; }
            /// <summary>
            /// 总笔数 数字	10	★
            /// </summary>
            public int TotalNum { get; set; }
            /// <summary>
            /// 总金额 数字	17	★	以元为单位，保留2位小数
            /// </summary>
            public decimal TotalMoney { get; set; }

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
            /// 收款账号开户行省 10个汉字	☆
            /// </summary>
            public string RecvProvince { get; set; }
            /// <summary>
            /// 收款账号开户行市 字符	10个汉字	☆
            /// </summary>
            public string RecvCity { get; set; }
            /// <summary>
            /// 收款账号开户行名称 20个汉字	☆
            /// </summary>
            public string RecvBankName { get; set; }
            /// <summary>
            /// 金额 	12位	★	以元为单位，保留2位小数
            /// </summary>
            public decimal Money { get; set; }
            /// <summary>
            /// 摘要 20个汉字	★
            /// </summary>
            public string Sumup { get; set; }
            /// <summary>
            /// 收款账号开户行联行号 12位	☆
            /// </summary>
            public string RecvBankCode { get; set; }
            /// <summary>
            /// 手机号 11位	☆
            /// </summary>
            public string Mobile { get; set; }
        }
    }
}
