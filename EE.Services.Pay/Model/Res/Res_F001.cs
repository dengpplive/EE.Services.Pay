﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_F001
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 随机密码
        /// </summary>
        public string RandomPwd { get; set; }
        /// <summary>
        /// 签名值
        /// </summary>
        public string SignData { get; set; }
        /// <summary>
        /// SHA-1摘要
        /// </summary>
        public string HashData { get; set; }        
    }
}
