﻿using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 子账户冻结解冻【1029】
    /// </summary>   
    public partial class Req_1029
    {
        public override string ToString()
        {
            return Utils.ToString<Req_1029>(this);
        }

    }
}
