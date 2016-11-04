using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.16 代理行支付当日交易查询[4011]
    /// </summary>   
    public partial class Req_4011
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4011>(this);
        }
    }
}
