using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EE.Services.Pay.Model.Res
{
    [Serializable]
    public partial class Res_4047
    {
        /// <summary>
        /// 凭证号
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 付扣类型	C(1)	Y	0：扣  1：付
        /// </summary>
        public string PayType { get; set; }
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
        /// 多条记录 标签名list （只有单笔实时代扣才会有list返回）
        /// </summary>
        public List<Result_4047> list { get { return _list; } set { _list = value; } }
        private List<Result_4047> _list = new List<Result_4047>();        
    }

    [Serializable]
    public partial class Result_4047
    {
        /// <summary>
        /// 单笔交易流水号
        /// </summary>
        public string SThirdVoucher { get; set; }
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
        /// 000000：成功
        ///这里只会有000000返回，如果交易失败或异常，返回报文头直接返回错误码和错误说明，没有保文体返回。
        /// </summary>
        public string stt { get; set; }        
    }
}
