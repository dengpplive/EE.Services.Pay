using System.ComponentModel;
namespace EE.Services.Pay.Common
{
    /// <summary>
    /// 公共的枚举类型
    /// </summary>
    public class CommonEnums
    {
        /// <summary>
        /// 目标系统
        /// </summary>
        public enum TargetSystem : int
        {
            [Description("银企直连")]
            银企直连 = 01,
            [Description("供应链金融")]
            供应链金融 = 02,
            [Description("交易资金")]
            交易资金 = 03,
            [Description("电子商业汇票")]
            电子商业汇票 = 04,
            [Description("政府前置_昆明国土局")]
            政府前置_昆明国土局 = 05,
            [Description("供应链1号店")]
            供应链1号店 = 06,
            [Description("POSP信用卡系统")]
            POSP信用卡系统 = 07,
            [Description("资产托管网银")]
            资产托管网银 = 08,
            [Description("交易资金_P2P系统")]
            交易资金_P2P系统 = 09,
            [Description("实物黄金系统")]
            实物黄金系统 = 10,
            [Description("政府前置_深圳交警")]
            政府前置_深圳交警 = 12,
            [Description("交易资金_见证系统")]
            交易资金_见证系统 = 13,
            [Description("企业网上银行系统")]
            企业网上银行系统 = 14,
            [Description("贷贷平安网银")]
            贷贷平安网银 = 15,
            [Description("橙e物流管理系统")]
            橙e物流管理系统 = 16,
            [Description("橙eApp消息推送服务")]
            橙eApp消息推送服务 = 17,
            [Description("橙e网门户")]
            橙e网门户 = 18,
            [Description("岼山招标通")]
            岼山招标通 = 19,
            [Description("反交易欺诈侦测平台")]
            反交易欺诈侦测平台 = 20,
            [Description("直通银行子系统")]
            直通银行子系统 = 21
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        public  enum IDType : int
        {
            [Description("身份证")]
            身份证 = 1,
            [Description("军人军官证")]
            军人军官证 = 2,
            [Description("港澳台居民通行证")]
            港澳台居民通行证 = 3,
            [Description("中国护照")]
            中国护照 = 4,
            [Description("单位统一代码")]
            单位统一代码 = 5,
            [Description("未登记证件")]
            未登记证件 = 6,
            [Description("暂住证")]
            暂住证 = 7,
            [Description("武警警官证")]
            武警警官证 = 8,
            [Description("临时身份证")]
            临时身份证 = 9,
            [Description("联名户")]
            联名户 = 10,
            [Description("户口簿")]
            户口簿 = 11,
            [Description("中国居民其他证")]
            中国居民其他证 = 12,
            [Description("军人士兵证")]
            军人士兵证 = 13,
            [Description("军人文职干部证")]
            军人文职干部证 = 14,
            [Description("军人其他证件")]
            军人其他证件 = 15,
            [Description("武警士兵证")]
            武警士兵证 = 16,
            [Description("武警文职干部证")]
            武警文职干部证 = 17,
            [Description("武警其他证件")]
            武警其他证件 = 18,
            [Description("外国护照")]
            外国护照 = 19,
            [Description("外国公民其他证件")]
            外国公民其他证件 = 20,
            [Description("重复有效证件")]
            重复有效证件 = 21,
            [Description("解放军士兵证")]
            解放军士兵证 = 22,
            [Description("解放军文职干部证")]
            解放军文职干部证 = 23,
            [Description("解放军其它个人证件")]
            解放军其它个人证件 = 24,

            [Description("法人代码证")]
            法人代码证 = 51,
            [Description("组织机构代码证")]
            组织机构代码证 = 52,
            [Description("政府机构_公共机构批文")]
            政府机构_公共机构批文 = 53,
            [Description("外交部_外事办批文_使")]
            外交部_外事办批文_使 = 54,
            [Description("外交部_外事办批文_领")]
            外交部_外事办批文_领 = 55,
            [Description("外交部_外事办批文_办")]
            外交部_外事办批文_办 = 56,
            [Description("香港商业登记证")]
            香港商业登记证 = 60,
            [Description("事业单位登记证")]
            事业单位登记证 = 65,
            [Description("社会团体登记证")]
            社会团体登记证 = 66,
            [Description("商业登记证_离岸")]
            商业登记证_离岸 = 67,
            [Description("营业执照")]
            营业执照 = 68,
            [Description("对公临时证件")]
            对公临时证件 = 69,
            [Description("其他证明文件_公司")]
            其他证明文件_公司 = 70,
            [Description("公司户重复有效证件")]
            公司户重复有效证件 = 71,
            [Description("统一社会信用代码")]
            统一社会信用代码 = 73,
            [Description("金融机构")]
            金融机构 = 80
        }
        /// <summary>
        /// 文件传输错误码
        /// </summary>
        public enum FileErrorCode : int
        {
            [Description("文件大小不符")]
            E1,
            [Description("文件不存在")]
            E2,
            [Description("加解密失败")]
            E3,
            [Description("签名、验证失败")]
            E4,
            [Description("与银行传文失败")]
            E5,
            [Description("与企业Ftp传文失败")]
            E6,
            [Description("发送通知失败")]
            E7
        }
        /// <summary>
        /// 文件下载按顺序状态
        /// </summary>
        public enum FileDownloadOrder : int
        {
            /// <summary>
            ///接收文件下载请求 后续状态 D2、D3、D4、D5、F0
            /// </summary>
            [Description("接收文件下载请求")]
            D1,
            /// <summary>
            /// 后续状态 D3、D4、D5、F0
            /// </summary>
            [Description("从银行下载文件")]
            D2,
            /// <summary>
            /// 后续状态D4、D5、F0
            /// </summary>
            [Description("文件解密、验签")]
            D3,
            /// <summary>
            /// 后续状态D5、F0
            /// </summary>
            [Description("将文件传至企业FTP服务器")]
            D4,
            /// <summary>
            /// 后续状态 F0
            /// </summary>
            [Description("发送通知")]
            D5,
            /// <summary>
            /// 后续状态 E7
            /// </summary>
            [Description("文件传输成功")]
            F0,
            [Description("发送通知失败（文件上传、下载成功）")]
            E7
        }
        /// <summary>
        /// 文件状态码
        /// </summary>
        public enum FileStatus : int
        {
            /// <summary>
            /// 后续状态 U2、U3、U4、U5、F0
            /// </summary>
            [Description("接收文件上传请求")]
            U1,
            /// <summary>
            ///后续状态 U3、U4、U5、F0
            /// </summary>
            [Description("从企业FTP服务器取文件")]
            U2,
            /// <summary>
            ///后续状态 U4、U5、F0
            /// </summary>
            [Description("文件签名、加密")]
            U3,
            /// <summary>
            /// 后续状态 U5、F0
            /// </summary>
            [Description("文件上传银行")]
            U4,
            /// <summary>
            /// F0
            /// </summary>
            [Description("发送通知")]
            U5,
            /// <summary>
            /// 文件传输成功
            /// </summary>
            [Description("文件传输成功")]
            F0
        }

        /// <summary>
        /// 报文消息编码
        ///  //01：GBK缺省 02：UTF8  03：unicode  04：iso-8859-1
        /// </summary>
        public enum MessageEncoding : int
        {
            GBK = 01,
            UTF8 = 02,
            Unicode = 03,
            ISO_8859_1 = 04
        }

    }
}
