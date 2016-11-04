using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_KHKF04
    {
        /// <summary>
        /// 企业签约帐号	C(32)
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 订单号	C(20) 【可选】 订单号和银行业务流水号两者不能同时为空
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 银行业务流水号	C(32)  【可选】 订单号和银行业务流水号两者不能同时为空
        /// </summary>
        public string BussFlowNo { get; set; }       
    }
}
