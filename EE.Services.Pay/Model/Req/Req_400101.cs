using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 借记卡客户信息验证接口[400101]
    /// </summary>
    [Serializable]
    public partial class Req_400101
    {
        /// <summary>
        /// 借记卡号
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 户名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 证件类型代码 参考“证件类型代码表
        /// </summary>
        public string CertType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertNo { get; set; }
        /// <summary>
        /// 银行预留手机
        /// </summary>
        public string Mobile { get; set; }       
    }
}
