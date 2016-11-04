using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 代发代扣申请接口[4047]
    /// </summary>   
    public partial class Req_4047
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4047>(this);
        }
    }
    public partial class HOResultSet4047R
    {       
        public override string ToString()
        {
            return Utils.ToString<HOResultSet4047R>(this);
        }

    }
}
