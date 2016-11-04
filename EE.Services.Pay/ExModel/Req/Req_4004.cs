using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 企业单笔资金划转[4004]
    /// </summary>  
    public partial class Req_4004
    {        
        public override string ToString()
        {
            return Utils.ToString<Req_4004>(this);
        }

    }
}
