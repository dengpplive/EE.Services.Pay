using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4022
    {
        /// <summary>
        /// 总账户
        /// </summary>
        public string AC { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string CCY { get; set; }
        /// <summary>
        /// 总账户户名
        /// </summary>
        public string ACNAME { get; set; }
        /// <summary>
        /// 集团类型 1-实体 2-虚子账户（集团提供) 3-虚子账户（自动生成）
        /// </summary>
        public string GTYPE { get; set; }
        /// <summary>
        /// 集团状态 1-待确认 2-待生效 3-正常 4-暂停 5-作废
        /// </summary>
        public string headAgreementState { get; set; }
        /// <summary>
        /// 自动归集下拨标志 C-归集 D-下拨 A-归集/下拨 Q-查询
        /// </summary>
        public string headAuthCirculateFlag { get; set; }
        /// <summary>
        /// 自动归集下拨类型 1、实时 2、批量 3、定时
        /// </summary>
        public string headAuthinnerCirculateType { get; set; }
        /// <summary>
        /// 手动归集下拨标志 Y-是  N-否
        /// </summary>
        public string headHandCirculateFlag { get; set; }
        /// <summary>
        /// 建立日期 YYYYMMDD 20100628
        /// </summary>
        public string WRDATE { get; set; }
        /// <summary>
        /// 到期日期 YYYYMMDD 20100628
        /// </summary>
        public string DUEDATE { get; set; }
        /// <summary>
        /// 客户经理号 
        /// </summary>
        public string CONCURNO { get; set; }
        /// <summary>
        /// 开户行号
        /// </summary>
        public string UNITNO { get; set; }
        /// <summary>
        /// 法人透支限额
        /// </summary>
        public string OVRT_BAL { get; set; }
        /// <summary>
        /// 账户账面余额
        /// </summary>
        public string CURRBAL { get; set; }       
    }
}
