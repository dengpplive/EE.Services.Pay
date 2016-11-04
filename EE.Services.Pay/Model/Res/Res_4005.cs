using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4005
    {
        /// <summary>
        /// 转账凭证号	C(20)	必输
        /// </summary>
        public string OrigThirdVoucher { get; set; }
        /// <summary>
        /// 银行流水号	C(14)	必输
        /// </summary>
        public string FrontLogNo { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	非必输	客户上送则返回
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
        /// 转账退票标志	C(1)	非必输	0:未退票; 默认为0 1:退票;
        /// </summary>
        public string IsBack { get; set; }
        /// <summary>
        /// 支付失败或退票原因描述	C(20)	非必输	如果是超级网银则返回如下信息:
        ///RJ01对方返回：账号不存在
        ///RJ02对方返回：账号、户名不符
        ///大小额支付则返回失败描述
        /// </summary>
        public string BackRem { get; set; }
        /// <summary>
        /// 银行处理结果	C(40)	必输	格式为：“六位代码:中文描述”。冒号为半角。如：000000：转账成功
        /// 处理中的返回(以如下返回开头)：
        /// MA9111:交易正在受理中
        /// 000000:交易受理成功待处理
        /// 000000:交易处理中
        /// 000000:交易受理成功处理中
        /// 成功的返回：
        /// 000000:转账交易成功
        /// 其他的返回都为失败:
        /// MA9112:转账失败
        /// </summary>
        public string Yhcljg { get; set; }
        /// <summary>
        /// 转账加急标志	C(1) 
        ///           必输	‘1’—大额 ，等同Y  
        ///    ‘2’—小额”等同N
        ///   Y：加急 N：普通S：特急
        /// </summary>
        public string SysFlag { get; set; }
        /// <summary>
        /// 转账手续费	C(13)	必输	
        /// </summary>
        public string Fee { get; set; }
        /// <summary>
        /// 转账代码类型	C(4)	必输	4004：单笔转账； 4014：单笔批量；
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
        /// 错误码	C(20)	非必输	交易失败的错误代码
        /// </summary>
        public string hostErrorCode { get; set; }
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
