using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 代发代扣申请接口[4047]
    /// </summary>
    [Serializable]
    public partial class Req_4047
    {
        /// <summary>
        /// 凭证号 标示交易唯一性 20位
        /// </summary>
        public string ThirdVoucher { get; set; }
        /// <summary>
        /// 委托单位协议号 协议号，每个代收付协议唯一 【可选】
        /// </summary>
        public string AGREE_NO { get; set; }
        /// <summary>
        /// 费项代码 客户在银行签约代发代扣后银行通过的费项代码
        /// </summary>
        public string BusiType { get; set; }
        /// <summary>
        /// 付扣类型 0：扣  1：付
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 币种 目前只支持RMB
        /// </summary>
        public string Currency { get; set; } = "RMB";
        /// <summary>
        /// 他行标志【可选】 Y:他行  N:同行   为空时默认同行，目前只支持同行
        /// </summary>
        public string OthBankFlag { get; set; } = "N";
        /// <summary>
        /// 本方帐号 代发代扣协议签约账户
        /// </summary>
        public string SrcAccNo { get; set; }
        /// <summary>
        /// 总记录数 入账方式如果为逐笔，则只能送1笔
        /// </summary>
        public int TotalNum { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 处理方式 该字段只对数量为1笔的代扣有效
        ///0：实时，如果客户有单笔代扣协议，建议选择0，交易实时处理并实时返回代扣结果；
        ///1：非实时，如果客户只有批量代扣协议，没有单笔代扣协议，则只能选择该方式，该方式批量处理，处理结果需要发送4048交易查询。
        /// </summary>
        public int SettleType { get; set; }
        /// <summary>
        /// 多条记录
        /// </summary>
        public List<HOResultSet4047R> HOResultSet4047R { get; set; } = new List<Req.HOResultSet4047R>();
    }
    [Serializable]
    public partial class HOResultSet4047R
    {       
        /// <summary>
        /// 单笔交易流水号 批内唯一
        /// </summary>
        public string SThirdVoucher { get; set; }
        /// <summary>
        /// 客户自定义凭证号【可选】 上送则返回，企业自定义
        /// </summary>
        public string CstInnerFlowNo { get; set; }
        /// <summary>
        /// 异地标志 【可选】 Y：异地 N：当地 为空默认当地
        /// </summary>
        public string OthAreaFlag { get; set; } = "N";

        /// <summary>
        /// 对方证件类型 校验证件时必输 【可选】        
        //证件类型：
        //1       身份证
        //2       军人军官证
        //3       港澳台居民通行证
        //4       中国护照
        //5       单位统一代码
        //6       未登记证件
        //7       暂住证
        //8       武警警官证
        //9       临时身份证
        //10     联名户
        //11     户口簿
        //12     中国居民其他证
        //13     军人士兵证
        //14     军人文职干部证
        //15     军人其他证件
        //16     武警士兵证
        //17     武警文职干部证
        //18     武警其他证件
        //19     外国护照
        //20     外国公民其他证件

        //51     法人代码证
        //52     组织机构代码证
        //53     政府机构/公共机构批文
        //54     外交部、外事办批文(使)
        //55     外交部、外事办批文(领)
        //56     外交部、外事办批文(办)
        //60     香港商业登记证
        //70     其他证明文件(公司)
        //71     公司户重复有效证件
        //65     事业单位登记证
        //66     社会团体登记证
        //67     商业登记证（离岸）
        //68     营业执照
        //69     对公临时证件
        //80     金融机构           
        /// </summary>
        public string IdType { get; set; }
        /// <summary>
        /// 对方证件号码 校验证件时必输   对应的证件类型号码
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 对方开户行名 跨行必填
        /// </summary>
        public string OppBankName { get; set; }
        /// <summary>
        /// 对方帐号
        /// </summary>
        public string OppAccNo { get; set; }
        /// <summary>
        /// 对方户名 
        /// </summary>
        public string OppAccName { get; set; }
        /// <summary>
        /// 对方联行号 跨行建议输入
        /// </summary>
        public string OppBranchId { get; set; }
        /// <summary>
        /// 省份 跨行建议输入,参考附录“省代码表”
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 附言、备注
        /// </summary>
        public string PostScript { get; set; }
        /// <summary>
        /// 个人账户备注 若输入，则显示在被扣个人账户的附言备注栏。
        /// </summary>
        public string RemarkFCR { get; set; }
    }
}
