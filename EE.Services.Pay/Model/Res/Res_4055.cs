using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4055
    {
        /// <summary>
        /// 总账号
        /// </summary>
        public string headAccountNo { get; set; }
        /// <summary>
        /// 总账户户名
        /// </summary>
        public string headAccountName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string headOpenBranch { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string headCurCode { get; set; }
        /// <summary>
        /// 上级账号
        /// </summary>
        public string supAccountNo { get; set; }
        /// <summary>
        /// 上级账户户名
        /// </summary>
        public string supAccountName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string supOpenBranch { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string supCurCode { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string subAccountNo { get; set; }
        /// <summary>
        /// 账户户名
        /// </summary>
        public string subAccountName { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string BranchNo { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 集团类型 1-实体 2-虚子账户（集团提供) 3-虚子账户（自动生成）
        /// </summary>
        public string accountGroupTypeFlag { get; set; }
        /// <summary>
        /// 子账户层级
        /// </summary>
        public string subAccountLeve { get; set; }
        /// <summary>
        /// 产品合约种类 1、资金归集 2、资金池 3、其他
        /// </summary>
        public string agreementType { get; set; }
        /// <summary>
        /// 自动归集/下拨标志  Y-是N-否
        /// </summary>
        public string authCirculateFlag { get; set; }
        /// <summary>
        /// 手动归集标志 Y-是N-否
        /// </summary>
        public string handGuijiFlag { get; set; }
        /// <summary>
        ///  手动下拨标志 Y-是N-否
        /// </summary>
        public string handXiaboFlag { get; set; }
        /// <summary>
        /// 归集类型 1-实时 2-批量 3-定时
        /// </summary>
        public string guiJiType { get; set; }
        /// <summary>
        /// 下拨类型  1、实时 2、批量 3、定时
        /// </summary>
        public string xiaboType { get; set; }
        /// <summary>
        /// 定时归集周期 1-日 2-月
        /// </summary>
        public string guiJiCycle { get; set; }
        /// <summary>
        /// 定时归集日期
        /// </summary>
        public string guiJiDate { get; set; }
        /// <summary>
        /// 定时归集时间 归集/下拨时间为12、13、16、18四个时间点，“000000000001000100000000”
        /// </summary>
        public string guiJiTime { get; set; }
        /// <summary>
        /// 归集方式 1-全额归集 2-超留存余额后全额归集 3-超留存余额后差额归集
        /// </summary>
        public string guiJiMode { get; set; }
        /// <summary>
        /// 归集取整单位 1、分 2、角 3、元 4、十元 5、百元 6、千元 7、万元 8、十万元 9、百万元 10、千万元 
        /// </summary>
        public string guiJiIntegerUnity { get; set; }
        /// <summary>
        /// 留存金额
        /// </summary>
        public string guiJiBalance { get; set; }
        /// <summary>
        /// 支控方式 1-统收统支； 2-以收定支； 3-超额定支； 4-预算定支；
        /// </summary>
        public string controlMode { get; set; }
        /// <summary>
        /// 超额额度
        /// </summary>
        public string bigLimit { get; set; }
        /// <summary>
        /// 预算定支额度
        /// </summary>
        public string bookLimit { get; set; }
        /// <summary>
        /// 是否允许日间透支 Y-允许 N-不允许
        /// </summary>
        public string dayOverdraftFlag { get; set; }
        /// <summary>
        /// 日间透支额度 
        /// </summary>
        public string dayOverLimit { get; set; }
        /// <summary>
        /// 定时下拨周期  1-日 2-月
        /// </summary>
        public string xiaboCycle { get; set; }
        /// <summary>
        /// 定时下拨日期
        /// </summary>
        public string xiaboDate { get; set; }
        /// <summary>
        /// 定时下拨时间 归集/下拨时间为12、13、16、18四个时间点
        /// </summary>
        public string xiaboTime { get; set; }
        /// <summary>
        /// 下拨方式 1-当维持余额不足时差额下拨 2-当维持余额不足时按固定金额下拨
        /// </summary>
        public string xiaboMode { get; set; }
        /// <summary>
        /// 下拨固定金额
        /// </summary>
        public string xiaboKeepAmt { get; set; }
        /// <summary>
        /// 维持余额
        /// </summary>
        public string xiaboBalance { get; set; }
        /// <summary>
        /// 委托贷款标志 Y-是 N-否
        /// </summary>
        public string entrustLoanFlag { get; set; }
        /// <summary>
        /// 是否计息 Y-是 N-否
        /// </summary>
        public string RateFlag { get; set; }
        /// <summary>
        /// 利息自动入账标志 Y-是  N-否
        /// </summary>
        public string rateRemitInFlag { get; set; }
        /// <summary>
        /// 上存利率
        /// </summary>
        public string upRate { get; set; }
        /// <summary>
        /// 下拨利率
        /// </summary>
        public string downRate { get; set; }
        /// <summary>
        /// 合约状态 1、待确认 2、待生效 3、正常 4、暂停 5、作废
        /// </summary>
        public string agreementState { get; set; }
        /// <summary>
        /// 合约生效日期
        /// </summary>
        public string effectDate { get; set; }
        /// <summary>
        /// 结息周期结息周期
        /// </summary>
        public string settleInterestsCycle { get; set; }
        /// <summary>
        /// 虚账号余额
        /// </summary>
        public string virAccBalance { get; set; }        
    }
}
