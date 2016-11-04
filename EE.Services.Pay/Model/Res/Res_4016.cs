using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4016
    {
        /// <summary>
        /// 贷款笔数
        /// </summary>
        public string Count { get; set; }
        /// <summary>
        /// 本次传送数据结束标志	Char(1)	Y	Y:本次传送数据结束
        ///N:本次传送数据未结束
        ///用于分页查询结束标志
        /// </summary>
        public string EndFlag { get; set; }
        /// <summary>
        /// 当前最后传送序号
        /// </summary>
        public string LastSeqNo { get; set; }
        /// <summary>
        /// 多条记录 标签名：list
        /// </summary>
        public List<Result_4016> list { get { return _list; } set { _list = value; } }
        private List<Result_4016> _list = new List<Result_4016>();        
    }

    [Serializable]
    public partial class Result_4016
    {
        /// <summary>
        /// 借款编号
        /// </summary>
        public string LOAN_NO { get; set; }
        /// <summary>
        /// 保函日期
        /// </summary>
        public string LOAN_DATE { get; set; }
        /// <summary>
        /// 保函到期日
        /// </summary>
        public string LOAN_DUE_DATE { get; set; }
        /// <summary>
        /// 放款利率
        /// </summary>
        public string LOAN_RATE { get; set; }
        /// <summary>
        /// 扣款周期
        /// </summary>
        public string DEB_PED { get; set; }
        /// <summary>
        /// 周期单位 M：月  D：日
        /// </summary>
        public string DEB_UNIT { get; set; }
        /// <summary>
        /// 放款金额
        /// </summary>
        public string LOAN_AMT { get; set; }
        /// <summary>
        /// 放款余额
        /// </summary>
        public string LOAN_BAL { get; set; }
        /// <summary>
        /// 应收利息
        /// </summary>
        public string INT_RECV { get; set; }        
    }
}
