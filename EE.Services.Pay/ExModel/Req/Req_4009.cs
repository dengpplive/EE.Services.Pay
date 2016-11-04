using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.16 银证转账[4009]
    /// </summary>   
    public partial class Req_4009
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4009>(this);
        }

    }
}
