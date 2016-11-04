using EE.Services.Pay.Model.Req;
using NLog;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Common
{
    /// <summary>
    /// 请求银行的接口
    /// </summary>
    public class BankInterface
    {
        /// <summary>
        /// 输出数据
        /// </summary>
        public static event OutPut Console;
        public BankInterface()
        {

        }

        #region 现货接口V1.4
        /// <summary>
        /// 生成企业请求银行的完整报文
        /// </summary>
        /// <param name="parmaKeyDict">输入参数</param>
        /// <param name="IsSpecialLine">是否为专线 默认为false</param>
        /// <returns></returns>
        public string GetTranMessageReq(ExHashTable parmaKeyDict, bool IsSpecialLine = false)
        {
            return GetTranMessage(parmaKeyDict, "01", IsSpecialLine);
        }
        /// <summary>
        /// 生成企业响应银行的完整报文
        /// </summary>
        /// <param name="parmaKeyDict">输入参数</param>
        /// <param name="IsSpecialLine">是否为专线 默认为false</param>
        /// <returns></returns>
        public string GetTranMessageRes(ExHashTable parmaKeyDict, bool IsSpecialLine = false)
        {
            return GetTranMessage(parmaKeyDict, "02", IsSpecialLine);
        }

        /// <summary>
        /// 解析接收银行的报文
        /// </summary>
        /// <param name="TranMessage">带解析的结果字符串</param>
        /// <returns></returns>
        public ExHashTable ParsingTranMessageString(string TranMessage)
        {
            ExHashTable retKeyDict = Utils.InitRetDict(TranMessage);
            if (string.IsNullOrEmpty(TranMessage)) return retKeyDict;
            byte[] byteRetMessage = Utils.ToByte(TranMessage);
            if (byteRetMessage.Length < 222) return retKeyDict;

            byte[] bNetHead = new byte[222];//通讯头
            byte[] bYeWuHead = new byte[122];//业务头


            byte[] bTranFunc = new byte[4];//业务交易码
            byte[] bTargetSystem = new byte[2];//接入系统
            byte[] bRspCode = new byte[6];//响应码
            byte[] bRspMsg = new byte[100];//响应描述
            byte[] bRspMsgLength = new byte[10];//数据包的长度
            byte[] bRspQydm = new byte[20];//企业标识代码
            byte[] bRspDatetime = new byte[14];//交易日期时间
            byte[] bRspThirdLogNo = new byte[20];//流水号  
            byte[] bCounterId = new byte[5];//操作员

            Array.Copy(byteRetMessage, 0, bNetHead, 0, bNetHead.Length);
            Array.Copy(byteRetMessage, 4, bTargetSystem, 0, bTargetSystem.Length);
            Array.Copy(byteRetMessage, 10, bRspQydm, 0, bRspQydm.Length);
            Array.Copy(byteRetMessage, 30, bRspMsgLength, 0, bRspMsgLength.Length);
            Array.Copy(byteRetMessage, 46, bCounterId, 0, bCounterId.Length);
            Array.Copy(byteRetMessage, 53, bRspDatetime, 0, bRspDatetime.Length);
            Array.Copy(byteRetMessage, 67, bRspThirdLogNo, 0, bRspThirdLogNo.Length);
            Array.Copy(byteRetMessage, 87, bRspCode, 0, bRspCode.Length);
            Array.Copy(byteRetMessage, 93, bRspMsg, 0, bRspMsg.Length);

            string strHead = Utils.ToGBK(bNetHead, 0, bNetHead.Length);
            string RspCode = Utils.ToGBK(bRspCode, 0, bRspCode.Length);
            string RspMsg = Utils.ToGBK(bRspMsg, 0, bRspMsg.Length);
            string Qydm = Utils.ToGBK(bRspQydm, 0, bRspQydm.Length).Trim();
            string TargetSystem = Utils.ToGBK(bTargetSystem, 0, bTargetSystem.Length);
            string RspDatetime = Utils.ToGBK(bRspDatetime, 0, bRspDatetime.Length);
            string RspThirdLogNo = Utils.ToGBK(bRspThirdLogNo, 0, bRspThirdLogNo.Length).Trim();
            string RspMsgLength = int.Parse(Utils.ToGBK(bRspMsgLength, 0, bRspMsgLength.Length)).ToString();
            string CounterId = Utils.ToGBK(bCounterId, 0, bCounterId.Length);
            string TranFunc = string.Empty;
            string BodyMsg = string.Empty;
            if (byteRetMessage.Length >= 226)
            {
                Array.Copy(byteRetMessage, 222, bTranFunc, 0, bTranFunc.Length);
                TranFunc = Utils.ToGBK(bTranFunc, 0, bTranFunc.Length);
            }
            if (byteRetMessage.Length - bNetHead.Length - bYeWuHead.Length > 0)
            {
                byte[] bNetBody = new byte[byteRetMessage.Length - bNetHead.Length - bYeWuHead.Length];//响应内容
                Array.Copy(byteRetMessage, bNetHead.Length + bYeWuHead.Length, bNetBody, 0, bNetBody.Length);
                BodyMsg = Utils.ToGBK(bNetBody, 0, bNetBody.Length);
            }

            retKeyDict.Set("TranFunc", TranFunc);//交易码
            retKeyDict.Set("TargetSystem", TargetSystem);//接入系统
            retKeyDict.Set("BodyMsg", BodyMsg);//响应内容        
            retKeyDict.Set("RspCode", RspCode);//响应码
            retKeyDict.Set("RspMsg", RspMsg);//响应描述
            retKeyDict.Set("TrandateTime", RspDatetime);//交易日期                      
            retKeyDict.Set("RspMsgLength", RspMsgLength);//响应数据长度
            retKeyDict.Set("Qydm", Qydm);//企业标识代码 
            retKeyDict.Set("CounterId", CounterId);//操作员
            retKeyDict.Set("ThirdLogNo", RspThirdLogNo);//请求流水号 
            retKeyDict.Set("Data", TranMessage);//原始数据
            return retKeyDict;
        }

        /// <summary>
        /// 发送报文，并接收银行返回 下行交易
        /// </summary>
        /// <param name="message">发送报文内容</param>        
        /// <param name="teleProtocol">请求的协议 01：tcp 02:http</param> 
        /// <returns></returns>     
        public string SendMessage(string message, string teleProtocol = "01")
        {
            string recvMessage = string.Empty;
            if (teleProtocol == "01")//tcp
            {
                ErpClient client = new ErpClient();
                recvMessage = client.SendUpMessage(message);
            }
            else if (teleProtocol == "02")//http
            {
                var pinganPayConfig = GlobalData.LoadPinganConfig();
                string url = string.Format("http://{0}:{1}/", pinganPayConfig.UpSetting.IP, pinganPayConfig.UpSetting.Port);
                HttpHelper http = new HttpHelper();
                recvMessage = http.Post(url, message, Encoding.GetEncoding("GBK"), pinganPayConfig.UpSetting.SendTimeout * 1000);
            }
#if DEBUG            
            if (Console != null) Console(message, recvMessage);
#endif
            return recvMessage;
        }
        #endregion

        #region 银行企业直连1.0
        /// <summary>
        /// 构建企业请求银行的完整报文
        /// </summary>
        /// <param name="parmaKeyDict">输入参数</param>
        /// <param name="IsSpecialLine">是否为专线 默认为false</param>
        /// <returns></returns>
        public List<string> GetBankEnterpriseMessageReq(ExHashTable parmaKeyDict, bool IsSpecialLine = false)
        {
            return GetBankEnterpriseMessage(parmaKeyDict, "01", IsSpecialLine);
        }
        /// <summary>
        ///  构建企业响应银行的完整报文
        /// </summary>
        /// <param name="parmaKeyDict">输入参数</param>
        /// <param name="IsSpecialLine">是否为专线 默认为false</param>
        /// <returns></returns>
        public List<string> GetBankEnterpriseMessageRes(ExHashTable parmaKeyDict, bool IsSpecialLine = false)
        {
            return GetBankEnterpriseMessage(parmaKeyDict, "02", IsSpecialLine);
        }
        /// <summary>
        /// 解析结果
        /// </summary>
        /// <returns></returns>
        public ExHashTable ParsingBankEnterpriseMessageString(string bankEnterpriseMessage)
        {
            ExHashTable retKeyDict = Utils.InitRetDict(bankEnterpriseMessage);
            if (string.IsNullOrEmpty(bankEnterpriseMessage)) return retKeyDict;
            byte[] messageByte = Utils.ToByte(bankEnterpriseMessage);
            if (messageByte.Length < 222) return retKeyDict;

            byte[] bNetHead = new byte[222];
            byte[] bNetBody = new byte[messageByte.Length - bNetHead.Length];
            byte[] bRspMsg = new byte[100];//描述
            byte[] bRspMsgLength = new byte[10];//数据包的长度
            byte[] bRspQydm = new byte[20];//企业标识代码
            byte[] bRspDatetime = new byte[14];//日期时间
            byte[] bRspThirdLogNo = new byte[20];//流水号
            byte[] bCounterId = new byte[5];//操作员
            byte[] bTargetSystem = new byte[2];//接入系统
            Array.Copy(messageByte, 0, bNetHead, 0, bNetHead.Length);
            Array.Copy(messageByte, 4, bTargetSystem, 0, bTargetSystem.Length);
            Array.Copy(messageByte, 11, bRspQydm, 0, bRspQydm.Length);
            Array.Copy(messageByte, 30, bRspMsgLength, 0, bRspMsgLength.Length);
            Array.Copy(messageByte, 46, bCounterId, 0, bCounterId.Length);
            Array.Copy(messageByte, 53, bRspDatetime, 0, bRspDatetime.Length);
            Array.Copy(messageByte, 67, bRspThirdLogNo, 0, bRspThirdLogNo.Length);
            Array.Copy(messageByte, 93, bRspMsg, 0, bRspMsg.Length);
            string strMessageBody = string.Empty;
            if (bNetBody.Length > 0)
            {
                Array.Copy(messageByte, bNetHead.Length, bNetBody, 0, bNetBody.Length);
                strMessageBody = Utils.ToGBK(bNetBody, 0, bNetBody.Length);
            }
            string strHead = Utils.ToGBK(bNetHead, 0, bNetHead.Length);
            string TranFunc = strHead.Length > 40 ? strHead.Substring(40, 6) : string.Empty;
            TranFunc = TranFunc.Trim();
            string bRspCode = strHead.Length > 87 ? strHead.Substring(87, 6) : string.Empty;
            string RspMsg = Utils.ToGBK(bRspMsg, 0, bRspMsg.Length);
            int _RspMsgLength = 0;
            string RspMsgLength = Utils.ToGBK(bRspMsgLength, 0, bRspMsgLength.Length);
            int.TryParse(RspMsgLength, out _RspMsgLength);
            string Qydm = Utils.ToGBK(bRspQydm, 0, bRspQydm.Length);
            string TargetSystem = Utils.ToGBK(bTargetSystem, 0, bTargetSystem.Length);
            string CounterId = Utils.ToGBK(bCounterId, 0, bCounterId.Length);
            string RspDatetime = Utils.ToGBK(bRspDatetime, 0, bRspDatetime.Length);
            string RspThirdLogNo = Utils.ToGBK(bRspThirdLogNo, 0, bRspThirdLogNo.Length).Trim();

            retKeyDict.Set("TranFunc", TranFunc);//业务交易码  
            retKeyDict.Set("TargetSystem", TargetSystem);//接入系统
            retKeyDict.Set("RspCode", bRspCode);//响应码
            retKeyDict.Set("RspMsg", RspMsg);//响应描述
            retKeyDict.Set("TrandateTime", RspDatetime);//交易日期时间
            retKeyDict.Set("BodyMsg", strMessageBody);//响应内容                   
            retKeyDict.Set("RspMsgLength", RspMsgLength);//响应数据长度
            retKeyDict.Set("Qydm", Qydm);//企业标识代码 
            retKeyDict.Set("CounterId", CounterId);//操作员
            retKeyDict.Set("ThirdLogNo", RspThirdLogNo);//请求流水号
            retKeyDict.Set("Data", bankEnterpriseMessage);//原始数据
            return retKeyDict;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 生成现货接口请求响应的完整报文
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <param name="hServType">服务类型 01:请求02:应答</param>
        /// <param name="IsSpecialLine">是否为专线 默认为false</param>
        /// <returns></returns>
        public string GetTranMessage(ExHashTable parmaKeyDict, string hServType, bool IsSpecialLine = false)
        {
            //业务报文体
            string tranMessageBody = GetTranMessageBody(parmaKeyDict, hServType);
            parmaKeyDict.Add("MessageBody", tranMessageBody);
            parmaKeyDict.Add("ServType", hServType);
            //业务报文头          
            string tranMessageHead = GetTranMessageHead(parmaKeyDict);
            //通讯报文头            
            string tranMessageNetHead = IsSpecialLine ? "" : GetTranMessageNetHead(parmaKeyDict);
            //完整请求报文
            string tranMessage = string.Format("{0}{1}{2}",
                tranMessageNetHead,
                tranMessageHead,
                tranMessageBody
                );
            return tranMessage;
        }
        /// <summary>
        /// 通讯报文头
        /// </summary>
        /// <param name="parmaKeyDict">参数</param>
        /// <returns></returns>
        private string GetTranMessageNetHead(ExHashTable parmaKeyDict)
        {
            var pinganPayConfig = GlobalData.LoadPinganConfig();
            var messageHeader = new MessageHeader();
            string servType = (string)parmaKeyDict.Get("ServType");
            string thirdLogNo = (string)parmaKeyDict.Get("ThirdLogNo");
            string messageBody = (string)parmaKeyDict.Get("MessageBody");
            //如果是请求去配置文件的,如果是响应解析中取数据
            string Qydm = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.Qydm;
            if (parmaKeyDict.Contains("Qydm") && servType == "02") Qydm = (string)parmaKeyDict.Get("Qydm");
            //操作员
            string CounterId = (string)parmaKeyDict.Get("CounterId");
            if (servType == "01" && string.IsNullOrEmpty(CounterId)) CounterId = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.CounterId;

            string RspCode = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.RspCode;
            if (parmaKeyDict.Contains("RspCode") && servType == "02") RspCode = (string)parmaKeyDict.Get("RspCode");

            string RspMsg = "";
            if (parmaKeyDict.Contains("RspMsg") && servType == "02") RspMsg = (string)parmaKeyDict.Get("RspMsg");

            //交易码
            string hTradeCode = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.TradeCode;
            byte[] byteMessageBody = Utils.ToByte(messageBody);
            string hLength = (byteMessageBody.Length + 122).ToString().PadLeft(10, '0');

            //ConFlag Times AttachCount
            string ConFlag = "0";
            if (parmaKeyDict.Contains("ConFlag")) ConFlag = (string)parmaKeyDict.Get("ConFlag");
            string Times = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.Times;
            if (parmaKeyDict.Contains("Times")) Times = (string)parmaKeyDict.Get("Times");
            string AttachCount = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.AttachCount;
            if (parmaKeyDict.Contains("AttachCount")) AttachCount = (string)parmaKeyDict.Get("AttachCount");

            messageHeader.MessageType = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.MessageType;
            messageHeader.TargetSystem = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.TargetSystem;
            messageHeader.Qydm = Qydm;
            messageHeader.CounterId = CounterId;
            messageHeader.Length = (byteMessageBody.Length + 122).ToString();
            messageHeader.ServType = servType;
            messageHeader.TradeCode = hTradeCode;
            messageHeader.ThirdLogNo = thirdLogNo;
            messageHeader.RspCode = RspCode;
            messageHeader.RspMsg = RspMsg;

            messageHeader.Times = Times;
            messageHeader.ConFlag = ConFlag;
            messageHeader.AttachCount = AttachCount;
            return messageHeader.ToString();

            #region ///
            /*
            DateTime dt = System.DateTime.Now;           
            string MessageType = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.MessageType; // "A001";//报文类别 C(4) A001定长222报文头+报文体，客户端需要按此报文头上送。 A002 无报文头，客户端不上送以A001开头的报文，由B2BiC客户端增加A002开头的222位报文头
            string TargetSystem = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.TargetSystem;//"03"; //目标系统 C(2) 01:银企直连 02:供应链金融 03:交易资金 04:电子商业汇票 05:政府前置 - 昆明国土局 06:供应链1号店 07:POSP信用卡系统 08:资产托管网银 10:交易资金 - P2P系统 11:实物黄金系统 12:政府前置 - 深圳交警 13:交易资金 - 见证系统 14:企业网上银行系统 15:贷贷平安网银 16:橙e物流管理系统 17:橙e App消息推送服务 18:橙e网门户 19: 岼山招标通 21：反交易欺诈侦测平台  22：直通银行子系统
            string MessageEncoding = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.MessageEncoding;//"01";//报文编码 C(2) 01：GBK缺省 02：UTF8  03：unicode  04：iso-8859-1
            string TeleProtocol = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.TeleProtocol;// "01";//通讯协议C(2)  01:tcpip 缺省 02：http  03：webservice 
            string hQydm = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.Qydm; //(string)parmaKeyDict.Get("Qydm");//交易网代码,外联客户代码 C(20) 测试使用:00102079900001231000
            hQydm = hQydm.PadRight(20, ' ');
            string hTradeCode = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.TradeCode;//"000000";//交易码 通信报文统一交易码:000000 C(6) 
            hTradeCode = hTradeCode.PadLeft(6, '0');
            string hCounterId = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.CounterId;//"PA001";//"00000";//;//操做员代码 可选 C(5) 建议送"00000"
            hCounterId = hCounterId.PadRight(5, ' ');
            string hTrandateTime = dt.ToString("yyyyMMddHHmmss");//交易日期时间 C(14)
            string hThirdLogNo = (string)parmaKeyDict.Get("ThirdLogNo");//请求方系统流水号 C(20)
            hThirdLogNo = hThirdLogNo.PadRight(20, ' ');
            string hRspCode = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.RspCode;//"999999";// "000000";//返回码 默认：000000 C(6) 请求时必须填写"000000"
            //格式为 “:交易成功”；其中冒号为英文格式半角。
            //100个空格 返回描述 C(100)
            string hRspMsg = "                                                                                                    ";
            string hConFlag = "0";//后续包标志 C(1) 0-结束包，1-还有后续包 目前仅支持0
            string hTimes = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.Times; //"000";//请求次数 C(3) 目前仅支持000
            hTimes = hTimes.PadLeft(3, '0');
            string hSignFlag = "0";//签名标识 填0，企业不管，由银行客户端完成 C(1) 目前仅支持填0
            string hSignPacketType = "1";// "1";//签名数据包格式 填1，企业不管，由银行客户端完成 C(1) 0-裸签 1- PKCS7 目前仅支持送1
            string hSignAlgorithm = "            ";//签名算法 12个空格 C(12)  RSA-SHA1
            string hSignDataLength = "0";//"0000000000";//签名数据长度 填0，签名报文数据长度 C(10) 目前仅支填写0
            hSignDataLength = hSignDataLength.PadLeft(10, ' ');
            string hAttachCount = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.AttachCount;//"0";//附件数目 默认为0 C(1) 最多9个
            string tranMessageNetHead = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}",
                MessageType,//报文类别 C(4)
                TargetSystem,//目标系统 C(2)
                MessageEncoding,//报文编码 C(2) 01:GBK
                TeleProtocol,//通讯协议 01:tcpip 缺省 02：http C(2)
                hQydm,//交易网代码  C(20)
                hLength,//接收报文长度 C(10) XML报文体数据的字节长度（提示：不是字符串的长度）；不包括附件内容、签名内容的长度
                hTradeCode,//交易码 C(6)
                hCounterId,//操做员代码 C(5)
                servType,//服务类型 C(2)
                hTrandateTime,//交易日期时间 C(14)
                hThirdLogNo,//请求方系统流水号 C(20)
                hRspCode,//返回码 C(6)
                hRspMsg,//返回描述 C(100)
                hConFlag,// 后续包标志 C(1)
                hTimes,//请求次数 C(3)
                hSignFlag,//签名标识 C(1)
                hSignPacketType,//签名数据包格式 C(1)
                hSignAlgorithm,//签名算法 C(12)
                hSignDataLength,//签名数据长度 C(10)
                hAttachCount//附件数目 C(1)
                );
            return tranMessageNetHead;
           */
            #endregion
        }

        /// <summary>
        /// 业务报文头
        /// </summary>
        /// <param name="parmaKeyDict">参数</param>
        /// <returns></returns>
        private string GetTranMessageHead(ExHashTable parmaKeyDict)
        {
            var pinganPayConfig = GlobalData.LoadPinganConfig();
            var businessHeader = new BusinessHeader();
            string messageBody = (string)parmaKeyDict.Get("MessageBody");
            string servType = (string)parmaKeyDict.Get("ServType");

            string Qydm = pinganPayConfig.TranMessageNetHead_1_4.BusinessMessageHead.Qydm;
            if (parmaKeyDict.Contains("Qydm") && servType == "02") Qydm = (string)parmaKeyDict.Get("Qydm");

            string CounterId = (string)parmaKeyDict.Get("CounterId");
            if (servType == "01" && string.IsNullOrEmpty(CounterId)) CounterId = pinganPayConfig.TranMessageNetHead_1_4.BusinessMessageHead.CounterId;

            //if (parmaKeyDict.Contains("CounterId") && servType == "02") CounterId = (string)parmaKeyDict.Get("CounterId");

            businessHeader.TranFunc = (string)parmaKeyDict.Get("TranFunc");
            businessHeader.ThirdLogNo = (string)parmaKeyDict.Get("ThirdLogNo");

            byte[] byteMessageBody = Utils.ToByte(messageBody);
            string hLength = byteMessageBody.Length.ToString().PadLeft(8, '0');

            businessHeader.Length = hLength;
            businessHeader.ServType = servType;
            businessHeader.CounterId = CounterId;
            businessHeader.Qydm = Qydm.Trim();
            if (servType == "02" && parmaKeyDict.Contains("RspCode")) businessHeader.RspCode = (string)parmaKeyDict.Get("RspCode");
            if (servType == "02" && parmaKeyDict.Contains("RspMsg")) businessHeader.RspMsg = (string)parmaKeyDict.Get("RspMsg");
            return businessHeader.ToString();

            #region ///
            /*
             DateTime dt = System.DateTime.Now;            
             string hMacCode = "0";//"                ";//16字符
             hMacCode = hMacCode.PadRight(16, ' ');
             string hTrandateTime = dt.ToString("yyyyMMddHHmmss");//设置日期格式
             string hRspCode = pinganPayConfig.TranMessageNetHead_1_4.BusinessMessageHead.RspCode;// "999999";//交易发起方初始填入”999999”
             string hRspMsg = "";// "                                          ";
             hRspMsg = hRspMsg.PadRight(42, ' ');
             string hConFlag = "0";
             string hCounterId = pinganPayConfig.TranMessageNetHead_1_4.BusinessMessageHead.CounterId;//"PA001"; ;// "00000";////操作员号
             hCounterId = hCounterId.PadLeft(5,' ');
             string hTranFunc = (string)parmaKeyDict.Get("TranFunc");
             string hThirdLogNo = (string)parmaKeyDict.Get("ThirdLogNo");
             hThirdLogNo = hThirdLogNo.PadRight(20, ' ');
             string hQydm = pinganPayConfig.TranMessageNetHead_1_4.BusinessMessageHead.Qydm; //(string)parmaKeyDict.Get("Qydm");

             string tranMessageHead = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
                   hTranFunc,    //交易类型 C(4)
                   servType,    //服务类型 C(2)
                   hMacCode,     //MAC码 C(16)
                   hTrandateTime,//交易日期和时间 C(14)
                   hRspCode,    //应答码 交易发起方初始填入”999999” C(6)
                   hRspMsg,     //应答码描述 C(42)
                   hConFlag,    //后续包标志 0结束包,1还有后续包 C(1)
                   hLength,     //报文体长度 C(8)
                   hCounterId,  //操作员号 C(5)
                   hThirdLogNo, //请求方系统流水号 C(20)
                   hQydm        //交易网代码 C(4)
                   );
             return tranMessageHead;
            */
            #endregion
        }



        /// <summary>
        /// 银企业直连完整报文
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <param name="hServType">服务类型 01:请求02:应答</param>
        /// <param name="IsSpecialLine">是否为专线 默认为false</param>
        /// <returns></returns>
        private List<string> GetBankEnterpriseMessage(ExHashTable parmaKeyDict, string hServType, bool IsSpecialLine = false)
        {
            //业务报文体
            string bankEnterpriseMessageBody = GetTranMessageBody(parmaKeyDict, hServType);
            parmaKeyDict.Add("MessageBody", bankEnterpriseMessageBody);
            parmaKeyDict.Add("ServType", hServType);
            //通讯报文头           
            string bankEnterpriseNetHead = IsSpecialLine ? "" : GetBankEnterpriseNetHead(parmaKeyDict);
            //附件报文头
            string bankEnterpriseAttachNetHead = GetBankEnterpriseAttachNetHead(parmaKeyDict);
            //完整请求报文           
            var list = new List<string>();
            list.Add(bankEnterpriseNetHead);
            list.Add(bankEnterpriseMessageBody);
            list.Add(bankEnterpriseAttachNetHead);
            return list;
        }

        /// <summary>
        /// 银行企业直连 通讯报文
        /// </summary>
        /// <param name="parmaKeyDict">参数</param>
        /// <returns></returns>
        private string GetBankEnterpriseNetHead(ExHashTable parmaKeyDict)
        {
            var pinganPayConfig = GlobalData.LoadPinganConfig();
            var messageHeader = new MessageHeader();
            string servType = (string)parmaKeyDict.Get("ServType");
            string hTradeCode = (string)parmaKeyDict.Get("TranFunc");
            string thirdLogNo = (string)parmaKeyDict.Get("ThirdLogNo");
            string messageBody = (string)parmaKeyDict.Get("MessageBody");
            byte[] byteMessageBody = Utils.ToByte(messageBody);//编码 重要
            string hLength = byteMessageBody.Length.ToString().PadLeft(10, '0');

            string Qydm = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.Qydm;
            if (parmaKeyDict.Contains("Qydm") && servType == "02") Qydm = (string)parmaKeyDict.Get("Qydm");
            //操作员
            string CounterId = (string)parmaKeyDict.Get("CounterId");
            if (servType == "01" && parmaKeyDict.Contains("CounterId")) CounterId = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.CounterId;

            messageHeader.MessageType = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.MessageType;
            messageHeader.ServType = servType;
            messageHeader.Length = byteMessageBody.Length.ToString();
            messageHeader.TradeCode = hTradeCode;
            messageHeader.TargetSystem = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.TargetSystem;
            messageHeader.Qydm = Qydm;
            messageHeader.CounterId = CounterId;
            messageHeader.ThirdLogNo = thirdLogNo;
            messageHeader.Times = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.Times;
            if (servType == "02" && parmaKeyDict.Contains("RspCode")) messageHeader.RspCode = (string)parmaKeyDict.Get("RspCode");
            if (servType == "02" && parmaKeyDict.Contains("RspMsg")) messageHeader.RspMsg = (string)parmaKeyDict.Get("RspMsg");
            return messageHeader.ToString();
            #region 11
            /*
            DateTime dt = System.DateTime.Now;           
            string MessageType = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.MessageType; // "A001";//报文类别 C(4) A001定长222报文头+报文体，客户端需要按此报文头上送。 A002 无报文头，客户端不上送以A001开头的报文，由B2BiC客户端增加A002开头的222位报文头
            string TargetSystem = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.TargetSystem;// "01"; //目标系统 C(2) 01:银企直连 02:供应链金融 03:交易资金 04:电子商业汇票 05:政府前置 - 昆明国土局 06:供应链1号店 07:POSP信用卡系统 08:资产托管网银 10:交易资金 - P2P系统 11:实物黄金系统 12:政府前置 - 深圳交警 13:交易资金 - 见证系统 14:企业网上银行系统 15:贷贷平安网银 16:橙e物流管理系统 17:橙e App消息推送服务 18:橙e网门户 19: 岼山招标通 21：反交易欺诈侦测平台  22：直通银行子系统
            string MessageEncoding = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.MessageEncoding;//"01";//报文编码 C(2) 01：GBK缺省 02：UTF8  03：unicode  04：iso-8859-1
            string TeleProtocol = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.TeleProtocol;// "01";//通讯协议C(2)  01:tcpip 缺省 02：http  03：webservice 
            string hQydm = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.Qydm;// "00101079900009999000";//(string)parmaKeyDict.Get("Qydm");//企业银企直连标准代码 银行提供给企业的20位唯一的标识代码 C(20) 测试使用:00102079900001231000
            hQydm = hQydm.PadRight(20, ' ');
            //string hTradeCode = (string)parmaKeyDict.Get("TranFunc");// "4001";// "000000";//交易码 通信报文统一交易码:000000 C(6)   
            hTradeCode = hTradeCode.PadRight(6, ' ');
            string hCounterId = pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.CounterId;// "00000"; //"     ";;//操做员代码 可选 C(5) 建议送"00000"
            hCounterId = hCounterId.PadRight(5, ' ');
            //string hServType = this.PinganPayConfig.BankEnterpriseNetHead.NetMessageHead.ServType;// "01";//服务类型 可选 01-请求 02-应答 C(2)
            string hTrandateTime = dt.ToString("yyyyMMddHHmmss");//交易日期时间 C(14)
            string hThirdLogNo = (string)parmaKeyDict.Get("ThirdLogNo");//请求方系统流水号 C(20)
            hThirdLogNo = hThirdLogNo.PadRight(20, ' ');
            string hRspCode = "      ";//"000000";//返回码 默认：000000 C(6) 请求时必须填写"000000"
            //格式为 “:交易成功”；其中冒号为英文格式半角。
            //100个空格 返回描述 C(100)
            string hRspMsg = "                                                                                                    ";
            string hConFlag = "0";//后续包标志 C(1) 0-结束包，1-还有后续包 目前仅支持0
            //请求次数 C(3) 目前仅支持000
            string hTimes = pinganPayConfig.TranMessageNetHead_1_4.NetMessageHead.Times; //"000";
            hTimes = hTimes.PadLeft(3, '0');
            string hSignFlag = "0";//签名标识 填0，企业不管，由银行客户端完成 C(1) 目前仅支持填0
            string hSignPacketType = " ";//"1";// "1";//签名数据包格式 填1，企业不管，由银行客户端完成 C(1) 0-裸签 1- PKCS7 目前仅支持送1
            string hSignAlgorithm = "            ";//签名算法 12个空格 C(12)  RSA-SHA1
            string hSignDataLength = "          ";// "0000000000";//签名数据长度 填0，签名报文数据长度 C(10) 目前仅支填写0
            string hAttachCount = "0";//附件数目 默认为0 C(1) 最多9个
            string bankEnterpriseMessageNetHead = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}{17}{18}{19}",
                MessageType,//报文类别 C(4)
                TargetSystem,//目标系统 C(2)
                MessageEncoding,//报文编码 C(2) 01:GBK
                TeleProtocol,//通讯协议 01:tcpip 缺省 02：http C(2)
                hQydm,//交易网代码  C(20)
                hLength,//接收报文长度 C(10) XML报文体数据的字节长度（提示：不是字符串的长度）；不包括附件内容、签名内容的长度
                hTradeCode,//交易码 C(6)
                hCounterId,//操做员代码 C(5)
                servType,//服务类型 C(2)
                hTrandateTime,//交易日期时间 C(14)
                hThirdLogNo,//请求方系统流水号 C(20)
                hRspCode,//返回码 C(6)
                hRspMsg,//返回描述 C(100)
                hConFlag,// 后续包标志 C(1)
                hTimes,//请求次数 C(3)
                hSignFlag,//签名标识 C(1)
                hSignPacketType,//签名数据包格式 C(1)
                hSignAlgorithm,//签名算法 C(12)
                hSignDataLength,//签名数据长度 C(10)
                hAttachCount//附件数目 C(1)
                );
            return bankEnterpriseMessageNetHead;
           */
            #endregion
        }
        /// <summary>
        /// 银行企业直连 通讯报文中的附件文件报文 报文头长度277+附件内容
        /// </summary>
        /// <returns></returns>
        private string GetBankEnterpriseAttachNetHead(ExHashTable parmaKeyDict)
        {
            string bankEnterpriseAttachNetHead = string.Empty;
            if (parmaKeyDict.Contains("Attach") && parmaKeyDict.Get("Attach") != null)
            {
                //文件名和内容都不能为空
                var attachment = parmaKeyDict.Get("Attach") as Attachment;
                if (!string.IsNullOrEmpty(attachment.AttachFileName)
                    && !string.IsNullOrEmpty(attachment.AttachContent))
                {
                    var attachMessageHeader = new AttachMessageHeader();
                    attachMessageHeader.FileName = attachment.AttachFileName;
                    attachMessageHeader.AttachContent = attachment.AttachContent;
                    bankEnterpriseAttachNetHead = attachMessageHeader.ToString();

                    #region 11111
                    /*
                    //文件名称C(240) 默认为TXT文本； .txt结尾为纯文本；.zip结尾为zip格式的压缩文件；            
                    string fileName = attachment.AttachFileName;
                    fileName = fileName.PadRight(240, ' ');
                    //文件内容编码C(2) 01：GBK缺省 02：UTF8 03：unicode 04：iso-8859-1
                    string fileContentEncoding = "02";
                    //获取文件方式C(1) 0:流 缺省 1：文件系统 2：FTP服务器 3：http下载
                    string fileMode = "0";
                    //是否对文件签名C(1) 0：不签名 1：签名
                    string isFileSign = "0";
                    //签名数据包格式C(1) 0-裸签  1-PKCS7
                    string hSignPacketType = "0";
                    //哈希签名算法C(12) 12个空格 C(12)  RSA-SHA1
                    string hSignAlgorithm = "            ";
                    // "0000000000";//签名数据长度 填0，签名报文数据长度 C(10) 目前仅支填写0
                    string hSignDataLength = "          ";
                    //附件文件的内容
                    string attachContent = attachment.AttachContent;
                    //指“附件报文体”的长度C(10)。若获取文件方式0:流，则必输。默认为0000000000
                    string attachLength = Utils.ToByteUTF8(attachContent).Length.ToString().PadLeft(10, '0');
                    bankEnterpriseAttachNetHead = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                        fileName,
                        fileContentEncoding,
                        fileMode,
                        isFileSign,
                        hSignPacketType,
                        hSignAlgorithm,
                        hSignDataLength,
                        attachLength,
                        attachContent
                        );
                        */
                    #endregion
                }
            }
            return bankEnterpriseAttachNetHead;
        }



        /// <summary>
        /// 根据交易码调用不同的交易报文生成方法  通讯报文体
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        private string GetTranMessageBody(ExHashTable parmaKeyDict, string hServType = "01")
        {
            string hTranFunc = (string)parmaKeyDict.Get("TranFunc");
            string tranMessageBody = GetTranMessageBody(hTranFunc, parmaKeyDict, hServType);
            return tranMessageBody;
        }
        /// <summary>
        /// 动态调用方法 构建各个接口的请求报文体
        /// </summary>
        /// <param name="tranFunc"></param>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        private string GetTranMessageBody(string tranFunc, ExHashTable parmaKeyDict, string hServType = "01")
        {
            string result = string.Empty;
            var asm = Assembly.Load(GlobalData.assemblyName);
            //默认请求的
            string strType = hServType == "02" ? GlobalData.buildMessageResBody : GlobalData.buildMessageReqBody;
            var type = asm.GetType(strType);
            var instance = asm.CreateInstance(strType);
            var method = type.GetMethod(GlobalData.BuildMethodPrex + tranFunc);
            if (method != null)
            {
                result = method.Invoke(instance, new object[] { parmaKeyDict }).ToString();
            }
            else
            {
                LogManager.GetCurrentClassLogger().Error("类型:" + hServType + " " + GlobalData.BuildMethodPrex + tranFunc + "方法不存在");
            }
            return result;
        }
        #endregion

    }
}
