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
    /// 单笔提交转汇总批量[400401]
    /// </summary> 
    public partial class Req_400401
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_400401>(this);
        }
    }
}
