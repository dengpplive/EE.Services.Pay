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
    /// 5.1.2 查询定活通存单信息[4025]
    /// </summary>
 
    public partial class Req_4025
    {        

        public override string ToString()
        {
            return Utils.ToString<Req_4025>(this);
        }

    }
}
