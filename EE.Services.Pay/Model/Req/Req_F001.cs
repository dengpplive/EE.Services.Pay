using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 4.1 明细报表查询接口[F001]
    /// </summary>
    [Serializable]
    public partial class Req_F001
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string QueryDate { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 交易码	C(6)		4004/4014/4018/C004/C005/4047
        /// </summary>
        public string BsnCode { get; set; }        
    }
}
