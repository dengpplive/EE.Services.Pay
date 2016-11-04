using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4019
    {
        /// <summary>
        /// 符合查询条件的笔数
        /// </summary>
        public string TotalCts { get; set; }
        /// <summary>
        /// 记录结束标志	C(1)	Y	Y:无剩余记录 N:有剩余记录
        /// </summary>
        public string IsEnd { get; set; }
        /// <summary>
        /// 当前页码	C(10)	Y	同上送
        /// </summary>
        public string PageNo { get; set; }
        /// <summary>
        /// 每页记录条数
        /// </summary>
        public string PageCts { get; set; }
        /// <summary>
        /// 多条记录 标签名list
        /// </summary>
        public List<Result_4019> list { get { return _list; } set { _list = value; } }
        private List<Result_4019> _list = new List<Result_4019>();       
    }

    [Serializable]
    public partial class Result_4019
    {
        /// <summary>
        /// 批次号 若属于批内则返回批次号
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 原始交易对应转账凭证号  客户上送单笔凭证号
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	N	用户输入则返回
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 交易日期时间	C(14)	Y	交易发送时间
        /// </summary>
        public string TransDate { get; set; }
        /// <summary>
        /// 本方帐号
        /// </summary>
        public string PayAccNo { get; set; }
        /// <summary>
        /// 对方帐号
        /// </summary>
        public string OppAccNo { get; set; }
        /// <summary>
        /// 收款方户名
        /// </summary>
        public string OppAccName { get; set; }
        /// <summary>
        /// 收款方开户行
        /// </summary>
        public string OppBankName { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 币种 交易币种
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 退票日期 
        /// </summary>
        public string RejectDate { get; set; }
        /// <summary>
        /// 退票描述
        /// </summary>
        public string RejectRemark { get; set; }
        /// <summary>
        /// 银行流水号	C(20)	Y	银行交易流水号
        /// </summary>
        public string FrontLogNo { get; set; }        
    }
}
