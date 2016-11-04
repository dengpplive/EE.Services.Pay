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
    /// 3.20 支付指令退票查询[4019]
    /// </summary>   
    public partial class Req_4019
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4019>(this);
        }
    }
}
