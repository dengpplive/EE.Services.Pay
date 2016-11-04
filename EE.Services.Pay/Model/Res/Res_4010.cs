using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4010
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string InvName { get; set; }
        /// <summary>
        /// 证券资金台账号
        /// </summary>
        public string CapAcct { get; set; }
        /// <summary>
        /// 人民币可用余额
        /// </summary>
        public string RMBCurBal { get; set; }
        /// <summary>
        /// 人民币可提现余额
        /// </summary>
        public string RMBAvailBal { get; set; }
        /// <summary>
        /// 人民币管理账户余额
        /// </summary>
        public string RMBTruBal { get; set; }
        /// <summary>
        /// 美元可用余额
        /// </summary>
        public string USDCurBal { get; set; }
        /// <summary>
        /// 美元可取余额
        /// </summary>
        public string USDAvailBal { get; set; }
        /// <summary>
        /// 美元管理账户余额
        /// </summary>
        public string USDTruBal { get; set; }
        /// <summary>
        /// 港币可用余额
        /// </summary>
        public string HKDCurBal { get; set; }
        /// <summary>
        /// 港币可取余额
        /// </summary>
        public string HKDAvailBal { get; set; }
        /// <summary>
        /// 港币管理账户余额
        /// </summary>
        public string HKDTruBal { get; set; }       
    }
}
