using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 台账记录查询[4024]
    /// </summary>
    [Serializable]
    public partial class Req_4024
    {
        /// <summary>
        /// 上级账号 若子账户为虚子账户，必输
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 账号 若此账户为子账户，查询主-子账户的台账；若为主账户，则查询主账户的台账。
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 【可选】 第一次查询该项不输入，若有翻页送前一次查询返回的SEQNO
        /// </summary>
        public string serialNo { get; set; }
        /// <summary>
        /// 起始日期 不输默认为上月月初
        /// </summary>
        public string beginDate { get; set; }
        /// <summary>
        /// 截止日期 不输默认为交易日，该项不能大于“起始日期”6个月
        /// </summary>
        public string endDate { get; set; }       
    }
}
