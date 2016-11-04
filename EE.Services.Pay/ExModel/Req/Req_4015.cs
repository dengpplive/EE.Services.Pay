using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.6 批量转账指令查询[4015]
    /// </summary>  
    public partial class Req_4015
    {       
        public override string ToString()
        {
            return Utils.ToString<Req_4015>(this);
        }
    }
    public partial class HOResultSet4015R
    {
        public override string ToString()
        {
            return Utils.ToString<HOResultSet4015R>(this);
        }
    }
}
