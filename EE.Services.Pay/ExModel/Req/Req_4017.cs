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
    /// 3.18 银行联行号查询[4017]
    /// </summary>    
    public partial class Req_4017
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4017>(this);
        }

    }
}
