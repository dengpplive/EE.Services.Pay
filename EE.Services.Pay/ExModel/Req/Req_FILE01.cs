using EE.Services.Pay.Common;
using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 上传文件
    /// </summary>   
    public partial class Req_FILE01
    {

        public override string ToString()
        {
            return Utils.ToString<Req_FILE01>(this);
        }
    }
}
