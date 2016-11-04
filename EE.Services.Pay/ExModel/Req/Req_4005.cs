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
    /// 单笔转账指令查询[4005]
    /// </summary> 
    public partial class Req_4005
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4005>(this);
        }
    }
}
