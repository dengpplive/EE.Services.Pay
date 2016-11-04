using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 入金（银行发起） [1310]
    /// </summary>  
    public partial class Req_1310
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_1310>(this);
        }
    }
}
