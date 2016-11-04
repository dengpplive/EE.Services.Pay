using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 查银行端会员资金台帐余额【1010】
    /// </summary>
  
    public partial class Req_1010
    {
        public override string ToString()
        {
            return Utils.ToString<Req_1010>(this);
        }
    }
}
