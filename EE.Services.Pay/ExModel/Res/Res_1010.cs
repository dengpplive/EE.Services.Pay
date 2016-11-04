using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
   
    public partial class Res_1010
    {

        public override string ToString()
        {
            return Utils.ToString<Res_1010>(this);
        }
    }

    /// <summary>
    /// 查询银行端会员子账户信息 1010
    /// </summary>
   
    public partial class AccountItem
    {
        public override string ToString()
        {
            return Utils.ToString<AccountItem>(this);
        }
    }
}
