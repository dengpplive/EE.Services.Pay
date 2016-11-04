using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.17 贷款户明细查询[4016]
    /// </summary>
    [Serializable]
    public partial class Req_4016
    {
        /// <summary>
        /// 贷款账户	Char(14)	Y	账号
        /// </summary>
        public string ACNO { get; set; }
        /// <summary>
        /// 贷款顺序号	Int(4)	N	顺序号,用于分页查询。默认为1
        /// 顺序号,用于分页查询。默认为1
        /// 第一次填写1, 第二次查询是填写上一次返回LastSeqNo 的值
        /// </summary>
        public string LNNO { get; set; } = "1";       
    }
}
