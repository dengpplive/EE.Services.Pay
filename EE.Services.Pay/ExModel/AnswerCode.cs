using System;
using System.Collections.Generic;
namespace EE.Services.Pay.Model
{
    /// <summary>
    /// 应答码表
    /// </summary>   
    [Serializable]
    public class AnswerCode
    {
        public List<RspStatus> AnswerList = new List<RspStatus>();
    }
    /// <summary>
    /// 应答码
    /// </summary>
    [Serializable]
    public class RspStatus
    {
        /// <summary>
        /// 代码编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Msg { get; set; }
    }
}
