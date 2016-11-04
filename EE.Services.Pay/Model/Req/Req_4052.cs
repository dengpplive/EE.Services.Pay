using System;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 集团内手工归集下拨[4052]
    /// </summary>
    [Serializable]
    public partial class Req_4052
    {
        private int _guiJiAreaOption = 1;
        private int _guiJiType = 1;
        /// <summary>
        /// 归集流水号 此流水号由企业生成，保证唯一性
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 上级账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 归集/下拨范围选择 当选择1-全部时，触发合约，当选择2-单子账户时，只对所选子账户归集下拨
        /// </summary>
        public int guiJiAreaOption { get { return _guiJiAreaOption; } set { _guiJiAreaOption = value; } }
        /// <summary>
        /// 下级账户 在OPTIONE选择2-单子账户时，需要送
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 归集/下拨类型 1-归集 2-下拨(只在“2-单子单账户”下显示)
        /// </summary>
        public int guiJiType { get { return _guiJiType; } set { _guiJiType = value; } }
        /// <summary>
        /// 金额 只在“2-单子单账户”下显示 13位整数，2位小数
        /// </summary>
        public decimal Amount { get; set; }       
    }
}
