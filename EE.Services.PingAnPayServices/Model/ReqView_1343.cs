using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Model
{
    [Serializable]
    public class ReqView_1343
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
        /// 会员账号 必输
        /// </summary>
        public string AcctId { get; set; }
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
        /// 证号号码 必输
        /// </summary>
        public string IdCode { get; set; }
        /// <summary>
        /// 手机号 必填
        /// </summary>
        public string MobilePhone { get; set; }
    }
}