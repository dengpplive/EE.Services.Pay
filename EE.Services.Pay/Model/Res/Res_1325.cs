using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1325
    {      
        /// <summary>
        /// 总记录数
        /// </summary>
        public string TotalCount { get; set; }
        /// <summary>
        /// 起始记录号
        /// </summary>
        public string BeginNum { get; set; }
        /// <summary>
        /// 是否结束包 0：否  1：是
        /// </summary>
        public string LastPage { get; set; }
        /// <summary>
        /// 本次返回流水笔数 重复次数（一次最多返回20条记录）
        /// </summary>
        public string RecordNum { get; set; }
        /// <summary>
        /// 信息数组
        /// </summary>
        public List<AccessToGoldTradeInfo> AccessToGoldTradeInfoList { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }       
    }
    /// <summary>
    /// 会员出入金流水信息【1325】
    /// </summary>
    [Serializable]
    public partial class AccessToGoldTradeInfo
    {
        /// <summary>
        /// 交易网流水号
        /// </summary>
        public string ThirdLogNo { get; set; }
        /// <summary>
        /// 银行前置流水号
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 记账标志 1：入金 2：出金
        /// </summary>
        public string TranFlag { get; set; }

        /// <summary>
        /// 交易状态 0：成功
        ///1：失败（交易网流水号不为空时才返回）
        ///2：异常（交易网流水号不为空时才返回）
        ///3：冲正（交易网流水号不为空时才返回）
        /// </summary>
        public string TranStatus { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public string TranDate { get; set; }
        /// <summary>
        /// 会计日期 即银行主机记账日期
        /// </summary>
        public string AcctDate { get; set; }      
    }
}
