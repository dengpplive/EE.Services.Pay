using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_KHKF05
    {
        /// <summary>
        /// 日期	C(8)	格式YYYYMMDD
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 账号	C(32) 【可选】	签约付款帐号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 文件类型	String(10)	【可选】	KHKF01对账文件  KHKF02差错文件
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 批次号	String(20)	【可选】对账文件按天生成（默认），则无法按批次号查询。对账文件按批次号生成，0000查询单笔交易对账文件
        /// </summary>
        public string BatchNo { get; set; }
       
    }
}
