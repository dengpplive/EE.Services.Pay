using EE.Services.Pay.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EE.Services.Pay.Model.DiskFile
{
    /// <summary>
    /// 对账文件
    /// </summary>
   
    public partial class CheckBillDiskFile
    {
        /// <summary>
        /// 汇总行字段
        /// </summary>
        public SummaryFiled Summary { get; set; } = new SummaryFiled();
        /// <summary>
        /// 明细行字段
        /// </summary>
        public List<DetailFiled> DetailList { get; set; } = new List<DetailFiled>();
        /// <summary>
        /// 生成对应的字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {          
            return Utils.DiskFileToString<CheckBillDiskFile>(this);
        }
        /// <summary>
        /// 保存到txt的文件
        /// </summary>
        /// <param name="path">文件路径 相对主目录</param>
        /// <returns></returns>
        public bool Save(string path)
        {
            return FileHelper.SaveFile(path, this.ToString(), true, Encoding.GetEncoding("GBK"));
        }
        public partial class SummaryFiled
        {

        }
        public partial class DetailFiled
        {

        }
    }
}
