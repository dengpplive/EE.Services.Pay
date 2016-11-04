using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4054
    {
        /// <summary>
        /// 必输	总账号
        /// </summary>
        public string headAccountNo { get; set; }
        /// <summary>
        /// 总账户户名
        /// </summary>
        public string headAccountName { get; set; }
        /// <summary>
        /// 上级账户
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 上级账号户名
        /// </summary>
        public string supAccountName { get; set; }
        /// <summary>
        /// 子账号
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 子账号户名
        /// </summary>
        public string subAccountName { get; set; }
        /// <summary>
        /// 功能:
        ///   1-预结息
        ///   2-结息
        /// </summary>
        public string CheckRate { get; set; }
        /// <summary>
        /// 上存积数
        /// </summary>
        public string upScore { get; set; }
        /// <summary>
        /// 下拆积数
        /// </summary>
        public string downScore { get; set; }
        /// <summary>
        /// 上存利率
        /// </summary>
        public string upRate { get; set; }
        /// <summary>
        /// 下拆利率
        /// </summary>
        public string downRate { get; set; }
        /// <summary>
        /// 上存预计息金额
        /// </summary>
        public string upBookRateAmt { get; set; }
        /// <summary>
        /// 下拨预计息金额
        /// </summary>
        public string downBookRateAmt { get; set; }
        /// <summary>
        /// 上存未计息积数
        /// </summary>
        public string upScoreBalance { get; set; }
        /// <summary>
        /// 下拨未计息积数
        /// </summary>
        public string downScoreBalance { get; set; }
        /// <summary>
        /// 上存已结息金额
        /// </summary>
        public string upRateAmt { get; set; }
        /// <summary>
        /// 下拆已结息金额
        /// </summary>
        public string downRateAmt { get; set; }
        /// <summary>
        /// 上次结息日
        /// </summary>
        public string lastRateDate { get; set; }
        /// <summary>
        /// 结息截止日
        /// </summary>
        public string endDate { get; set; }
        /// <summary>
        /// 付息账号
        /// </summary>
        public string payRateAcc { get; set; }
        /// <summary>
        /// 付息账号户名
        /// </summary>
        public string payRateAccName { get; set; }
        /// <summary>
        /// 收息账号
        /// </summary>
        public string recvRateAcc { get; set; }
        /// <summary>
        /// 收息账号户名
        /// </summary>
        public string recvRateAccName { get; set; }
        /// <summary>
        /// 预计息金额
        /// </summary>
        public string bookRateAmt { get; set; }
        /// <summary>
        /// 结息金额
        /// </summary>
        public string RateAmt { get; set; }        
    }
}
