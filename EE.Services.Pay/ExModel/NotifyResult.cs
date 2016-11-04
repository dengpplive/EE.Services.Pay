using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model
{
    /// <summary>
    /// 通知数据处理
    /// </summary>
    [Serializable]
    public class NotifyResult
    {
        /// <summary>
        /// 解析后的数据
        /// </summary>
        public DataResult DataResult { get; set; }
        /// <summary>
        /// 接收银行的请求的数据
        /// </summary>
        public dynamic ReqData { get; set; }
        /// <summary>
        /// 需要返回给银行的数据 只需要属性赋值
        /// </summary>
        public dynamic RspData { get; set; }
        /// <summary>
        /// 业务的处理状态 成功返回应答码为"000000",其他均失败
        /// </summary>
        public RspStatus RspStatus { get; set; } = new RspStatus();

    }
}
