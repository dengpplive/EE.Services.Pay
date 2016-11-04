using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 企业交易明细详细信息查询[4006]
    /// </summary>
    [Serializable]
    public partial class Req_4006
    {
        /// <summary>
        /// 前置机代码	Char (6)	Y
        /// </summary>
        public string PreHostCode { get; set; }
        /// <summary>
        /// 前置机流水号	Char (14)	Y
        /// </summary>
        public string PreNo { get; set; }
        /// <summary>
        /// 业务类型	Char (5)	Y
        /// </summary>
        public string BusinessType { get; set; }
        /// <summary>
        /// 账号	Char (14)	N
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 交易代码	Char (4)	N
        /// </summary>
        public string TxnCode { get; set; }
        /// <summary>
        /// 冲正标志	Char (1)	N	*—反交易；空格—正常交易
        /// </summary>
        public string OrFlag { get; set; }
        /// <summary>
        /// 主机流水号	Char (7)	N
        /// </summary>
        public string HostTrace { get; set; }
        /// <summary>
        /// 货币代码	Char (3)	N	
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 借贷标志	Char (2)	N	D—转出；C—转入
        /// </summary>
        public string DcFlag { get; set; }
        /// <summary>
        /// 交易金额	Char (13)	N
        /// </summary>
        public decimal TranAmount { get; set; }
        /// <summary>
        /// 摘要	Char (21)	N
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 交易账户	Char (15)	N
        /// </summary>
        public string TxAcctNo { get; set; }
        /// <summary>
        /// 网点号	Char (10)	N
        /// </summary>
        public string UnitNo { get; set; }
        /// <summary>
        /// 交易柜员	Char (6)	N
        /// </summary>
        public string CounterID { get; set; }
        /// <summary>
        /// 保留字段1	Char(120)	N
        /// </summary>

        public string Reserve { get; set; }
        /// <summary>
        /// 应用码	Char(2)	N	新增，对应4002的返回的值。
        /// </summary>
        public string JJCode { get; set; }       
    }
}
