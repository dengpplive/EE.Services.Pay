using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 5.2.1 集团内账户预结息/结息 (4054)
    /// </summary>
    [Serializable]
    public partial class Req_4054
    {
        /// <summary>
        /// 必输	总账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 必输	子账号
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 必输	功能:1：预结息 2：结息
        /// </summary>
        public string CheckRate { get; set; }       
    }
}
