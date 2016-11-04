using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_FILE04
    {
        /// <summary>
        /// 流水号 必输 对应文件上传下载请求流水号
        /// </summary>
        public string TradeSn { get; set; }
        /// <summary>
        /// 文件名称 必输
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件路径 本地下载后的目录
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        ///上传下载类型 必输 1:上传；2:下载
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        ///随机密码 必输 文件完成加密后返回
        /// </summary>
        public string RandomPwd { get; set; }
        /// <summary>
        /// 签名值 非必输 文件完成签名后返回
        /// </summary>
        public string SignData { get; set; }
        /// <summary>
        /// SHA-1摘要  非必输 输入则验证文件的完整性
        /// </summary>
        public string HashData { get; set; }
    }
}
