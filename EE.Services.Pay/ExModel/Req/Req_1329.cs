using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 子账户直接支付【1329】
    /// </summary>  
    public partial class Req_1329
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_1329>(this);
        }
    }
}
