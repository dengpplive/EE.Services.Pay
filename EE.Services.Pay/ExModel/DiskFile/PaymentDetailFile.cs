using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.ExModel.DiskFile
{
    /// <summary>
    /// 付款明细文件
    /// </summary>
    public class PaymentDetailFile
    {
        public Summary SummaryFiled { get; set; }
        public class Summary
        {
            /// <summary>
            /// 总笔数 
            /// </summary>
            public int TotalNum { get; set; }

            /// <summary>
            /// 总金额
            /// </summary>
            public int TotalAmount { get; set; }
            /// <summary>
            /// 成功笔数
            /// </summary>
            public int SuccessNum { get; set; }
            /// <summary>
            /// 成功金额
            /// </summary>
            public int SuccessAmount { get; set; }
        }
        /// <summary>
        /// 对外付款
        /// </summary>
        public class Detail_4004_4014_4018
        {
            /// <summary>
            /// 直连系统生成的流水号
            /// </summary>
            public string FlowNo { get; set; }
            /// <summary>
            /// 转账凭证号 客户上送的凭证号
            /// </summary>
            public string ThirdVoucher { get; set; }
            /// <summary>
            /// 企业内部流水号 客户上送的
            /// </summary>
            public string CstInnerFlowNo { get; set; }
            /// <summary>
            /// 付款帐号
            /// </summary>
            public string OutAcctNo { get; set; }
            /// <summary>
            /// 收款帐号
            /// </summary>
            public string InAcctNo { get; set; }
            /// <summary>
            /// 收款户名
            /// </summary>
            public string InAcctName { get; set; }
            /// <summary>
            /// 金额
            /// </summary>
            public string TranAmount { get; set; }
            /// <summary>
            /// 提交时间 银行记录的提交时间
            /// </summary>
            public string submitTime { get; set; }
            /// <summary>
            /// 会计日期 银行主机记账的会计日期
            /// </summary>
            public string AccountDate { get; set; }
            /// <summary>
            /// 主机流水号  银行主机记账流水号
            /// </summary>
            public string hostFlowNo { get; set; }
            /// <summary>
            /// 20成功，30失败；99异常；其余为处理中
            /// </summary>
            public string Stt { get; set; }
            /// <summary>
            /// 错误码
            /// </summary>
            public string hostErrorCode { get; set; }
            /// <summary>
            /// 错误信息
            /// </summary>
            public string BackRem { get; set; }
        }
        /// <summary>
        /// 单笔代收
        /// </summary>
        public class Detail_4047
        {
            /// <summary>
            /// 直连系统生成的流水号
            /// </summary>
            public string FlowNo { get; set; }
            /// <summary>
            /// 批次号
            /// </summary>
            public string ThirdVoucher { get; set; }
            /// <summary>
            /// 企业内部流水号
            /// </summary>
            public string CstInnerFlowNo { get; set; }
            /// <summary>
            /// 企业帐号
            /// </summary>
            public string SrcAcctNo { get; set; }
            /// <summary>
            /// 单位代码  对应委托单位协议号字段
            /// </summary>
            public string AGREE_NO { get; set; }
            /// <summary>
            /// 对手帐号
            /// </summary>
            public string OppAccNo { get; set; }
            /// <summary>
            /// 对手户名
            /// </summary>
            public string OppAccName { get; set; }
            /// <summary>
            /// 金额
            /// </summary>
            public decimal Amount { get; set; }
            /// <summary>
            /// 提交时间 银行记录的提交时间
            /// </summary>
            public string submitTime { get; set; }
            /// <summary>
            /// 会计日期 银行主机记账的会计日期
            /// </summary>
            public string AccountDate { get; set; }
            /// <summary>
            /// 主机流水号 银行主机记账流水号
            /// </summary>
            public string hostFlowNo { get; set; }
            /// <summary>
            /// 状态 0成功，30失败；99异常；其余为处理中。
            /// </summary>
            public string Stt { get; set; }
            /// <summary>
            /// 错误码
            /// </summary>
            public string hostErrorCode { get; set; }
            /// <summary>
            /// 错误消息
            /// </summary>
            public string BackRem { get; set; }
        }
    }
}
