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
    /// 查交易网端会员管理账户余额【1019】
    /// </summary>   
    public partial class Req_1019
    {
        public override string ToString()
        {
            return Utils.ToString<Req_1019>(this);
        }
    }
}
