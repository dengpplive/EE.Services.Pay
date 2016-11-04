using EE.Services.Pay.Common;
using EE.Services.Pay.Common.Ext;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Req;
using System;
using System.Collections.Generic;
using System.Text;

namespace EE.Services.Pay.InertnetVer
{
    /// <summary>
    /// [平安银行银企直连-跨行快付接口V0.5]
    /// </summary>
    public class CrossLineFastPaymentInterface
    {
        #region 构造方法
        private bool IsSpecialLine = false;
        /// <summary>
        ///  是否为专线 true专线 false互联网 默认互联网
        /// </summary>
        /// <param name="IsSpecialLine"></param>
        public CrossLineFastPaymentInterface(bool IsSpecialLine = false)
        {
            this.IsSpecialLine = IsSpecialLine;
        }
        #endregion
        #region 私有方法        
        /// <summary>
        /// 根据请求参数 返回结果
        /// </summary>
        /// <param name="parmaKeyDict"></param>
        /// <returns></returns>
        private DataResult GetResult(ExHashTable parmaKeyDict)
        {
            //记录日志
            StringBuilder sbLog = new StringBuilder();
            ExHashTable retKeyDict = new ExHashTable();
            try
            {
                //检测
                Utils.PayCheckData((string)parmaKeyDict.Get("ThirdLogNo"), (string)parmaKeyDict.Get("CounterId"));
                //获取请求报文
                BankInterface msg = new BankInterface();
                //调用函数生成请求的而完整报文          
                List<string> messageList = msg.GetBankEnterpriseMessageReq(parmaKeyDict, this.IsSpecialLine);
                var pinganPayConfig = GlobalData.LoadPinganConfig();
                string reqMessage = string.Join("", (pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.TeleProtocol == "01" ? messageList.ToArray() : messageList.GetRange(1, 2).ToArray()));
                sbLog.AppendFormat("时间:{0}\r\n", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sbLog.AppendFormat("请求:{0}\r\n", reqMessage);
                //发送请求报文  //获取银行返回报文
                string recvMessage = msg.SendMessage(reqMessage, pinganPayConfig.BankEnterpriseNetHead.NetMessageHead.TeleProtocol);
                sbLog.AppendFormat("响应:{0}\r\n", recvMessage);
                //解析返回结果
                retKeyDict = msg.ParsingBankEnterpriseMessageString(recvMessage);
                sbLog.AppendFormat("解析结果:\r\n{0}\r\n", retKeyDict.ToString());
            }
            catch (Exception ex)
            {
                sbLog.AppendFormat("异常信息:{0}\r\n", ex.Message);
                throw ex;
            }
            finally
            {
                //写入日志
                if (GlobalData.LoadPinganConfig().OpenLog)
                    FileHelper.SaveFile(string.Format("Log\\Req\\ReqData_{0}.txt", System.DateTime.Now.ToString("yyyyMMdd")), sbLog.ToString() + "\r\n\r\n");
            }
            //转换
            return Utils.ToDataResult(retKeyDict, GlobalData.DirectErpBankVersion);
        }
        #endregion        

        #region 第三章 银企直连跨行快付接口
        /// <summary>
        /// 3.1 批量付款文件提交 [KHKF01]
        /// </summary>     
        /// <param name="req_KHKF01">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult PatchPaymentFileCommitInterface(Req_KHKF01 req_KHKF01, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "KHKF01");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", req_KHKF01.BatchNo);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_KHKF01);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_KHKF01();
            return retKeyDict;
        }
        /// <summary>
        /// 3.2 批量付款结果查询[KHKF02]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_KHKF02">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult PatchPaymentResultQueryInterface(string serialNumber, Req_KHKF02 req_KHKF02, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "KHKF02");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_KHKF02);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_KHKF02();
            return retKeyDict;
        }
        /// <summary>
        /// 3.3 单笔付款申请[KHKF03]
        /// </summary>       
        /// <param name="req_KHKF03">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult SinglePaymentApplayInterface(Req_KHKF03 req_KHKF03, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "KHKF03");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", req_KHKF03.OrderNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_KHKF03);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_KHKF03();
            return retKeyDict;
        }
        /// <summary>
        /// 3.4 单笔付款结果查询[KHKF04]
        /// </summary>       
        /// <param name="req_KHKF04">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult SinglePaymentResultQueryInterface(Req_KHKF04 req_KHKF04, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "KHKF04");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", req_KHKF04.OrderNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_KHKF04);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_KHKF04();
            return retKeyDict;
        }
        /// <summary>
        /// 3.5 对账/差错文件查询[KHKF05] 
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_KHKF05">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult ReconciliationOrErrorFileQueryInterface(string serialNumber, Req_KHKF05 req_KHKF05, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "KHKF05");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_KHKF05);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_KHKF05();
            return retKeyDict;
        }
        #endregion

        #region 文件传输
        /// <summary>
        /// 文件上传接口
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_FILE01">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult FILE01_Interface(string serialNumber, Req_FILE01 req_FILE01, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "FILE01");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_FILE01);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }
        /// <summary>
        /// 5.3.3 FILE02文件上传和下载进度查询
        /// </summary>
        /// <param name="tradeSn">上传文件流水号</param>   
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult FILE02_Interface(string tradeSn, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //交易码
            parmaKeyDict.Add("TranFunc", "FILE02");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", tradeSn);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //--文档参数
            parmaKeyDict.Add("TradeSn", tradeSn);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_FILE02();
            return retKeyDict;
        }
        /// <summary>
        ///  FILE03文件下载
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_FILE03">请求参数</param>
        /// <returns></returns>
        public DataResult FILE03_Interface(Req_FILE03 req_FILE03, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //交易码
            parmaKeyDict.Add("TranFunc", "FILE03");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", req_FILE03.TradeSn);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_FILE03);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_FILE03();
            return retKeyDict;
        }
        #endregion
    }
}
