using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4021
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AcctNo { get; set; }
        /// <summary>
        /// 总存单记录数
        /// </summary>
        public string TotalCount { get; set; }
        /// <summary>
        /// 当前返回存单记录数
        /// </summary>
        public string PageRecCount { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        public List<Result_4021> list { get; set; } = new List<Result_4021>();
    }

    [Serializable]
    public partial class Result_4021
    {
        /// <summary>
        /// 存款顺序号
        /// </summary>
        public string SeqNo { get; set; }
        /// <summary>
        /// 存款类型 普通定期 FIXED DEPOSIT      01 
        ///企业定期 COMPANY DEPOSIT    02 
        ///大额定期 LARGE AMT DEPOSIT  03 
        ///保证金存款 BAIL DEPOSIT     04 
        ///零存整取 CLUB DEPOSIT       05 
        ///教育储蓄 EDUCATION DEPOSIT  06 
        ///整存零取 ANTI-CLUB DEPOSIT  07 
        ///存本取息 CUNBEN-QUXI DEPOSIT 08  
        ///通知存款 CALL DEPOSIT       09
        ///定活两便 OPTIONAL DEPOSIT   10
        /// </summary>
        public string DepositType { get; set; }
        /// <summary>
        /// 存款类型描述
        /// </summary>
        public string DepositTypeDesc { get; set; }
        /// <summary>
        /// 货币
        /// </summary>
        public string CcyCode { get; set; }
        /// <summary>
        /// 钞汇标志 Ｃ／Ｒ（钞／汇）
        /// </summary>
        public string CcyType { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 利率
        /// </summary>
        public string Rate { get; set; }
        /// <summary>
        /// 起息日
        /// </summary>
        public string ValueDate { get; set; }
        /// <summary>
        /// 存期
        /// </summary>
        public string Period { get; set; }
        /// <summary>
        /// 存期描述
        /// </summary>
        public string PeriodDesc { get; set; }
        /// <summary>
        /// 到期日
        /// </summary>
        public string DueDate { get; set; }
        /// <summary>
        /// 到期指示 0 亲临支取 
        ///1 本息续存  
        ///2 本金续存，利息转存指定账户
        ///3 本息全部转存指定账户
        ///9 自动转存拒绝
        /// </summary>
        public string Inst { get; set; }
        /// <summary>
        /// 到期指示描述
        /// </summary>
        public string InstDesc { get; set; }
        /// <summary>
        /// 存单状态 [1]1 存单销单
        ///[2]1 存单正式挂失
        ///[3]1 存单口头挂失
        ///[4]1 法律冻结
        ///[5]1 存单止付
        ///[6]1 质押
        ///[7]1 存单挂失新开
        ///[8]1 自动转存开单
        ///[9]1 开单冲账/反交易
        ///[10]1 销单冲账/反交易
        ///[12] 1：电子存单，0：纸质存单
        ///后5位暂未启用
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 存单状态描述
        /// </summary>
        public string StatusDesc { get; set; }
    }
}
