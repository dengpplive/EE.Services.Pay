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
    /// 查询支付指令状态【1327】
    /// </summary>   
    public partial class Req_1327
    {
        public override string ToString()
        {
            return Utils.ToString<Req_1327>(this);
        }

    }
}
