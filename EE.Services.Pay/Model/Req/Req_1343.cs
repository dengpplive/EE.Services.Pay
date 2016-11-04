using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1343
    {
        /// <summary>
        /// 资金汇总账号 C(32)必输               
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 交易网会员代码 C(32)         必输
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 会员名称 必输
        /// </summary>
        public string CustName { get; set; }
        /// <summary>
        /// 会员证件类型 见文档附录的“接口证件类型说明”
        ///例如：身份证送1
        ///营业执照送68
        ///社会信用代码证送73
        ///开户许可证 送70（非企业类机构送开户许可证）
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 会员证件号码 必输
        /// </summary>
        public string IdCode { get; set; }
        /// <summary>
        /// 1：企业 2：个人 必输
        /// </summary>
        public int CpFlag { get; set; } = 1;
        /// <summary>
        /// 会员账号 必输
        /// </summary>
        public string AcctId { get; set; }
        /// <summary>
        /// 银行类型        
        ///C(1) 必输 1：本行 2：他行
        /// </summary>
        public int BankType { get; set; } = 1;
        /// <summary>
        /// 开户行名称 必输
        ///若大小额行号不填则送超级网银号对应的银行名称，若填大小额行号则送大小额行号对应的银行名称
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 必输
        /// 大小额行号 若绑定他行卡作为资金转出账户则必填。
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 超级网银号 可选  企业做小额鉴权，企业必送
        /// </summary>
        public string SBankCode { get; set; }
        /// <summary>
        /// 手机号 必填
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 邮箱 可选
        /// </summary>
        public string EmailAddr { get; set; }
        /// <summary>
        /// 企业注册地  C(120) 可选 企业落地后柜员审核使用，企业必送        
        /// </summary>
        public string RegAddress { get; set; }
        /// <summary>
        /// 开户许可证
        /// </summary>
        //public string OpenLicense { get; set; }
        /// <summary>
        /// 邮政编码  可选 企业UKEY邮寄邮编，企业必送
        /// </summary>        
        public string Zip { get; set; }
        /// <summary>
        /// 地址  C(120)    可选 企业UKEY邮寄地址，企业必送
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系人  C(120) 可选 企业UKEY邮寄收件人，企业必送
        /// </summary>
        public string ContactUser { get; set; }
        /// <summary>
        /// 保留域  C(120)      可选
        /// </summary>
        public string Reserve { get; set; }
    }
}
