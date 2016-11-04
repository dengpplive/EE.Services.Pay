using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_FILE02
    {
        /// <summary>
        /// 状态描述	C(100)	必输
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 受理状态码	C(2)	必输	参考“文件状态码”
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 文件名称	C(100)	必输
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 随机密码	C(200)	非必输	文件完成加密后返回
        /// </summary>
        public string RandomPwd { get; set; }
        /// <summary>
        /// 签名值	C(3000)	非必输	文件完成签名后返回
        /// </summary>
        public string SignData { get; set; }
        /// <summary>
        /// SHA-1摘要	C(3000)	非必输	SHA-1摘要
        /// </summary>
        public string HashData { get; set; }
        /// <summary>
        /// 上传下载类型	C(1)	必输	1:上传；2:下载
        /// </summary>
        public string Action { get; set; }
    }
}
