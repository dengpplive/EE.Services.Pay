using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 出金（交易网发起）【1318】
    /// </summary>   
    public partial class Req_1318
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_1318>(this);
        }

    }
}
