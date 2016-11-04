using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_KHKF01
    {
        /// <summary>
        /// 批次号	C(20)
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 费项代码	C(10)	默认为xxxx
        /// </summary>
        public string BusiType { get; set; }
        /// <summary>
        /// 单位代码	C(32)
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 总笔数	N(10)
        /// </summary>
        public int TotalNum { get; set; }
        /// <summary>
        /// 总金额	N (17,2)
        /// </summary>
        public decimal TotalAmount { get; set; }        
    }
}
