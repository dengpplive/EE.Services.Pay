using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 查询账户当日历史交易明细[4013]
    /// </summary>
    [Serializable]
    public partial class Req_4013
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string CcyCode { get; set; } = "RMB";
        /// <summary>
        /// 若查询当日明细， 开始、结束日期必须为当天；若查询历史明细，开始、结束日期必须是历史日期 格式:yyyyMMdd
        /// </summary>
        public string BeginDate { get; set; } =
        System.DateTime.Now.ToString("yyyyMMdd");
        /// <summary>
        /// 结束日期 同“开始日期 格式:yyyyMMdd
        /// </summary>
        public string EndDate { get; set; } = System.DateTime.Now.ToString("yyyyMMdd");
        /// <summary>
        /// 查询页码 1：第一页，依次递增
        /// </summary>
        public int PageNo { get; set; } = 1;
        /// <summary>
        /// 每页明细数量  默认30笔一页；若自定义，在30 ~1000之间，且每次查询必须固定为此值，否则出现明细遗漏
        /// </summary>
        public int PageSize { get; set; } = 30;
        /// <summary>
        /// 预留字段
        /// </summary>
        public string Reserve { get; set; }
    }
}
