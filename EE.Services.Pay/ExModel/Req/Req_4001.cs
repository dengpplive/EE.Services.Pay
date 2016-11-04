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
    /// 企业账户余额查询 [4001]
    /// </summary>   
    public partial class Req_4001
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4001>(this);
        }
    }
}
