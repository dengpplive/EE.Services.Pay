using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.13 历史余额查询[4012]
    /// </summary>
    [Serializable]
    public partial class Req_4012
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 历史日期	C(8)	必输	限制查询当前日期的前100天内的
        /// </summary>
        public string RptDate { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }       
    }
}
