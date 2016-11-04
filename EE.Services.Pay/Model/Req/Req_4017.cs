using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 3.18 银行联行号查询[4017]
    /// </summary>
    [Serializable]
    public partial class Req_4017
    {
        /// <summary>
        /// 银行代码 必填
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 银行名称 可选
        /// </summary>
        public string BankName { get; set; } = "";
        /// <summary>
        /// 网点名称关键字 必填
        /// </summary>
        public string KeyWord { get; set; }        
    }
}
