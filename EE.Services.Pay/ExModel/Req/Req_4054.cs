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
    /// 5.2.1 集团内账户预结息/结息 (4054)
    /// </summary>
   
    public partial class Req_4054
    {       
        public override string ToString()
        {
            return Utils.ToString<Req_4054>(this);
        }
    }
}
