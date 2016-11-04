using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4024
    {
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 子账户户名
        /// </summary>
        public string subAccountName { get; set; }
        /// <summary>
        /// 子账户开户行
        /// </summary>
        public string subAccountOpenBank { get; set; }
        /// <summary>
        /// 子账户币种
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 总账号
        /// </summary>
        public string headAccountNo { get; set; }
        /// <summary>
        /// 总账户户名
        /// </summary>
        public string headAccountName { get; set; }
        /// <summary>
        /// 总账户开户行
        /// </summary>
        public string headOpenBranch { get; set; }
        /// <summary>
        /// 总账户币种
        /// </summary>
        public string headCurCode { get; set; }
        /// <summary>
        /// 上级账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 上级账户户名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string AcctOpenBank { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string supCurCode { get; set; }
        /// <summary>
        /// 是否翻页 Y翻页N不翻页
        /// </summary>
        public string turnPageFlag { get; set; } = "N";
        /// <summary>
        /// 每页显示记录总数
        /// </summary>
        public string turnPageShowNum { get; set; }
        /// <summary>
        /// 当页最后一条交易记录序号 用于下次翻页传递
        /// </summary>
        public string serialNo { get; set; }
        /// <summary>
        /// 结果列表
        /// </summary>
        public List<Result_4024> list { get; set; } = new List<Result_4024>();
    }
    [Serializable]
    public partial class Result_4024
    {
        /// <summary>
        /// 交易日期
        /// </summary>
        public string tranDate { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string tranAmount { get; set; }
        /// <summary>
        /// 台账余额
        /// </summary>
        public string virAccBalance { get; set; }
        /// <summary>
        /// 借贷标志 1-借、2-贷
        /// </summary>
        public string loanFlag { get; set; }
        /// <summary>
        /// 委贷标志 1-是、2-否
        /// </summary>
        public string entrustLoanFlag { get; set; }
        /// <summary>
        /// 备注 交易备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public string tranTime { get; set; }
        /// <summary>
        /// 对方账号
        /// </summary>
        public string otherAccountNo { get; set; }
        /// <summary>
        /// 对方账户名
        /// </summary>
        public string otherAccountName { get; set; }
    }
}
