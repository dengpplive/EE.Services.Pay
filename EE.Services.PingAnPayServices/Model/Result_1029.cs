using EE.Services.Pay.Model.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Model
{
    [Serializable]
    public class Result_1029
    {
        /// <summary>
        /// 返回结果数据
        /// </summary>
        public Res_1029 Data { get; set; }
        /// <summary>
        /// 应答码  "000000"表示成功 其他失败
        /// </summary>
        public string RspCode { get; set; }
        /// <summary>
        /// 返回结果描述
        /// </summary>
        public string RspMsg { get; set; }
    }
}