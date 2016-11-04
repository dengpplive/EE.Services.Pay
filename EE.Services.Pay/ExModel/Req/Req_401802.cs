using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 汇总批量付款电子回单查询[401802]
    /// </summary>    
    public partial class Req_401802
    {
        public override string ToString()
        {
            return Utils.ToString<Req_401802>(this);
        }
    }
}
