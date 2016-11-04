using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1342
    {
        /// <summary>
        /// 交易状态 0:成功 1:失败
        /// </summary>
        public string TranStatus { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }

    }
}
