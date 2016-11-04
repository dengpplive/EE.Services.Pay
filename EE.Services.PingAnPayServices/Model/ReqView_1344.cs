using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Model
{
    [Serializable]
    public class ReqView_1344
    {
        /// <summary>
        /// 指令流水号必输  C(32) 【1343】接口返回的
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 短信验证码 C(7)  可选  当FuncFlag为1时，必输
        /// </summary>
        public string MessageCode { get; set; }
    }
}