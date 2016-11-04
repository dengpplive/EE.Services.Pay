using EE.Services.Pay.Common;
using System;

namespace EE.Services.Pay.Model.Req
{
    /// <summary>
    /// 业务报文头部信息 122位
    /// </summary>
    [Serializable]
    public class BusinessHeader
    {
        private string _TranFunc = "";
        private string _ServType = "01";
        private string _MacCode = "0";
        private string _RspCode = "999999";
        private string _RspMsg = "";
        private string _ConFlag = "0";
        private string _CounterId = "";
        private string _ThirdLogNo = "";
        private string _Qydm = "";
        private string _Length = "0";
        private string _TrandateTime = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        /// <summary>
        /// 交易类型 C(4)  老版本4位接口交易码 新版位6位接口交易码
        /// </summary>
        public string TranFunc { get { return _TranFunc.PadRight(4, ' '); } set { _TranFunc = value; } }
        /// <summary>
        /// 服务类型 C(2)
        /// </summary>
        public string ServType { get { return _ServType; } set { _ServType = value; } }
        /// <summary>
        /// MAC码 C(16)
        /// </summary>
        public string MacCode
        {
            get
            {
                return Utils.ToData(_MacCode, 16);
            }
            set { _MacCode = value; }
        }
        /// <summary>
        /// 交易日期和时间 C(14)
        /// </summary>
        public string TrandateTime { get { return _TrandateTime.PadRight(14, ' '); } set { _TrandateTime = value; } }
        /// <summary>
        /// 应答码 交易发起方初始填入”999999” C(6)
        /// </summary>
        public string RspCode { get { return _RspCode.PadRight(6, ' '); } set { _RspCode = value; } }
        /// <summary>
        /// 应答码描述 C(42)
        /// </summary>
        public string RspMsg
        {
            get
            {
                return Utils.ToData(_RspMsg, 42);
            }
            set
            {
                _RspMsg = value;
            }
        }
        /// <summary>
        /// 后续包标志 0结束包,1还有后续包 C(1)
        /// </summary>
        public string ConFlag { get { return _ConFlag; } set { _ConFlag = value; } }
        /// <summary>
        /// 报文体长度 C(8)
        /// </summary>
        public string Length { get { return _Length.PadLeft(8, '0'); } set { _Length = value; } }
        /// <summary>
        /// 操作员号 C(5) 企业操作员代码 (由企业指定)
        /// </summary>
        public string CounterId { get { return _CounterId.PadLeft(5, ' '); } set { _CounterId = value; } }
        /// <summary>
        /// 请求方系统流水号 C(20)
        /// </summary>
        public string ThirdLogNo { get { return _ThirdLogNo.PadRight(20, ' '); } set { _ThirdLogNo = value; } }
        /// <summary>
        /// 交易网代码 C(4)
        /// </summary>
        public string Qydm { get { return _Qydm.PadRight(4, ' '); } set { _Qydm = value; } }
        /// <summary>
        /// 字符串显示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tranMessageHead = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",
                TranFunc,    //交易类型 C(4)
                ServType,    //服务类型 C(2)
                MacCode,     //MAC码 C(16)
                TrandateTime,//交易日期和时间 C(14)
                RspCode,    //应答码 交易发起方初始填入”999999” C(6)
                RspMsg,     //应答码描述 C(42)
                ConFlag,    //后续包标志 0结束包,1还有后续包 C(1)
                Length,     //报文体长度 C(8)
                CounterId,  //操作员号 C(5)
                ThirdLogNo, //请求方系统流水号 C(20)
                Qydm        //交易网代码 C(4)
                 );
            return tranMessageHead;
        }
    }
}
