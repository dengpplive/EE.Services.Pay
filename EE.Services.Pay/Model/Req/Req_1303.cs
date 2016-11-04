using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1303
    {
        /// <summary>
        /// 功能标志  1:指定，2：修改，3：删除
        /// </summary>
        public int FuncFlag { get; set; }
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 会员子账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 会员证件类型
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 会员证件号码
        /// </summary>
        public string IdCode { get; set; }
        /// <summary>
        /// 出/入金账号
        /// </summary>
        public string RelatedAcctId { get; set; }
        /// <summary>
        /// 账号性质 1：出金账号
        ///2：入金账号
        ///3：出金账号&入金账号（默认）
        /// </summary>
        public string AcctFlag { get; set; } = "3";
        /// <summary>
        /// 转账方式  1：本行（默认）
        ///2：同城 
        ///3：异地汇款
        /// </summary>
        public string TranType { get; set; } = "1";
        /// <summary>
        /// 账号名称
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 联行号 本行为分行号
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 开户行名称 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 原出入金账号 若FuncFlag为1或者3时为空
        /// </summary>
        public string OldRelatedAcctId { get; set; }
        /// <summary>
        ///  保留域
        /// </summary>
        public string Reserve { get; set; }      
    }
}
