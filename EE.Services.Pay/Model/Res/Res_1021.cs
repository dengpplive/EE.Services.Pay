using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1021
    {     
        /// <summary>
        /// 汇总账号总数
        /// </summary>
        public string RecordNum { get; set; }
        /// <summary>
        /// 所属交易网代码
        /// </summary>
        public string TranWebCode { get; set; }
        /// <summary>
        /// 交易网名称
        /// </summary>
        public string TranWebName { get; set; }
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string AcctId { get; set; }
        /// <summary>
        /// 户名
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdCode { get; set; }
        /// <summary>
        /// 网银用户名
        /// </summary>
        public string WebName { get; set; }
        /// <summary>
        /// 网银客户号
        /// </summary>
        public string WebCustId { get; set; }
        /// <summary>
        /// 手机号码1
        /// </summary>
        public string MobilePhone1 { get; set; }
        /// <summary>
        /// 手机号码2
        /// </summary>
        public string MobilePhone2 { get; set; }
        /// <summary>
        /// 邮箱1
        /// </summary>
        public string EmailAddr1 { get; set; }
        /// <summary>
        /// 邮箱2
        /// </summary>
        public string EmailAddr2 { get; set; }
        /// <summary>
        /// 服务类型 5：存管服务
        /// </summary>
        public string FuncFlag { get; set; }
        /// <summary>
        /// 开立子账户方式 3：都可以
        /// </summary>
        public string OpenCustFlag { get; set; }
        /// <summary>
        /// 币种 默认为RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 当前余额 当前存款的可用余额，与主机一致
        /// </summary>
        public decimal CurBalance { get; set; }
        /// <summary>
        /// 子账户资金合计 普通子账户的总金额合计
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 可转出资金合计 手续费和利息子帐户的余额合计
        /// </summary>
        public decimal TranOutAmount { get; set; }
        /// <summary>
        ///  可用余额总计 普通子会员的可用余额合计
        /// </summary>
        public decimal TotalBalance { get; set; }
        /// <summary>
        /// 冻结金额总计 普通子会员的冻结金额总计
        /// </summary>
        public decimal TotalFreeze { get; set; }
        /// <summary>
        /// 子账户总数 包括已销户的子账户
        /// </summary>
        public int CustTotal { get; set; }

        /// <summary>
        /// 有效子账户数 不包括已销户的子账户
        /// </summary>
        public int CustAvailTotal { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        public string TranDate { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}
