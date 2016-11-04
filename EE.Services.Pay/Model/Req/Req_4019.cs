using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.20 支付指令退票查询[4019]
    /// </summary>
    [Serializable]
    public partial class Req_4019
    {
        /// <summary>
        /// 企业付款帐号	C(20)	Y
        /// </summary>
        public string AccNo { get; set; }
        /// <summary>
        /// 查询开始时间	C(8)	Y	yyyyMMdd 查询时间范围为30天
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 查询结束时间	C(8)	Y	yyyyMMdd查询时间范围为30天，包含次天
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 当前页码	C(10)	Y	从1开始递增
        /// </summary>
        public int PageNo { get; set; } = 1;
        /// <summary>
        /// 每页记录条数	C(5)	N	默认为30；最大300
        /// 对同一个账户的分页查询此值保持一致
        /// </summary>
        public string PageCts { get; set; } = "30";
    }
}
