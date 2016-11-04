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
    /// 3.13 历史余额查询[4012]
    /// </summary>  
    public partial class Req_4012
    {        

        public override string ToString()
        {
            return Utils.ToString<Req_4012>(this);
        }

    }
}
