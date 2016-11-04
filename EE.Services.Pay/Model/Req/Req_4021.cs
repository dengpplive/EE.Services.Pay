using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.1.1 定期账户信息查询[4021]
    /// </summary>
    [Serializable]
    public partial class Req_4021
    {
        /// <summary>
        /// 起始存单号  	Char(6)	Y	第一次查询送1，若有后续送上次返回最后一个存款顺序号SeqNo+1
        /// </summary>
        public int PageNo { get; set; } = 1;
        /// <summary>
        /// 账号	Char(14)	Y	定期账号
        /// </summary>
        public string AcctNo { get; set; }       
    }
}
