using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4002
    {
        /// <summary>
        /// 账户	C(14)	必输
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 货币类型 
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 记录数	C(2)	必输
        /// </summary>
        public string RecordNum { get; set; }
        public List<Result_4002> list { get { return _list; } set { _list = value; } }
        private List<Result_4002> _list = new List<Result_4002>();      
    }
    [Serializable]
    public partial class Result_4002
    {
        /// <summary>
        /// 交易代码	C(4)
        /// </summary>
        public string TxCode { get; set; }
        /// <summary>
        /// 冲正标志	C(1)	必输	*—反交易；空格—正常交易
        /// </summary>
        public string Correct { get; set; }
        /// <summary>
        /// 主机流水号	C(7)	必输
        /// </summary>
        public string HostSeqNo { get; set; }
        /// <summary>
        /// 货币代码	C(3)	必输
        /// </summary>
        public string CurrencyNo { get; set; }
        /// <summary>
        /// 借贷标志	C(2)	必输	D—转出；C—转入
        /// </summary>
        public string TxType { get; set; }
        /// <summary>
        /// 交易金额	C(13)	必输
        /// </summary>
        public string TxAmount { get; set; }
        /// <summary>
        /// 摘要	C(21)
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 交易账户	C(15)
        /// </summary>
        public string TxAcctNo { get; set; }
        /// <summary>
        /// 网点号	C(10)
        /// </summary>
        public string UnitNo { get; set; }
        /// <summary>
        /// 交易柜员	C(6)
        /// </summary>
        public string Teller { get; set; }
        /// <summary>
        /// 前置机代码	C(6)
        /// </summary>
        public string FMCode { get; set; }
        /// <summary>
        /// 前置机流水号	C(14)
        /// </summary>
        public string FMJournalNo { get; set; }
        /// <summary>
        /// 业务类型	C(5)
        /// </summary>
        public string FMTranType { get; set; }
        /// <summary>
        /// 应用码	C(2)		新增
        /// </summary>
        public string JJCode { get; set; }      
    }
}
