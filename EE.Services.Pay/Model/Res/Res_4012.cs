using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4012
    {
        /// <summary>
        /// 账号	C(14)	必输
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 币种	C(3)	必输
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 钞汇标志	C(1)	非必输
        /// </summary>
        public string CcyType { get; set; }
        /// <summary>
        /// 账面余额	NUM(15,2)	必输	账面余额，不等于可用余额
        /// </summary>
        public string HisBalance { get; set; }
        /// <summary>
        /// 账单余额	NUM(15,2)	必输	账单余额=账面余额 +阶梯财富、智能存款
        /// </summary>
        public string HisBookBalance { get; set; }

    }
}
