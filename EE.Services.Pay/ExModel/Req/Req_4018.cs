using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    ///企业大批量资金划转[4018]
    /// </summary>   
    public partial class Req_4018
    {       
        public override string ToString()
        {
            return Utils.ToString<Req_4018>(this);
        }
    }
    public partial class HOResultSet4018R
    {


        public override string ToString()
        {
            return Utils.ToString<HOResultSet4018R>(this);
        }
    }
}
