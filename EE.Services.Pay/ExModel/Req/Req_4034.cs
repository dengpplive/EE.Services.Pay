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
    /// 3.8 企业汇总资金划转[4034]
    /// </summary>
    
    public partial class Req_4034
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4034>(this);
        }
    }
}
