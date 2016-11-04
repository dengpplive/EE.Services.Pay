using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.22 代发代扣结果查询XML接口[4048]
    /// </summary>
    [Serializable]
    public partial class Req_4048
    {
        /// <summary>
        /// 凭证号	C (20)	Y	标示交易唯一性
        /// </summary>
        public string ThirdVoucher { get; set; }       
    }
}
