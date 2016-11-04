using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 借记卡客户信息验证接口[400101]
    /// </summary>    
    public partial class Req_400101
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_400101>(this);
        }
    }
}
