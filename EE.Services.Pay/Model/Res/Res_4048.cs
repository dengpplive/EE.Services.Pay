using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4048
    {
        /// <summary>
        /// 凭证号 标示交易唯一性
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 批次处理状态	C(1)	Y	3:批次失败 4:批次成功
        /// </summary>
        public string BStt { get; set; }
        /// <summary>
        /// 费项代码	C(5)	Y	客户在银行签约代发代扣后银行通过的费项代码
        /// </summary>
        public string BusiType { get; set; }
        /// <summary>
        /// 付扣类型	C(1)	Y	0：扣  1：付
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 币种		Y	目前只支持RMB
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 他行标志		N	Y：他行 N：同行 为空时默认同行，目前只支持同行
        /// </summary>
        public string OthBankFlag { get; set; }
        /// <summary>
        /// 本方帐号	C(20)	Y	代发代扣协议签约账户
        /// </summary>
        public string SrcAccNo { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public string TotalNum { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public string TotalAmount { get; set; }
        /// <summary>
        /// 入帐方式
        /// </summary>
        public string SettleType { get; set; }

        public List<Result_4048> list { get { return _list; } set { _list = value; } }
        private List<Result_4048> _list = new List<Result_4048>();        
    }

    [Serializable]
    public partial class Result_4048
    {
        /// <summary>
        /// 单笔交易流水号	C(20)	Y	批内唯一
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号	C(20)	N	上送则返回，企业自定义
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 对方证件类型	C(5)	N	校验证件时必输
        ///证件类型：
        ///1-身份证
        ///2-军人军官证
        ///3-港澳台居民通行证
        ///4-中国护照
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 对方证件号码	C(25)	N	校验证件时必输
        /// 对应的证件类型号码
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 对方帐号
        /// </summary>
        public string OppAccNo { get; set; }
        /// <summary>
        /// 对方户名
        /// </summary>
        public string OppAccName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 附言、备注
        /// </summary>
        public string PostScript { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public string Fee { get; set; }
        /// <summary>
        /// 单笔处理结果
        /// </summary>
        public string stt { get; set; }
        /// <summary>
        /// 结果描述
        /// </summary>
        public string sttInfo { get; set; }
        /// <summary>
        /// 个人账户备注
        /// </summary>
        public string RemarkFCR { get; set; }        
    }
}
