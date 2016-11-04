using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4034
    {
        /// <summary>
        /// 批量转账凭证号	C(20)	必输	同上送的批次号
        /// </summary>
        public string BThirdVoucher { get; set; }     
    }
}
