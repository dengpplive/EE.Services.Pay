using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.24 查询券商端资金台帐余额[4010]
    /// </summary>
    [Serializable]
    public partial class Req_4010
    {
        /// <summary>
        /// 银行结算账号	C(20)	必输
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 证券资金密码	C(30)	非必输	明文
        /// </summary>
        public string StockAccPwd { get; set; }       
    }
}
