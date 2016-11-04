using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4006
    {
        /// <summary>
        /// 前置机代码	Char (6)
        /// </summary>
        public string PreHostCode { get; set; }
        /// <summary>
        /// 业务类型	Char (5)
        /// </summary>
        public string BusinessType { get; set; }
        /// <summary>
        /// 前置流水号	Char (14)
        /// </summary>
        public string PreNo { get; set; }
        /// <summary>
        /// 日期	Char (8)
        /// </summary>
        public string TranDate1 { get; set; }
        /// <summary>
        /// 时间	Char (6)
        /// </summary>
        public string TranTime1 { get; set; }
        /// <summary>
        /// 网点号	Char (4)
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// 付款方名称	Char (140)
        /// </summary>
        public string SendName { get; set; }
        /// <summary>
        /// 付款方开户行名称	Char (140)
        /// </summary>
        public string SendBank { get; set; }
        /// <summary>
        /// 付款方账户	Char (32)
        /// </summary>
        public string SendAccount { get; set; }
        /// <summary>
        /// 收款方名称	Char (140)
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 收款方开户行名	Char (140)
        /// </summary>
        public string AcctBank { get; set; }
        /// <summary>
        /// 收款方账户	Char (32)
        /// </summary>
        public string AcctAccount { get; set; }
        /// <summary>
        /// 交易金额	Char (15)
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 币种	Char (3)
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 手续费	Char (13)
        /// </summary>
        public decimal Fee1 { get; set; }
        /// <summary>
        /// 手续费1	Char (13)
        /// </summary>
        public decimal Fee2 { get; set; }
        /// <summary>
        /// 摘要1	Char (100)
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// 摘要2	Char (40)		第一字节：0表示系统自动归集交易，1表示系统自动补充交易（企业需与银行约定是否需区分交易种类，默认不区分）
        /// </summary>
        public string Notes1 { get; set; }      
    }
}
