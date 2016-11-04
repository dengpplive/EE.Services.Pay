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
    /// 1020 查会员出入金账号的银行余额
    /// </summary>  
    public partial class Req_1020
    {
        public override string ToString()
        {
            return Utils.ToString<Req_1020>(this);
        }

    }
}
