using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EE.Services.PingAnPayServices.Model
{
    [Serializable]
    public class Result
    {
        /// <summary>
        /// 接口的版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 交易日期和时间
        /// </summary>
        public string TrandateTime { get; set; }
        /// <summary>
        /// 请求流水号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 业务交易码
        /// </summary>
        public string FuncCode { get; set; }
        /// <summary>
        /// 应答码  "000000"表示成功 其他失败
        /// </summary>
        public string RspCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string RspMsg { get; set; }
        /// <summary>
        /// 响应内容 业务需要的返回数据不含有报文头数据
        /// </summary>
        public string RspContent { get; set; }

        /// <summary>
        /// 操作员 5位长度
        /// </summary>
        public string CounterId { get; set; }

        /// <summary>
        /// 成功之后 解析后的数据实体
        /// </summary>
        public dynamic Model { get; set; }
    }
}