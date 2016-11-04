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
    /// 5.4.1 集团总账户查询[4022]
    /// </summary>
    public partial class Req_4022
    {      

        public override string ToString()
        {
            return Utils.ToString<Req_4022>(this);
        }
    }
}
