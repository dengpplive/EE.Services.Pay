using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 附件信息
    /// </summary>
    [Serializable]
    public class Attachment
    {
        /// <summary>
        /// 附件的文件名 默认为TXT文本； .txt结尾为纯文本；.zip结尾为zip格式的压缩文件
        /// </summary>
        public string AttachFileName { get; set; }
        /// <summary>
        /// 附件文件的内容
        /// </summary>
        public string AttachContent { get; set; }

    }
}
