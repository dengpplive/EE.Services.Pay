using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_1315
    {
        /// <summary>
        /// 交易网流水号
        /// </summary>
        public string ThirdLogNo { get; set; }
        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserve { get; set; }      
    }
}
