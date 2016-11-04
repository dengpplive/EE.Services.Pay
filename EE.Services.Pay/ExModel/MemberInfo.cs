using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model
{
    [Serializable]
    public class MemberInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 账号状态 true 可用 false禁用
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 处理状态 -1:未处理  0：成功 3：待确认
        /// </summary>
        public int DealStatus { get; set; } = -1;
        /// <summary>
        /// 会员类型 必输 1：企业 2 ：个人
        /// </summary>
        public int CpFlag { get; set; } = 1;
        /// <summary>
        /// //会员账号 C(32)必输
        /// </summary>
        public string AcctId { get; set; }
        /// <summary>
        /// 银行类型 1：本行 2 ：他行
        /// </summary>
        public int BankType { get; set; } = 1;
        /// <summary>
        /// 超级网银号 可选
        /// 企业做小额鉴权，企业必送
        /// </summary>
        public string SBankCode { get; set; }
        /// <summary>
        /// 手机号 必输
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 邮箱  可选
        /// </summary>
        public string EmailAddr { get; set; }
        /// <summary>
        /// 企业注册地 可选 企业落地后柜员审核使用，企业必送
        /// </summary>
        public string RegAddress { get; set; }
        /// <summary>
        /// 邮政编码 可选 企业 UKEY邮寄邮编，企业必送
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// 地址 可选 企业 UKEY邮寄地址，企业必送
        /// </summary>
        public string ErpAddress { get; set; }
        /// <summary>
        /// 联系人 可选 企业 UKEY邮寄收件人，企业必送
        /// </summary>
        public string ContactUser { get; set; }
        /// <summary>
        /// 指令流水号
        /// </summary>
        public string SerialNo { get; set; }



        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 子账户账号
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 交易网会员代码
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 子账户证件类型
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 子账户证件号码
        /// </summary>
        public string IdCode { get; set; }
        /// <summary>
        /// 子账户性质 1：虚拟户
        /// </summary>
        public string CustFlag { get; set; }
        /// <summary>
        /// 初始总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 初始可用余额
        /// </summary>
        public decimal TotalBalance { get; set; }
        /// <summary>
        /// 初始冻结金额
        /// </summary>
        public decimal TotalFreezeAmount { get; set; }





        /// <summary>
        /// 出/入金账号
        /// </summary>
        public string RelatedAcctId { get; set; }
        /// <summary>
        /// 账号性质 3：出金账号&入金账号
        /// </summary>
        public string AcctFlag { get; set; }
        /// <summary>
        /// 转账方式 1：本行
        /// </summary>
        public string TranType { get; set; }
        /// <summary>
        /// 账号名称
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 联行号  大小额行号 若绑定他行卡作为资金转出账户则必填。
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 开户行名称  
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 付款人/收款人地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 原出入金账号
        /// </summary>
        public string OldRelatedAcctId { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
        /// <summary>
        /// 最后一次操作源
        /// </summary>
        public string LastOption { get; set; }
    }
}
