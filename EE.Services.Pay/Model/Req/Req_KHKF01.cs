using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_KHKF01
    {
        /// <summary>
        /// 批次号	C(20)	要求唯一 必填
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 企业签约的帐号 付款账号	C(32) 必填
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 费项代码	可选 C(10)
        /// </summary>
        public string BusiType { get; set; } = "00000";
        /// <summary>
        /// 单位代码 [可选]	C(32) 
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 总笔数	Number(10) 最大30000笔 必填
        /// </summary>
        public int TotalNum { get; set; }
        /// <summary>
        /// 总金额	Number(14,2) 以元为单位，2位小数 必填
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 批次备注 [可选]	C(30)
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 文件名称	C(30) 必填
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 密码	C(100)	由b2bi返回，用于解密文件 必填
        /// </summary>
        public string RandomPwd { get; set; }
        /// <summary>
        /// 文件摘要 [可选]	C(200)	由b2bi返回，用于核对文件是否完整
        /// </summary>
        public string HashData { get; set; }
        /// <summary>
        /// 签名值	C(5000)	[可选]	由b2bi返回，用于核对文件的发起客户身份
        /// </summary>
        public string SignData { get; set; }       
    }
}
