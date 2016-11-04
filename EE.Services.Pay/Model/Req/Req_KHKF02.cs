using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_KHKF02
    {
        /// <summary>
        /// 企业帐号	C(32)
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 批次号	C(20)
        /// </summary>
        public string BatchNo { get; set; }        
    }
}
