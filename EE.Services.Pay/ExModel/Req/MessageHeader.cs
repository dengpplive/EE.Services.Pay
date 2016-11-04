using EE.Services.Pay.Common;
using System;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 通讯的头部信息 222位
    /// </summary>
    [Serializable]
    public class MessageHeader
    {
        private string _MessageType = "A001";
        private string _TargetSystem = "01";
        private string _MessageEncoding = "01";
        private string _TeleProtocol = "01";
        private string _ServType = "01";
        private string _TrandateTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        private string _ConFlag = "0";
        private string _Times = "0";
        private string _Length = "0";
        private string _SignFlag = "0";
        private string _SignPacketType = "1";
        private string _SignDataLength = "0";
        private string _AttachCount = "0";
        private string _TradeCode = "0";
        private string _Qydm = "";
        private string _ThirdLogNo = "";
        private string _CounterId = "";
        private string _RspCode = "".PadRight(6, ' ');
        private string _RspMsg = "".PadRight(100, ' ');
        private string _SignAlgorithm = "".PadRight(12, ' ');

        /// <summary>
        /// 报文类别 C(4) A001定长222报文头+报文体，客户端需要按此报文头上送。 A002 无报文头，客户端不上送以A001开头的报文，由B2BiC客户端增加A002开头的222位报文头
        /// </summary>
        public string MessageType { get { return _MessageType; } set { _MessageType = value; } }
        /// <summary>
        /// 目标系统 C(2) 01:银企直连 02:供应链金融 03:交易资金 04:电子商业汇票 05:政府前置 - 昆明国土局 06:供应链1号店 07:POSP信用卡系统 08:资产托管网银 10:交易资金 - P2P系统 11:实物黄金系统 12:政府前置 - 深圳交警 13:交易资金 - 见证系统 14:企业网上银行系统 15:贷贷平安网银 16:橙e物流管理系统 17:橙e App消息推送服务 18:橙e网门户 19: 岼山招标通 21：反交易欺诈侦测平台  22：直通银行子系统
        /// </summary>
        public string TargetSystem { get { return _TargetSystem; } set { _TargetSystem = value; } }
        /// <summary>
        /// 报文编码 C(2)  01：GBK缺省 02：UTF8  03：unicode  04：iso-8859-1
        /// </summary>
        public string MessageEncoding { get { return _MessageEncoding; } set { _MessageEncoding = value; } }
        /// <summary>
        /// 通讯协议  01:tcpip 缺省 02：http  03：webservice 
        /// </summary>
        public string TeleProtocol { get { return _TeleProtocol; } set { _TeleProtocol = value; } }
        /// <summary>
        /// 交易网代码  C(20)  企业银企直连标准代码 银行提供给企业的20位唯一的标识代码
        /// </summary>
        public string Qydm { get { return _Qydm.PadRight(20, ' '); } set { _Qydm = value; } }
        /// <summary>
        /// 接收报文长度 C(10) XML报文体数据的字节长度或者业务报文头(122)+报文体的的字节长度（提示：不是字符串的长度）；不包括附件内容、签名内容的长度
        /// </summary>
        public string Length { get { return _Length.PadLeft(10, '0'); } set { _Length = value; } }
        /// <summary>
        /// 交易码 C(6)
        /// </summary>
        public string TradeCode { get { return _TradeCode.PadRight(6, ' '); } set { _TradeCode = value; } }
        /// <summary>
        /// 操做员代码 C(5)
        /// </summary>
        public string CounterId { get { return _CounterId.PadRight(5, ' '); } set { _CounterId = value; } }
        /// <summary>
        /// 服务类型 C(2) 服务类型 01:请求02:应答
        /// </summary>
        public string ServType { get { return _ServType; } set { _ServType = value; } }
        /// <summary>
        /// 交易日期时间 C(14)
        /// </summary>
        public string TrandateTime { get { return _TrandateTime.PadRight(14, ' '); } set { _TrandateTime = value; } }
        /// <summary>
        /// 请求方系统流水号 C(20)
        /// </summary>
        public string ThirdLogNo { get { return _ThirdLogNo.PadRight(20, ' '); } set { _ThirdLogNo = value; } }
        /// <summary>
        /// 返回码 C(6)
        /// </summary>
        public string RspCode { get { return _RspCode.PadRight(6, ' '); } set { _RspCode = value; } }
        /// <summary>
        /// 返回描述 C(100)
        /// </summary>
        public string RspMsg
        {
            get
            {
                return Utils.ToData(_RspMsg, 100);
            }
            set { _RspMsg = value; }
        }
        /// <summary>
        /// 后续包标志 C(1)
        /// </summary>
        public string ConFlag { get { return _ConFlag; } set { _ConFlag = value; } }
        /// <summary>
        /// 请求次数 C(3)
        /// </summary>
        public string Times { get { return _Times.PadLeft(3, '0'); } set { _Times = value; } }
        /// <summary>
        /// 签名标识 C(1)
        /// </summary>
        public string SignFlag { get { return _SignFlag; } set { _SignFlag = value; } }
        /// <summary>
        /// 签名数据包格式 C(1)
        /// </summary>
        public string SignPacketType { get { return _SignPacketType; } set { _SignPacketType = value; } }
        /// <summary>
        /// 签名算法 C(12)
        /// </summary>
        public string SignAlgorithm { get { return _SignAlgorithm.PadRight(12, ' '); } set { _SignAlgorithm = value; } }
        /// <summary>
        /// 签名数据长度 C(10)
        /// </summary>
        public string SignDataLength { get { return _SignDataLength.PadLeft(10, ' '); } set { _SignDataLength = value; } }
        /// <summary>
        /// 附件数目 C(1)
        /// </summary>
        public string AttachCount { get { return _AttachCount; } set { _AttachCount = value; } }
        /// <summary>
        /// 字符串显示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string bankEnterpriseMessageNetHead = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}",
              MessageType,//报文类别 C(4)
              TargetSystem,//目标系统 C(2)
              MessageEncoding,//报文编码 C(2) 01:GBK
              TeleProtocol,//通讯协议 01:tcpip 缺省 02：http C(2)
              Qydm,//交易网代码  C(20)
              Length,//接收报文长度 C(10) 
              TradeCode,//交易码 C(6)
              CounterId,//操做员代码 C(5)
              ServType,//服务类型 C(2)
              TrandateTime,//交易日期时间 C(14)
              ThirdLogNo,//请求方系统流水号 C(20)
              RspCode,//返回码 C(6)
              RspMsg,//返回描述 C(100)
              ConFlag,// 后续包标志 C(1)
              Times,//请求次数 C(3)
              SignFlag,//签名标识 C(1)
              SignPacketType,//签名数据包格式 C(1)
              SignAlgorithm,//签名算法 C(12)
              SignDataLength,//签名数据长度 C(10)
              AttachCount//附件数目 C(1)
              );
            return bankEnterpriseMessageNetHead;
        }
    }
}
