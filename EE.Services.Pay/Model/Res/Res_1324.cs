using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1324
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
        public List<TradeFlowiInfo> TradeFlowiInfoList { get; set; } = new List<TradeFlowiInfo>();
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }        
    }
    /// <summary>
    /// 会员的交易流水信息
    /// </summary>
    [Serializable]
    public partial class TradeFlowiInfo
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
        /// 记账标志 1：申请支付 2：冻结 3：解冻 4：收费 5：退费6：会员支付到市场 7：市场支付到会员 8：确认支付 9：可用直接支付 10：撤销支付 11：代理确认支付 12：强制支付 13：冻结直接支付 14：冻结收费 15：会员冻结支付到市场16：子账户间可用支付17：子账户间冻结支付
        /// </summary>
        public string TranFlag { get; set; }
        /// <summary>
        /// 交易状态 0：成功 1:失败（交易网流水号不为空时才返回）2：异常（交易网流水号不为空时才返回，异常是中间状态，需等待一段时间（5-10分钟）后重新查询结果）
        /// </summary>
        public string TranStatus { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 转出子账户 即付款方
        /// </summary>
        public string OutCustAcctId { get; set; }
        /// <summary>
        /// 转出会员代码
        /// </summary>
        public string OutThirdCustId { get; set; }
        /// <summary>
        /// 转入子账户 即收款方
        /// </summary>
        public string InCustAcctId { get; set; }
        /// <summary>
        /// 转入会员代码
        /// </summary>
        public string InThirdCustId { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public string TranDate { get; set; }       
    }
}
