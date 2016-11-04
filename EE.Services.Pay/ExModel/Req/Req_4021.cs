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
    /// 5.1.1 定期账户信息查询[4021]
    /// </summary>    
    public partial class Req_4021
    {        

        public override string ToString()
        {
            return Utils.ToString<Req_4021>(this);
        }

    }
}
