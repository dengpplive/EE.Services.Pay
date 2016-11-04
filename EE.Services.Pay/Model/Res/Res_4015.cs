using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4015
    {
        /// <summary>
        /// 成功笔数	C(5)	非必输	查询类型为“0全部”时返回
        /// </summary>
        public string successCts { get; set; }
        /// <summary>
        /// 成功金额	C(13,2)	非必输	查询类型为“0全部”时返回
        /// </summary>
        public string successAmt { get; set; }
        /// <summary>
        /// 失败笔数	C(5)	非必输	查询类型为“0全部”时返回
        /// </summary>
        public string faildCts { get; set; }
        /// <summary>
        /// 失败金额	C(13,2)	非必输	查询类型为“0全部”时返回
        /// </summary>
        public string faildAmt { get; set; }
        /// <summary>
        /// 处理中笔数	C(5)	非必输	查询类型为“0全部”时返回
        /// </summary>
        public string processCts { get; set; }
        /// <summary>
        /// 处理中金额	C(13,2)	非必输	查询类型为“0全部”时返回
        /// </summary>
        public string processAmt { get; set; }
        /// <summary>
        /// 批次总记录数	9(10)	必输	批次的记录总数
        /// </summary>
        public string TotalCts { get; set; }
        /// <summary>
        /// 符合当前查询条件的笔数	9(10)	必输	符合当前查询条件的笔数
        /// </summary>
        public string CTotalCts { get; set; }
        /// <summary>
        /// 当前页返回的记录数	9(10)	必输	当前分页返回的记录数
        /// </summary>
        public string PTotalCts { get; set; }
        /// <summary>
        /// 记录结束标志	C(1)	必输	Y:无剩余记录
        /// N:有剩余记录
        /// 符合当前查询条件的记录是否查询结束
        /// </summary>
        public string IsEnd { get; set; }
        /// <summary>
        /// 批次状态	C(2)	非必输	20：成功
        ///30：失败
        ///其他为银行受理成功处理中
        /// </summary>
        public string batchSTT { get; set; }
        /// <summary>
        /// 子批次状态描述	C(100)	非必输	格式:
        ///[子批次号]-[状态]-[错误码]-[错误信息];
        /// </summary>
        public string subBatchSTT { get; set; }
        /// <summary>
        /// 多条记录
        /// </summary>
        public List<Result_4015> list { get { return _list; } set { _list = value; } }
        private List<Result_4015> _list = new List<Result_4015>();      
    }

    [Serializable]
    public partial class Result_4015
    {
        /// <summary>
        /// 银行流水号	C(14)	必输
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 单笔转账凭证号(批次中的流水号)	C(20)	非必输	若上送，则返回按递增排序
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	非必输	若客户上送则返回
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 货币类型	C(3)	必输
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 转出账户开户网点名	C(60)	非必输
        /// </summary>
        public string OutAcctBankName { get; set; }
        /// <summary>
        /// 转出账户	C(14)	必输
        /// </summary>
        public string OutAcctNo { get; set; }
        /// <summary>
        /// 转入账户网点名称	C(60)	非必输
        /// </summary>
        public string InAcctBankName { get; set; }
        /// <summary>
        /// 转入账户	C(32)	必输
        /// </summary>
        public string InAcctNo { get; set; }
        /// <summary>
        /// 转入账户户名	C(60)	必输
        /// </summary>
        public string InAcctName { get; set; }
        /// <summary>
        /// 交易金额	C(13)	必输
        /// </summary>
        public string TranAmount { get; set; }
        /// <summary>
        /// 行内跨行标志	C(1)	必输	1：行内转账，0：跨行转账
        /// </summary>
        public string UnionFlag { get; set; }
        /// <summary>
        /// 交易状态标志	C(2)	必输	20：成功 30：失败 其他为银行受理成功处理中
        /// </summary>
        public string Stt { get; set; }
        /// <summary>
        /// 转账退票标志	C(1)	必输	0:未退票; 1:退票;
        /// </summary>
        public string IsBack { get; set; }
        /// <summary>
        /// 支付失败、退票原因	C(20)	非必输	
        /// </summary>
        public string BackRem { get; set; }
        /// <summary>
        /// 银行处理结果	C(40)	必输	格式为：“六位代码:中文描述”。冒号为半角。如： 000000：内部转账交易成功    MA0103: 没有满足条件纪录；
        /// </summary>
        public string Yhcljg { get; set; }
        /// <summary>
        /// 转账加急标志	C(1) 
        ///必输	‘1’—大额 ，等同Y  
        ///‘2’—小额”等同N
        ///Y：加急 N：不加急S：特急
        /// </summary>
        public string SysFlag { get; set; }
        /// <summary>
        /// 银行手续费	C(13)		转账手续费预算，实际手续费用以实际扣取的为准。
        /// </summary>
        public string Fee { get; set; }
        /// <summary>
        /// 转账代码类型	C(4)	必输	4004：单笔转账；
        ///4014：单笔批量；
        ///4018：大批量转账
        ///4034：汇总批量
        /// </summary>
        public string TransBsn { get; set; }
        /// <summary>
        /// 交易受理时间	C(14)	非必输	交易受理时间
        /// </summary>
        public string submitTime { get; set; }
        /// <summary>
        /// 记账日期	C(8)	非必输	主机记账日期
        /// </summary>
        public string AccountDate { get; set; }
        /// <summary>
        /// 主机记账流水号	C(10)	非必输	主机记账流水
        /// </summary>
        public string hostFlowNo { get; set; }
        /// <summary>
        /// 代理人户名	C(60)	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayName { get; set; }
        /// <summary>
        /// 代理人账号	C(30)	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayAcc { get; set; }
        /// <summary>
        /// 代理人银行名称	C(30)	非必输	用于代理行支付功能
        /// </summary>
        public string ProxyPayBankName { get; set; }        
    }
}
