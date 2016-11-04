using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_KHKF05
    {     
        /// <summary>
        /// 查询结果	String(2)		20:成功，有文件 30:无对应文件
        /// </summary>
        public string Stt { get; set; }
        /// <summary>
        /// list 文件列表
        /// </summary>
        public List<Result_KHKF05> list { get; set; } = new List<Result_KHKF05>();       
    }
    [Serializable]
    public partial class Result_KHKF05
    {
        /// <summary>
        /// 文件名称	C(100)
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件类型	C(10)	KHKF01对账文件 KHKF02差错文件
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 批次号	C(20)
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 文件路径	C(100)
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 随机密码	C(200)
        /// </summary>
        public string RandomPwd { get; set; }
        /// <summary>
        /// 签名值	C(3000)
        /// </summary>
        public string SignData { get; set; }
        /// <summary>
        /// SHA-1摘要	C(3000)
        /// </summary>
        public string HashData { get; set; }       
    }
}
