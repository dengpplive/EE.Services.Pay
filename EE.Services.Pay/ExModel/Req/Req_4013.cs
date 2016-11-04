using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 查询账户当日历史交易明细[4013]
    /// </summary>  
    public partial class Req_4013
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4013>(this);
        }
    }
}
