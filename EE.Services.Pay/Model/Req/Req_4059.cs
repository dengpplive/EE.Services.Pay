using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.4.6 现金管理子账户余额查询[4059]
    /// </summary>
    [Serializable]
    public partial class Req_4059
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 钞汇标志	C(1)	非必输	C 钞户, R汇户,默认为C。
        /// </summary>
        public string CcyType { get; set; } = "C";
        /// <summary>
        /// 货币类型	C(3)	非必输	RMB 人民币,USD 美元，HKD 港币, 默认为RMB
        /// </summary>
        public string CcyCode { get; set; } = "RMB";      
    }
}
