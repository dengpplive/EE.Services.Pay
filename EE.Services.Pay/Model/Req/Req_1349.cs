using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1349
    {
        /// <summary>
        /// 资金汇总账号 必输
        /// </summary>
        public string SupAcctId { get; set; }
        /// <summary>
        /// 对账文件类型  必输
        /// 20：出入金文件 
        ///21：开销户文件
        ///22：会员余额文件
        ///23：会员交易文件
        ///24：在途充值文件
        /// </summary>
        public int FuncFlag { get; set; } = 20;
        /// <summary>
        /// 查询日期 yyyyMMdd 必输 
        /// </summary>
        public string TranDate { get; set; }
        /// <summary>
        /// 保留域 可选
        /// </summary>
        public string Reserve { get; set; }
    }
}
