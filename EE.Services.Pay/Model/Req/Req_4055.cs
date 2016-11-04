using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.4.3 现金管理合约查询[4055]
    /// </summary>
    [Serializable]
    public partial class Req_4055
    {
        /// <summary>
        /// 总账户 否	若子账户为虚子账户，必输
        /// </summary>
        public string AC { get; set; } = "";
        /// <summary>
        /// 子账户	必输
        /// </summary>
        public string SUBAC { get; set; }     
    }
}
