using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    ///  离岸账户转账[4020]
    /// </summary>   
    public partial class Req_4020
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4020>(this);
        }

    }
}
