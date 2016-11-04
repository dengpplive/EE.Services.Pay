using EE.Services.Pay.Common;
using System;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 附件报文头部信息 277位
    /// </summary>
    [Serializable]
    public class AttachMessageHeader
    {
        private string _FileName = "";
        private string _SignPacketType = "0";
        private string _IsFileSign = "0";
        private string _FileMode = "0";
        private string _SignDataLength = "";
        private string _SignAlgorithm = "";
        private string _FileContentEncoding = "02";
        private string _AttachLength = "0";
        /// <summary>
        /// 文件名称C(240) 默认为TXT文本； .txt结尾为纯文本；.zip结尾为zip格式的压缩文件；    
        /// </summary>
        public string FileName { get { return Utils.ToData(_FileName, 240); } set { _FileName = value; } }
        /// <summary>
        /// 文件内容编码C(2) 01：GBK缺省 02：UTF8 03：unicode 04：iso-8859-1
        /// </summary>
        public string FileContentEncoding { get { return _FileContentEncoding; } set { _FileContentEncoding = value; } }
        /// <summary>
        /// 获取文件方式C(1) 0:流 缺省 1：文件系统 2：FTP服务器 3：http下载
        /// </summary>
        public string FileMode { get { return _FileMode; } set { _FileMode = value; } }
        /// <summary>
        /// 是否对文件签名C(1) 0：不签名 1：签名
        /// </summary>
        public string IsFileSign { get { return _IsFileSign; } set { _IsFileSign = value; } }
        /// <summary>
        /// 签名数据包格式C(1) 0-裸签  1-PKCS7
        /// </summary>
        public string SignPacketType { get { return _SignPacketType; } set { _SignPacketType = value; } }
        /// <summary>
        /// 哈希签名算法C(12) 12个空格 C(12)  RSA-SHA1
        /// </summary>
        public string SignAlgorithm { get { return Utils.ToData(_SignAlgorithm, 12);} set { _SignAlgorithm = value; } }
        /// <summary>
        /// 签名数据长度 填0，签名报文数据长度 C(10) 目前仅支填写0
        /// </summary>
        public string SignDataLength { get { return Utils.ToData(_SignDataLength, 10); } set { _SignDataLength = value; } }
        /// <summary>
        /// 附件文件的内容
        /// </summary>
        public string AttachLength { get { _AttachLength = Utils.ToByteUTF8(AttachContent).Length.ToString().PadLeft(10, '0'); return _AttachLength; } set { _AttachLength = value; } }
        /// <summary>
        /// 指“附件报文体”的长度C(10)。若获取文件方式0:流，则必输。默认为0000000000
        /// </summary>
        public string AttachContent { get; set; }
        /// <summary>
        /// 字符串显示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string bankEnterpriseAttachNetHead = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                         FileName,
                         FileContentEncoding,
                         FileMode,
                         IsFileSign,
                         SignPacketType,
                         SignAlgorithm,
                         SignDataLength,
                         AttachLength,
                         AttachContent
                         );
            return bankEnterpriseAttachNetHead;
        }
    }
}
