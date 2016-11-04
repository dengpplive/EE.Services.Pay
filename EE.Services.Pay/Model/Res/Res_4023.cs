using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4023
    {
        /// <summary>
        /// 是否翻页 Y翻页N不翻页
        /// </summary>
        public string PAGE { get; set; } = "N";
        /// <summary>
        /// 有效子账号数
        /// </summary>
        public string ALLCOUNT { get; set; }
        /// <summary>
        /// 子账户循环体
        /// </summary>
        public List<ResultChildAccount_4023> list { get; set; } = new List<ResultChildAccount_4023>();
    }

    [Serializable]
    public partial class ResultChildAccount_4023
    {
        /// <summary>
        /// 子账户
        /// </summary>
        public string SUBAC { get; set; }
        /// <summary>
        /// 子账户户名
        /// </summary>
        public string SUBNAME { get; set; }
        /// <summary>
        /// 开户网点
        /// </summary>
        public string CORSCONBR { get; set; }
        /// <summary>
        /// 归集余额
        /// </summary>
        public string UPBALANCE { get; set; }
        /// <summary>
        /// 下拨余额
        /// </summary>
        public string DOWNBALANCE { get; set; }
        /// <summary>
        /// 应付利息试算（下级）
        /// </summary>
        public string payRateComputeDown { get; set; }
        /// <summary>
        /// 账户余额 子账户自身的可用余额
        /// </summary>
        public string CURRBAL { get; set; }
        /// <summary>
        /// 日间透支可用余额
        /// </summary>
        public string dayOverBalance { get; set; }
        /// <summary>
        /// 日间透支额度
        /// </summary>
        public string dayOverLimit { get; set; }
        /// <summary>
        /// 上存积数
        /// </summary>
        public string upScore { get; set; }
        /// <summary>
        /// 下存积数
        /// </summary>
        public string downScore { get; set; }
        /// <summary>
        /// 子账户个数
        /// </summary>
        public string subAccCount { get; set; }
        /// <summary>
        /// 集团账户类型 1、实体 2、虚拟(集团提供) 3、虚拟(自动生成)
        /// </summary>
        public string accountGroupTypeFlag { get; set; }
    }
}
