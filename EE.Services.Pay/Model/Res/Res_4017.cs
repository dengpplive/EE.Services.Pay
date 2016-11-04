using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4017
    {
        /// <summary>
        /// 银行代码
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 返回的记录数
        /// </summary>
        public string size { get; set; }
        /// <summary>
        /// 多条记录 标签名：list
        /// </summary>
        public List<Result_4017> list { get { return _list; } set { _list = value; } }
        private List<Result_4017> _list = new List<Result_4017>();        
    }

    [Serializable]
    public partial class Result_4017
    {
        /// <summary>
        /// 网点名称
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 网点联行号
        /// </summary>
        public string NodeCode { get; set; }        
    }
}
