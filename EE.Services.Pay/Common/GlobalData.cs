using EE.Services.Pay.Model;
namespace EE.Services.Pay.Common
{
    public delegate void OutPut(string input, string output);
    public delegate void UIItem();
    /// <summary>
    /// 全局的数据储存
    /// </summary>
    public class GlobalData
    {

        /// <summary>
        /// 配置信息
        /// </summary>
        private static PinganPayConfig PinganPayConfig = null;
        private static AnswerCode answerCode = null;
        /// <summary>
        /// 银企直连版本号
        /// </summary>
        public static string DirectErpBankVersion = "1.0";
        /// <summary>
        /// B2B现货版本号
        /// </summary>
        public static string B2BSpotVersion = "V1.5";
        /// <summary>
        /// 报文体连接字符串 旧版本
        /// </summary>
        public static string CombineStr = "&";
        /// <summary>
        /// 跨行快付字段分隔符
        /// </summary>
        public static string CrossCombineStr = "|::|";
        /// <summary>
        /// 银企直连 F001 分隔符
        /// </summary>
        public static string ErpBankCombineStr = "|$|";
        /// <summary>
        /// 构建方法的前缀
        /// </summary>
        public static string BuildMethodPrex = "BuildString_";
        /// <summary>
        ///xml的头部模板
        /// </summary>
        public static string XMLHeadTemplate = "<?xml version=\"1.0\" encoding=\"GBK\"?><Result>{0}</Result>";
        /// <summary>
        /// 程序集名称
        /// </summary>
        public static string assemblyName = "EE.Services.Pay";
        public static string buildMessageReqBody = "EE.Services.Pay.InertnetVer.BuildMessageReqBody";
        public static string buildMessageResBody = "EE.Services.Pay.InertnetVer.BuildMessageResBody";
        public static string serviceName = "PingAnPay";
        public static string displayName = "PingAnPay";
        public static string serviceDesc = "PingAnPay";
        /// <summary>
        /// 加载配置文件数据
        /// </summary>
        /// <param name="isRefresh">true:重新加载</param>
        /// <returns></returns>
        public static PinganPayConfig LoadPinganConfig(bool isRefresh = false)
        {
            if (PinganPayConfig == null || isRefresh)
            {
                PinganPayConfig = ConfigManage.GetPinganPayConfig();
            }
            return PinganPayConfig;
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="pinganPayConfig"></param>
        public static void SavePinganConfig(PinganPayConfig pinganPayConfig)
        {
            PinganPayConfig = pinganPayConfig;
            ConfigManage.SetPinganPayConfig(pinganPayConfig);
        }
        /// <summary>
        /// 加载响应码
        /// </summary>
        /// <param name="isRefresh">true:重新加载</param>
        /// <returns></returns>
        public static AnswerCode LoadAnswerCode(bool isRefresh = false)
        {
            if (answerCode == null || isRefresh)
            {
                answerCode = ConfigManage.GetAnswerList();
            }
            return answerCode;
        }
    }
}
