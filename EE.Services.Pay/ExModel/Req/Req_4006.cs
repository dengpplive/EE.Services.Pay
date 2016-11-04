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
    /// 企业交易明细详细信息查询[4006]
    /// </summary>   
    public partial class Req_4006
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4006>(this);
        }
    }
}
