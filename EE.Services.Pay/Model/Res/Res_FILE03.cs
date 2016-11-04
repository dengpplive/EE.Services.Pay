using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_FILE03
    {
        /// <summary>
        /// 状态描述	C(100)	必输
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 受理状态码	C(2)	必输	参考“文件状态码”
        /// </summary>
        public string Code { get; set; }

    }
}
