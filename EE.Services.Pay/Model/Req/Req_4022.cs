using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.4.1 集团总账户查询[4022]
    /// </summary>
    [Serializable]
    public partial class Req_4022
    {
        /// <summary>
        /// 总账户
        /// </summary>
        public string AC { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string ccyId { get; set; } = "RMB";       
    }
}
