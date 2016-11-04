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
    /// 4.1 明细报表查询接口[F001]
    /// </summary>    
    public partial class Req_F001
    {       

        public override string ToString()
        {
            return Utils.ToString<Req_F001>(this);

        }
    }
}
