using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 会员注册签约易宝-回填验证【1344】
    /// </summary>
    [Serializable]
    public partial class Req_1344
    {
        /// <summary>
        /// 验证标志 1：短信验证 2：金额验证 必输 C(32)
        /// </summary>
        public int FuncFlag { get; set; } = 1;
        /// <summary>
        /// 指令流水号必输  C(32) 【1343】接口返回的
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 短信验证码 C(7)  可选  当FuncFlag为1时，必输
        /// </summary>
        public string MessageCode { get; set; }
        /// <summary>
        /// 验证金额 9(15)  可选 当FuncFlag为2时，必输
        /// </summary>
        public decimal CheckAmount { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
      
    }
}
