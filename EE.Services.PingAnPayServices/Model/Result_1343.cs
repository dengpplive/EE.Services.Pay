using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Model
{
    [Serializable]
    public class Result_1343
    {
        /// <summary>
        /// 交易网会员代码 必填
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 指令流水号 必填
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }


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