using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1016
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
        /// 子账户个数 重复次数（一次最多返回20条记录）
        /// </summary>
        public string RecordNum { get; set; }
        /// <summary>
        /// 信息数组
        /// </summary>
        public List<OpenAccountInfo> OpenAccountInfoList { get; set; } = new List<OpenAccountInfo>();

        public string Reserve { get; set; }       
    }
    /// <summary>
    /// 查询开户信息 1016
    /// </summary>
    [Serializable]
    public partial class OpenAccountInfo
    {
        /// <summary>
        /// 银行前置流水号
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 交易状态 （1：开户 2：销户 3：待确认）
        /// </summary>
        public string UserStatus { get; set; }
        /// <summary>
        /// 子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 子账户性质 （1：虚拟账号）
        /// </summary>
        public string CustFlag { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public string TranDate { get; set; }
        /// <summary>
        /// 操作柜员号
        /// </summary>
        public string CounterId { get; set; }       
    }
}
