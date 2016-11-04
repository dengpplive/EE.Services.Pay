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
    /// 3.24 查询券商端资金台帐余额[4010]
    /// </summary>   
    public partial class Req_4010
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4010>(this);
        }
    }
}
