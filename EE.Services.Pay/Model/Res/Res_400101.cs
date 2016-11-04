using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_400101
    {
        /// <summary>
        /// 验证一致标志	C(1)	必输	0:一致 1:不一致
        /// </summary>
        public string Flag { get; set; }
        /// <summary>
        /// 不一致的原因描述	C(100)	必输	例如：|证件类型或证件号码不符|手机号码不符
        /// </summary>
        public string Desc { get; set; }      
    }
}
