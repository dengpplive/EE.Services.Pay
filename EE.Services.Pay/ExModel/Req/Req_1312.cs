using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 出金（银行发起）【1312】
    /// </summary>   
    public partial class Req_1312
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_1312>(this);
        }
    }
}
