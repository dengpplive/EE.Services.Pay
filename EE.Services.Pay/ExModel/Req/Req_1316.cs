using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 入金（交易网发起）【1316】
    /// </summary>  
    public partial class Req_1316
    {
        public override string ToString()
        {
            return Utils.ToString<Req_1316>(this);
        }

    }
}
