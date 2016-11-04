using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4052
    {
        /// <summary>
        /// 归集流水号	Char(20)	Y	此流水号由企业生成，保证唯一性
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 银行流水号	Char(14)	Y	银行提供的流水号
        /// </summary>
        public string flowNo { get; set; }
        /// <summary>
        /// 上级账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 总账号户名
        /// </summary>
        public string supAccountName { get; set; }
        /// <summary>
        /// 总账号开户行
        /// </summary>
        public string supAccountOpenNode { get; set; }
        /// <summary>
        /// 归集/下拨范围选择	Char(1)		1-全部 2-单子账户
        /// </summary>
        public string guiJiAreaOption { get; set; }
        /// <summary>
        /// 子账号
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 子账号户名
        /// </summary>
        public string subAccountName { get; set; }
        /// <summary>
        /// 归集/下拨类型 1-归集 2-下拨
        /// </summary>
        public string guiJiType { get; set; }
        /// <summary>
        /// 金额	C(13,2)		13位整数，2位小数
        /// </summary>
        public string Amount { get; set; }        
    }
}
