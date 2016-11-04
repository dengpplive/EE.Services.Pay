using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4027
    {
        /// <summary>
        /// 批量转账凭证号
        /// </summary>
        public string ThirdVoucher { get; set; }      
    }
}
