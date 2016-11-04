using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 查询时间段会员交易流水信息 1324
    /// </summary>
    [Serializable]
    public partial class Req_1324
    {

        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 交易网流水号 若为空则返回全部
        /// </summary>
        public string OrigThirdLogNo { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>

        public string BeginDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>

        public string EndDate { get; set; }
        /// <summary>
        /// 第几页 起始值为1，每次最多返回20条记录，第二页返回的记录数为第21至40条记录，第三页为41至60条记录，顺序均按照建立时间的先后
        /// </summary>

        public int PageNum { get; set; } = 1;
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}
