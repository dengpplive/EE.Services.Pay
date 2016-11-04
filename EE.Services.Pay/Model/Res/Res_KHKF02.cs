using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_KHKF02
    {
        /// <summary>
        /// 批次号	C(20)
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 批次处理状态码	C(2)	20:成功 30:失败 40:处理中
        /// </summary>
        public string BatchStt { get; set; }
        /// <summary>
        /// 批次处理描述	C(100)
        /// </summary>
        public string BatchInfo { get; set; }
        /// <summary>
        /// 文件名称	C(8)	【可选】	批次处理成功后，返回此字段
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 密码	C(100)	【可选】	批次处理成功后，返回此字段，用于FILE03下载文件
        /// </summary>
        public string RandomPwd { get; set; }
        /// <summary>
        /// 文件摘要	C(200)
        /// </summary>
        public string HashData { get; set; }
        /// <summary>
        /// 签名值	C(5000)
        /// </summary>
        public string SignData { get; set; }       
    }
}
