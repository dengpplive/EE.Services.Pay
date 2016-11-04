using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_KHKF03
    {
        /// <summary>
        /// 订单号	C(20)
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 银行业务流水号	C(32)	银行受理成功，返回业务流水号
        /// </summary>
        public string BussFlowNo { get; set; }       
    }
}
