using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Req
{
    [Serializable]
    public partial class Req_1348
    {
        /// <summary>
        /// 鉴权指令号
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }

    }
}
