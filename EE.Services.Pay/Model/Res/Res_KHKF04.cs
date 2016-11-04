using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_KHKF04
    {
        private string _CcyCode = "RMB";
        /// <summary>
        /// 订单号	C(20)
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 银行业务流水号	C(32)	银行受理成功，返回业务流水号
        /// </summary>
        public string BussFlowNo { get; set; }
        /// <summary>
        /// 银行交易流水号	C(32)	银行交易流水号
        /// </summary>
        public string TranFlowNo { get; set; }
        /// <summary>
        /// 交易状态	C(2)	20:成功，30:失败，其余处理中。
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 返回码	C(4)
        /// </summary>
        public string RetCode { get; set; }
        /// <summary>
        /// 返回消息	C(64)
        /// </summary>
        public string RetMsg { get; set; }
        /// <summary>
        /// 清算日期	C(8)
        /// </summary>
        public string SettleDate { get; set; }
        /// <summary>
        /// 收款卡号	C(20)
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 收款户名	C(32)
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 币种	C(3) 默认RMB
        /// </summary>
        public string CcyCode { get { return _CcyCode; } set { _CcyCode = value; } }
        /// <summary>
        /// 金额	Number(14,2)	元为单位，2位小数
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 手机号	C(11)
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 用途/备注	C(30)
        /// </summary>
        public string Remark { get; set; }        
    }
}
