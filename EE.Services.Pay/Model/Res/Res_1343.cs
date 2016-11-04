using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1343
    {
        /// <summary>
        /// 交易网会员代码 必填
        /// </summary>
        public string ThirdCustId { get; set; }
        /// <summary>
        /// 指令流水号 必填
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }     
    }
}
