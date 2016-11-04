using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_FILE03
    {
        /// <summary>
        /// 上传的文件流水号
        /// </summary>
        public string TradeSn { get; set; }
        /// <summary>
        /// 文件名称 不能以.enc结尾
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 客户端文件路径 本地文件保存路径；
        /// 若客户端配置FTP，可为空则按按“面向企业端配置-FTP服务器配置”配置的“企业FTP服务器默认目录或本地默认目录”保存
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 随机密码 客户收到银行端的通知的密码
        /// </summary>
        public string RandomPwd { get; set; }
        /// <summary>
        /// 签名值  输入则验签是否为银行发出的文件
        /// </summary>
        public string SignData { get; set; }
        /// <summary>
        /// SHA-1摘要 输入则验证文件的完整性
        /// </summary>
        public string HashData { get; set; }
    }
}
