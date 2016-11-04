using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 单笔转账指令查询[4005]
    /// </summary>
    [Serializable]
    public partial class Req_4005
    {
        /// <summary>
        /// 请求流水号	C(20)	非必输	不建议使用此条件查询
        /// </summary>
        public string OrigThirdLogNo { get; set; }
        /// <summary>
        /// 转账凭证号	C(20)	非必输	推荐使用；
        ///使用4004接口上送的ThirdVoucher或者4014上送的SThirdVoucher
        /// </summary>
        public string OrigThirdVoucher { get; set; }
        /// <summary>
        /// 银行流水号	C(14)	非必输	推荐使用；银行返回的转账流水号
        /// </summary>
        public string OrigFrontLogNo { get; set; }       
    }
}
