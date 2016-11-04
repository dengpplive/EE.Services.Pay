using System.Collections.Generic;

namespace EE.Services.Pay.Model
{
    /// <summary>
    /// 平安银行设置
    /// </summary>
    public class PinganPayConfig
    {
        private UpSetting _UpSetting = new UpSetting();
        private DownSetting _DownSetting = new DownSetting();
        private TranMessageNetHead_1_4 _TranMessageNetHead_1_4 = new TranMessageNetHead_1_4();
        private BankEnterpriseNetHead _BankEnterpriseNetHead = new BankEnterpriseNetHead();
        /// <summary>
        /// 上行设置 用于连接b2bIC客户端的设置
        /// </summary>
        public UpSetting UpSetting { get { return _UpSetting; } set { _UpSetting = value; } }

        /// <summary>
        /// 下行设置 用于监听b2bIC转发银行的数据
        /// </summary>
        public DownSetting DownSetting { get { return _DownSetting; } set { _DownSetting = value; } }
        /// <summary>
        /// 平安银行B2B现货接口文档V1.4 通讯报文头信息
        /// </summary>
        public TranMessageNetHead_1_4 TranMessageNetHead_1_4 { get { return _TranMessageNetHead_1_4; } set { _TranMessageNetHead_1_4 = value; } }
        /// <summary>
        /// 平安银行银企直连接口文档1.0 银行和企业直连的通讯报文头信息
        /// </summary>
        public BankEnterpriseNetHead BankEnterpriseNetHead { get { return _BankEnterpriseNetHead; } set { _BankEnterpriseNetHead = value; } }
        /// <summary>
        /// 是否开启日志
        /// </summary>
        public bool OpenLog { get; set; } = true;
        /// <summary>
        /// 循环查询调用接口时间间隔 毫秒
        /// </summary>
        public int SleepTime { get; set; } = 50;

    }
    /// <summary>
    /// 银行和企业直连的通讯报文 [平安银行银企直连接口文档1.0]
    /// </summary>
    public class BankEnterpriseNetHead
    {
        //private AccountSetting _AccountSetting = new AccountSetting();
        private NetMessageHead _NetMessageHead = new NetMessageHead();
        /// <summary>
        /// 通讯的设置
        /// </summary>
        public NetMessageHead NetMessageHead { get { return _NetMessageHead; } set { _NetMessageHead = value; } }
        /// <summary>
        /// 账号设置
        /// </summary>
        //public AccountSetting AccountSetting { get { return _AccountSetting; } set { _AccountSetting = value; } }
    }
    /// <summary>
    /// 银行企业中需配置使用的账号
    /// </summary>
    public class AccountSetting
    {
        private List<AccountInfo> _ChildAccount = new List<AccountInfo>();

        /// <summary>
        /// 主账号
        /// </summary>
        public string MainAccount { get; set; }
        /// <summary>
        /// 主账号名称
        /// </summary>
        public string MainAccountName { get; set; }
        /// <summary>
        /// 子账号信息
        /// </summary>
        public List<AccountInfo> ChildAccount { get { return _ChildAccount; } set { _ChildAccount = value; } }
    }

    public class AccountInfo
    {
        /// <summary>
        /// 子账号
        /// </summary>
        public string SubAccountNo { get; set; }
        /// <summary>
        /// 子账号名称
        /// </summary>
        public string SubAccName { get; set; }
    }


    /// <summary>
    /// [平安银行B2B现货接口文档V1.4]接口
    /// </summary>
    public class TranMessageNetHead_1_4
    {
        private BusinessMessageHead _BusinessMessageHead = new BusinessMessageHead();
        private NetMessageHead _NetMessageHead = new NetMessageHead();
        /// <summary>
        /// 业务报文头的固定信息
        /// </summary>
        public BusinessMessageHead BusinessMessageHead { get { return _BusinessMessageHead; } set { _BusinessMessageHead = value; } }
        /// <summary>
        /// 通讯报文头的固定信息
        /// </summary>
        public NetMessageHead NetMessageHead { get { return _NetMessageHead; } set { _NetMessageHead = value; } }
    }

    /// <summary>
    /// 上行通讯设置
    /// </summary>
    public class UpSetting
    {
        /// <summary>
        /// 请求的服务器IP地址
        /// </summary>
        public string IP
        {
            get;
            set;
        }
        /// <summary>
        /// 请求的端口号
        /// </summary>
        public int Port
        {
            get;
            set;
        }
        /// <summary>
        /// 发送请求的超时时间
        /// </summary>
        public int SendTimeout
        {
            get;
            set;
        }
        /// <summary>
        /// 接收请求的超时时间
        /// </summary>

        public int ReceiveTimeout
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置发送缓冲区的大小
        /// </summary>
        public int SendBufferSize
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置一个值，该值在发送或接收缓冲区未满时禁用延迟
        /// </summary>
        public bool NoDelay
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 下行通讯设置
    /// </summary>
    public class DownSetting
    {
        /// <summary>
        /// 监听的IP地址
        /// </summary>
        public string ListenIP
        {
            get;
            set;
        }
        /// <summary>
        /// 监听的端口号
        /// </summary>
        public int ListenPort
        {
            get;
            set;
        }
        /// <summary>
        /// 发送请求的超时时间
        /// </summary>
        public int SendTimeout
        {
            get;
            set;
        }
        /// <summary>
        /// 接收请求的超时时间
        /// </summary>

        public int ReceiveTimeout
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置发送缓冲区的大小
        /// </summary>
        public int SendBufferSize
        {
            get;
            set;
        }
        /// <summary>
        /// 获取或设置一个值，该值在发送或接收缓冲区未满时禁用延迟
        /// </summary>
        public bool NoDelay
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 业务报文头的固定信息
    /// </summary>
    public class BusinessMessageHead
    {
        /// <summary>
        /// 服务类型 01:请求02:应答
        /// </summary>
        //public string ServType { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public string RspCode { get; set; }
        /// <summary>
        /// 操作员代码
        /// </summary>
        public string CounterId { get; set; }
        /// <summary>
        /// 企业代码  交易网代码或外联客户代码 （企业上线的时候由银行分配）与业务报文头的交易网代码一致。
        /// </summary>
        public string Qydm { get; set; }

    }
    /// <summary>
    /// 通讯报文头的固定信息
    /// </summary>
    public class NetMessageHead
    {
        /// <summary>
        /// 报文类别 A001定长222报文头+报文体，客户端需要按此报文头上送。 A002 无报文头，客户端不上送以A001开头的报文，由B2BiC客户端增加A002开头的222位报文头
        /// </summary>
        public string MessageType { get; set; }
        /// <summary>
        /// 目标系统 01:银企直连 02:供应链金融 03:交易资金 04:电子商业汇票 05:政府前置 - 昆明国土局 06:供应链1号店 07:POSP信用卡系统 08:资产托管网银 10:交易资金 - P2P系统 11:实物黄金系统 12:政府前置 - 深圳交警 13:交易资金 - 见证系统 14:企业网上银行系统 15:贷贷平安网银 16:橙e物流管理系统 17:橙e App消息推送服务 18:橙e网门户 19: 岼山招标通 21：反交易欺诈侦测平台  22：直通银行子系统
        /// </summary>
        public string TargetSystem { get; set; }
        /// <summary>
        /// 报文编码 01：GBK缺省 02：UTF8  03：unicode  04：iso-8859-1
        /// </summary>
        public string MessageEncoding { get; set; }
        /// <summary>
        /// 通讯协议 01:tcpip 缺省 02：http  03：webservice 
        /// </summary>
        public string TeleProtocol { get; set; }
        /// <summary>
        /// 企业代码 交易网代码或外联客户代码  （企业上线的时候由银行分配）与业务报文头的交易网代码一致。
        /// </summary>
        public string Qydm { get; set; }
        /// <summary>
        /// 通信报文统一交易码 "000000"
        /// </summary>
        public string TradeCode { get; set; }
        /// <summary>
        /// 操作员代码 C5 (企业指定) 银行登记使用
        /// </summary>
        public string CounterId { get; set; }
        /// <summary>
        /// 服务类型 01-请求 02-应答
        /// </summary>
        //public string ServType { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public string RspCode { get; set; }
        /// <summary>
        /// 请求次数
        /// </summary>
        public string Times { get; set; }
        /// <summary>
        /// 附件数目
        /// </summary>
        public string AttachCount { get; set; }
    }
}
