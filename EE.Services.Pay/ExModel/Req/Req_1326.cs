using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 银行复核通知【1326】
    /// </summary>  
    public partial class Req_1326
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_1326>(this);
        }

    }
}
