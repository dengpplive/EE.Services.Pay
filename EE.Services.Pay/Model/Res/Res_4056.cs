using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4056
    {
        /// <summary>
        /// 上级账户
        /// </summary>
        public string supAccountNo { get; set; }
        /// <summary>
        /// 子账号
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 记录条数
        /// </summary>
        public string RecordNum { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public List<Result_4056> list { get; set; } = new List<Result_4056>();                
    }

    [Serializable]
    public partial class Result_4056
    {
        /// <summary>
        /// 交易日期
        /// </summary>
        public string TxDate { get; set; }
        /// <summary>
        /// 日志号
        /// </summary>
        public string HostSeqNo { get; set; }
        /// <summary>
        /// 借贷标识 D；C
        /// </summary>
        public string dFlag { get; set; }
        /// <summary>
        /// 结息标识  1、入账成功 2、入账不成功 3、暂停合约 4、非自动入账
        /// </summary>
        public string hoststatus { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 计息开始日
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 计息截至日
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 上存利率
        /// </summary>
        public string upRate { get; set; }
        /// <summary>
        /// 上存积数
        /// </summary>
        public string upScore { get; set; }
        /// <summary>
        /// 上存预计息金额
        /// </summary>
        public string upBookRateAmt { get; set; }
        /// <summary>
        /// 下拨利率
        /// </summary>
        public string downRate { get; set; }
        /// <summary>
        /// 下拨积数
        /// </summary>
        public string downScore { get; set; }
        /// <summary>
        /// 下拨预计息金额
        /// </summary>
        public string downBookRateAmt { get; set; }        
    }
}
