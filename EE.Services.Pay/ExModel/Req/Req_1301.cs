using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 会员开销户确认【1301】
    /// </summary>   
    public partial class Req_1301
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_1301>(this);
        }
    }
}
