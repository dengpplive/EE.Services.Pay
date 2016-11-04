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
    /// 3.6 企业批量实时资金划转[4014]
    /// </summary>   
    public partial class Req_4014
    {
        
        public override string ToString()
        {
            return Utils.ToString<Req_4014>(this);
        }
    }
    public partial class HOResultSet4014R
    {       
        public override string ToString()
        {
            return Utils.ToString<HOResultSet4014R>(this);
        }
    }
}
