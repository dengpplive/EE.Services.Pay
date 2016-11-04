using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.6 批量转账指令查询[4015]
    /// </summary>
    [Serializable]
    public partial class Req_4015
    {
        private List<HOResultSet4015R> _HOResultSet4015R = new List<Req.HOResultSet4015R>();
        private int _PageCts = 500;
        private int _PageNo = 1;
        /// <summary>
        /// 批量转账凭证号 批量转账发起时上送的凭证号
        /// </summary>
        public string OrigThirdVoucher { get; set; }
        /// <summary>
        /// 查询类型 【可选】，默认为0  0或者空：全部；1:成功 2:失败 3:处理中 4:退票
        /// </summary>
        public int QueryType { get; set; }
        /// <summary>
        /// 每页笔数 【可选】，默认单次返回上限500笔 每次查询返回的笔数，用于分页查询。建议为50，最大500；     单批多次分页查询每页笔数必须保持一致。
        /// </summary>
        public int PageCts { get { return _PageCts; } set { _PageCts = value; } }
        /// <summary>
        /// 【可选】，默认为1 当前查询的页码，用于分页查询。从1开始递增
        /// </summary>
        public int PageNo { get { return _PageNo; } set { _PageNo = value; } }
        /// <summary>
        /// 多条记录
        /// </summary>
        public List<HOResultSet4015R> HOResultSet4015R { get { return _HOResultSet4015R; } set { _HOResultSet4015R = value; } }      
    }
    public partial class HOResultSet4015R
    {
        /// <summary>
        /// 单笔转账凭证号 批次中单笔流水号；若上送此单笔凭证号，则只返回此笔交易结果。此域若上送则QueryType无效，且不分页。  最多支持500个
        /// </summary>
        public string SThirdVoucher { get; set; }       
    }
}
