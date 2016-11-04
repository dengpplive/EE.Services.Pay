using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4025
    {
        /// <summary>
        /// 输出区长度
        /// </summary>
        public string OUT_LEN { get; set; }
        /// <summary>
        /// 格式码
        /// </summary>
        public string OUT_FMT_CODE { get; set; }
        /// <summary>
        /// 前置机代码
        /// </summary>
        public string OUT_FRONT_CODE { get; set; }
        /// <summary>
        /// 前置机流水号
        /// </summary>
        public string OUT_FRONT_JRN_NO { get; set; }
        /// <summary>
        /// 日志号
        /// </summary>
        public string OUT_IBS_JRN_NO { get; set; }
        /// <summary>
        /// 执行日期
        /// </summary>
        public string OUT_IBS_DATE { get; set; }
        /// <summary>
        /// 交易码
        /// </summary>
        public string OUT_IBS_TXN_CODE { get; set; }
        /// <summary>
        /// 协定定期账号
        /// </summary>
        public string Q10_AC_NO { get; set; }
        /// <summary>
        /// 总有效存单数
        /// </summary>
        public string Q10_TOT_DEP { get; set; }
        /// <summary>
        /// 有效查询存单数
        /// </summary>
        public string Q10_CONF_CNT { get; set; }
        /// <summary>
        /// 是否结束标志	Y：存单个数不足50个
        ///N：存单个数超过50个
        /// </summary>
        public string Q10_END_FLG { get; set; }
        /// <summary>
        /// 起始存单序号
        /// </summary>
        public string Q10_STR_SEQNO { get; set; }

        /// <summary>
        /// 存单明细信息，依据存款笔数，最大循环50次
        /// </summary>
        public List<Result_4025> list { get; set; } = new List<Result_4025>();
    }

    [Serializable]
    public partial class Result_4025
    {
        /// <summary>
        /// 存单序号
        /// </summary>
        public string Q10_SEQ_NO { get; set; }
        /// <summary>
        /// 存单种类
        /// </summary>
        public string Q10_DEP_TYPE { get; set; }
        /// <summary>
        /// 存单种类中文描述
        /// </summary>
        public string Q10_DEP_TYPE_DESC { get; set; }
        /// <summary>
        /// 货币码
        /// </summary>
        public string Q10_CCY { get; set; }
        /// <summary>
        /// 钞汇标识
        /// </summary>
        public string Q10_RECP_TYPE { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Q10_BAL { get; set; }
        /// <summary>
        /// 利率
        /// </summary>
        public string Q10_INT_RATE { get; set; }
        /// <summary>
        /// 起息日期
        /// </summary>
        public string Q10_VAL_DATE { get; set; }
        /// <summary>
        /// 存期
        /// </summary>
        public string Q10_PERD { get; set; }
        /// <summary>
        /// 存期中文描述
        /// </summary>
        public string Q10_PERD_DESC { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public string Q10_DUE_DATE { get; set; }
        /// <summary>
        /// 存单号
        /// </summary>
        public string Q10_RECP_NO { get; set; }
        /// <summary>
        /// 转存指示 0 亲临支取 
        /// 1 本息续存  
        /// 2 本金续存，利息转存指定账户
        /// 3 本息全部转存指定账户
        /// 9 自动转存拒绝
        /// </summary>
        public string Q10_INST { get; set; }
        /// <summary>
        /// 转存指示中文描述
        /// </summary>
        public string Q10_INST_DESC { get; set; }
        /// <summary>
        /// 存单状态字 [1]1 存单销单
        ///[2]1 存单正式挂失
        ///[3]1 存单口头挂失
        ///[4]1 法律冻结
        ///[5]1 存单止付
        ///[6]1 质押
        ///[7]1 存单挂失新开
        ///[8]1 自动转存开单
        ///[9]1 开单冲账/反交易
        ///[10]1 销单冲账/反交易
        ///第12位为1则该存单为电子存单
        /// </summary>
        public string Q10_STAS_WORD { get; set; }
        /// <summary>
        /// 存单状态字中文描述
        /// </summary>
        public string Q10_STAS_WORD_DESC { get; set; }
    }

}
