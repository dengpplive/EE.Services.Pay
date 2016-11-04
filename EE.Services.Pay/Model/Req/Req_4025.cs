using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.1.2 查询定活通存单信息[4025]
    /// </summary>
    [Serializable]
    public partial class Req_4025
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string ACNO { get; set; }
        /// <summary>
        /// 存款顺序号	第一次查询送1，后续分页送前一次返回的起始存单序号Q10-STR-SEQNO
        /// </summary>
        public string ACSEQ { get; set; } = "1";      
    }
}
