using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 查银行端会员资金台帐余额【1010】
    /// </summary>
    [Serializable]
    public partial class Req_1010
    {
        /// <summary>
        /// 资金汇总账号
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 交易网会员代码 市场端的会员ID
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 子账户
        /// </summary>
        public string CustAcctId { get; set; }
        /// <summary>
        /// 查询标志  1：全部 2：普通会员子账户 3：功能子账户（利息、手续费、清收子账户）
        /// </summary>
        public int SelectFlag { get; set; }
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
