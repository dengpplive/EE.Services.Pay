using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1349
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件密码
        /// </summary>
        public string FilePSW { get; set; }
        /// <summary>
        /// 文件存在标志 0：无文件 1：有文件
        /// </summary>
        public string FileExist { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }
    }
}
