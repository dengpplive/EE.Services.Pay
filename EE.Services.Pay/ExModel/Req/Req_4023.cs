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
    /// 5.4.2 集团子账户列表查询 [4023]
    /// </summary>
    
    public partial class Req_4023
    {       
        public override string ToString()
        {
            return Utils.ToString<Req_4023>(this);
        }

    }
}
