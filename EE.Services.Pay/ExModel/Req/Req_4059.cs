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
    /// 5.4.6 现金管理子账户余额查询[4059]
    /// </summary>
  
    public partial class Req_4059
    {       

        public override string ToString()
        {
            return Utils.ToString<Req_4059>(this);
        }

    }
}
