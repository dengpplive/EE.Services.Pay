using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1348
    {
        /// <summary>
        /// 返回状态 0：成功，1：失败， 2：查询中
        /// </summary>
        public string ReturnStatus { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string ReturnMsg { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }

    }
}
