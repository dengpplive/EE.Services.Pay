using EE.Services.Pay.Common;
using System;
namespace EE.Services.Pay.Model
{
    /// <summary>
    /// 返回的结果 ToModel方法转换成具体的类对象
    /// </summary>
    [Serializable]
    public partial class DataResult
    {
        /// <summary>
        /// 接口的版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 接收到的原始数据包括报文头
        /// </summary>
        public string RecvData { get; set; }
        /// <summary>
        /// 接入的系统(目标系统) 01:银企直连 02:供应链金融 03:交易资金 04:电子商业汇票 05:政府前置 - 昆明国土局 06:供应链1号店 07:POSP信用卡系统 08:资产托管网银 10:交易资金 - P2P系统 11:实物黄金系统 12:政府前置 - 深圳交警 13:交易资金 - 见证系统 14:企业网上银行系统 15:贷贷平安网银 16:橙e物流管理系统 17:橙e App消息推送服务 18:橙e网门户 19: 岼山招标通 21：反交易欺诈侦测平台  22：直通银行子系统
        /// </summary>
        public string TargetSystem { get; set; }
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
        /// 应答码
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
        /// 银行企业合作的唯一标识代码
        /// </summary>
        public string PartnerCode { get; set; }

        /// <summary>
        /// 操作员 5位长度
        /// </summary>
        public string CounterId { get; set; }

        /// <summary>
        /// 成功之后 解析后的数据实体
        /// </summary>
        public dynamic Model { get; set; }
        /// <summary>
        /// 旧版本将结果转化为具体的类对象,新版本转化为DynamicXml
        /// </summary>
        /// <typeparam name="T">转化的类型</typeparam>
        /// <returns></returns>
        public T ToModel<T>() where T : class, new()
        {
            if (!string.IsNullOrEmpty(this.RspContent))
            {
                if (this.RspContent.TrimStart().ToLower().StartsWith("<?xml"))
                {
                    //新版本接口处理
                    return Utils.LoadXML(this.RspContent.Replace("\n",""));
                }
                else
                {
                    //老版本接口处理  
                    return Utils.ToModelFromString<T>(this.FuncCode, this.RspContent);
                }
            }
            //throw new Exception("转换出错,返回结果数据为空！");
            return default(T);
        }
    }
}
