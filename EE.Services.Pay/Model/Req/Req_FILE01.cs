using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class Req_FILE01
    {
        /// <summary>
        /// 上传文件的流水号 每次文件上传、下载请求唯一。可取报文头字段“请求方系统流水号”。
        /// </summary>
        public string TradeSn { get; set; }
        /// <summary>
        /// 文件名称 重复则覆盖服务器端文件
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 客户端待上传文件路径 企业未配置FTP时必须输入；【可选】
        /// 若企业端配置FTP，且为空则按按配置的上传目录下读取文件，若上送路径则优先按此路径读取文件。
        /// </summary>
        public string FilePath { get; set; }
    }
}
