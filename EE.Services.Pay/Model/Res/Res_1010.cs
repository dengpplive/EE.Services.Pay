using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1010
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
        public string LastPage { get; set; } = "0";
        /// <summary>
        /// 子账户个数 重复次数（一次最多返回20条记录）
        /// </summary>
        public string RecordNum { get; set; } = "20";
        /// <summary>
        /// 信息数组
        /// </summary>
        public List<AccountItem> AccountList { get; set; } = new List<AccountItem>();

        public string Reserve { get; set; }       
    }

    /// <summary>
    /// 查询银行端会员子账户信息 1010
    /// </summary>
    [Serializable]
    public partial class AccountItem
    {
        /// <summary>
        /// 子账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 子账号性质 1：虚拟账号，2：实体账号
        /// </summary>
        public string CustFlag { get; set; }
        /// <summary>
        /// 子账号属性 1：普通会员子账户 2：挂账子账户  3：手续费子账户 4：利息子账户 6：清收子账户
        /// </summary>
        public string CustType { get; set; }
        /// <summary>
        /// 状态 1：正常  2：已销户
        /// </summary>
        public string CustStatus { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 上级监管账号
        /// </summary>
        public string MainAcctId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 账户总余额
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 账户可用余额
        /// </summary>
        public string TotalBalance { get; set; }
        /// <summary>
        /// 账户总冻结金额
        /// </summary>
        public string TotalFreezeAmount { get; set; }
        /// <summary>
        /// 维护日期 开户日期或修改日期
        /// </summary>
        public string TranDate { get; set; }       
    }
}
