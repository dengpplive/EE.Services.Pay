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
    ///  企业当日交易详情查询[4008]
    /// </summary>  
    public partial class Req_4008
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4008>(this);
        }
    }
}
