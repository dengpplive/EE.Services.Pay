using EE.Services.Pay.Common;
using EE.Services.Pay.Common.Ext;
using EE.Services.Pay.Model;
using EE.Services.Pay.Model.Req;
using EE.Services.Pay.Model.Res;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EE.Services.Pay.InertnetVer
{
    /// <summary>
    /// [平安银行银企直连接口文档1.0] 
    /// 返回结果可以再次分装成具体的类对象
    /// </summary>
    public class BankEnterpriseDirectInterface
    {
        #region 构造方法
        private bool IsSpecialLine = false;
        /// <summary>
        ///  是否为专线 true专线 false互联网 默认互联网
        /// </summary>
        /// <param name="IsSpecialLine"></param>
        public BankEnterpriseDirectInterface(bool IsSpecialLine = false)
        {
            this.IsSpecialLine = IsSpecialLine;
        }
        #endregion

        #region 私有方法               
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

        #region 第三章 普通查询转账接口设计
        /// <summary>
        /// 系统状态探测(S001)
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <returns></returns>
        public DataResult SystemStatusProbeInterface(string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "S001");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }
        /// <summary>
        /// 企业账户余额查询(4001)  此接口适应银行所有币种的活期账户的余额查询，其中的可用余额只包含自身的资金状况，而不包括集团内部的资金池。账面余额，也只是自身账号的账面金额。
        /// 如果需要查询集团现金管理子账户的可用余额，需要调用“现金管理子账户余额查询[4059]”接口。
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="Req_4001">请求参数</param>     
        /// <param name="counterId">操作员号 5位</param>
        /// <returns></returns>
        public DataResult QueryQiyeAccountBalanceInterface(string serialNumber, Req_4001 req_4001, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            var PinganPayConfig = GlobalData.LoadPinganConfig();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4001");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4001);
            //-------------------
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4001();
            return retKeyDict;
        }

        /// <summary>
        /// 3.3 企业当日交易明细查询[4002]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4002">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult QueryErpTodayTradeDetailInterface(string serialNumber, Req_4002 req_4002, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            var PinganPayConfig = GlobalData.LoadPinganConfig();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4002");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4002);
            //-------------------
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4002();
            return retKeyDict;
        }
        /// <summary>
        /// 3.15 企业当日交易详情查询[4008]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4008">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult QueryErpTodayTradeDetailedInterface(string serialNumber, Req_4008 req_4008, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4008");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4008);
            //-------------------
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4008();
                var list = new List<Result_4008>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.EndFlag != "Y"); i++)
                    {
                        //按页码查询：第一次填0，后续页码递增1
                        if (model.list.Count > 0)
                        {
                            req_4008.PageNo++;
                            //日志号
                            req_4008.JournalNo = model.JournalNo;
                            //偏移量
                            req_4008.LogCount = model.LogCount;
                        }
                        //发送请求的时间间隔
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = QueryErpTodayTradeDetailedInterface(serialNumber, req_4008, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                        else
                        {
                            model.list = new List<Result_4008>();
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }

        /// <summary>
        /// 企业单笔资金划转(4004)
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4004">请求参数</param>  
        /// <param name="attachment">附件文件</param>
        /// <returns></returns>
        public DataResult QiyeSingleMoneyTransferInterface(string serialNumber, Req_4004 req_4004, string counterId = "", Attachment attachment = null)
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4004");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4004);
            //附件文件
            if (attachment != null)
            {
                parmaKeyDict.Add("Attach", attachment);
            }
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4004();
            return retKeyDict;
        }
        /// <summary>
        /// 企业批量实时资金划转[4014]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4014">请求参数</param>
        /// <param name="counterId">操作员号</param>
        /// <returns></returns>
        public DataResult QiyeBatchNoDelayMoneyTransferInterface(string serialNumber, Req_4014 req_4014, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4014");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4014);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4014();
            return retKeyDict;
        }
        /// <summary>
        /// 单笔提交转汇总批量[400401]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="Req_400401">请求参数</param>
        /// <param name="counterId">操作员号</param>
        /// <returns></returns>
        public DataResult SingleSubmitTransferSummaryBatchInterface(string serialNumber, Req_400401 req_400401, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "400401");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_400401);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_400401();
            return retKeyDict;
        }
        /// <summary>
        /// 企业大批量资金划转[4018]
        /// </summary>      
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4018">请求参数</param>
        /// <param name="counterId">操作员号</param>
        /// <returns></returns>
        public DataResult QiyeLargeBatchMoneyTransferInterface(string serialNumber, Req_4018 req_4018, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //交易码
            parmaKeyDict.Add("TranFunc", "4018");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4018);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4018();
            return retKeyDict;
        }

        /// <summary>
        ///  企业汇总资金划转[4034]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4034">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult QiyeSummaryMoneyTransferInterface(string serialNumber, Req_4034 req_4034, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4034");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4034);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4034();
            return retKeyDict;
        }

        /// <summary>
        /// 3.9 企业汇总资金划转[403401]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4034">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult QiyeSummaryMoneyTransfer_403401Interface(string serialNumber, Req_4034 req_4034, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "403401");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4034);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4034();
            return retKeyDict;
        }

        /// <summary>
        /// 单笔转账指令查询4005 上送必须输入如下三项中的一项，建议选择使用后两项。如果同时上送多项查询条件，则优先级如下：OrigThirdVoucher >  OrigFrontLogNo > OrigThirdLogNo
        /// </summary>       
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4005">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult SingleTransferCmdQueryInterface(string serialNumber, Req_4005 req_4005, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //交易码
            parmaKeyDict.Add("TranFunc", "4005");
            //请求流水号
            //parmaKeyDict.Add("ThirdLogNo", req_4005.OrigThirdLogNo);
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4005);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4005();
            return retKeyDict;
        }
        /// <summary>
        /// 企业交易明细详细信息查询[4006]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4006">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult ErpTradeDetailInfoQueryInterface(string serialNumber, Req_4006 req_4006, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4006");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4006);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4006();
            return retKeyDict;
        }
        /// <summary>
        /// 批量转账指令查询[4015]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4015">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult LargeBatchTransferCmdQueryInterface(string serialNumber, Req_4015 req_4015, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4015");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4015);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4015();
            return retKeyDict;
        }
        /// <summary>
        /// 历史余额查询[4012]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="Req_4012">请求参数</param>     
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult HistoryBalanceQueryInterface(string serialNumber, Req_4012 req_4012, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4012");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4012);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4012();
            return retKeyDict;
        }
        /// <summary>
        /// 查询账户当日历史交易明细[4013]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4013">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult QueryTodayHistoryTransactionDetailInterface(string serialNumber, Req_4013 req_4013, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4013");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4013);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4013();
                var list = new List<Result_4013>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.EndFlag != "Y"); i++)
                    {
                        //000001：第一页，依次类推 A: 一次查询回所有的记录，不分页，但是开始和结束时间必须为同一天
                        if (model.list.Count > 0) req_4013.PageNo++;
                        //发送请求的时间间隔
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = QueryTodayHistoryTransactionDetailInterface(serialNumber, req_4013, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 代理行支付当日交易查询[4011]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4011">请求参数</param>    
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult ProxyBankPayTodayTradeQueryInterface(string serialNumber, Req_4011 req_4011, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4011");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4011);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4011();
            return retKeyDict;
        }
        /// <summary>
        /// 贷款户明细查询[4016]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4016">请求参数</param>    
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult LoanAccountDetailQueryInterface(string serialNumber, Req_4016 req_4016,bool isAll=false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4016");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4016);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4016();
                var list = new List<Result_4016>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.EndFlag != "Y"); i++)
                    {
                        //第一次填写1, 第二次查询是填写上一次返回LastSeqNo 的值
                        if (model.list.Count > 0) req_4016.LNNO = model.LastSeqNo;
                        //发送请求的时间间隔
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = LoanAccountDetailQueryInterface(serialNumber, req_4016, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;                
            }
            return retKeyDict;
        }
        /// <summary>
        /// 银行联行号查询[4017]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4017">请求参数</param>  
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult BankContactNumberQueryInterface(string serialNumber, Req_4017 req_4017, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4017");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4017);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4017();
            return retKeyDict;
        }
        /// <summary>
        /// 离岸账户转账[4020]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4020">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult OffshoreAccountTransferInterface(string serialNumber, Req_4020 req_4020, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4020");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4020);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4020();
            return retKeyDict;
        }
        /// <summary>
        /// 支付指令退票查询[4019]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4019">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult PayCmdRefundQueryInterface(string serialNumber, Req_4019 req_4019, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4019");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4019);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4019();
                var list = new List<Result_4019>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.IsEnd != "Y"); i++)
                    {
                        //从1开始递增
                        if (model.list.Count > 0) req_4019.PageNo++;
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = PayCmdRefundQueryInterface(serialNumber, req_4019, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 代发代扣申请接口[4047]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4047">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult OnBehalfOfWithholdApplayInterface(string serialNumber, Req_4047 req_4047, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4047");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4047);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4047();
            return retKeyDict;
        }
        /// <summary>
        /// 代发代扣结果查询接口[4048]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4048">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult OnBehalfOfWithholdResultQueryInterface(string serialNumber, Req_4048 req_4048, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4048");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4048);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4048();
            return retKeyDict;
        }
        /// <summary>
        /// 银证转账[4009]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4009">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult SilverCardTransferMoneyInterface(string serialNumber, Req_4009 req_4009, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4009");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4009);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4009();
            return retKeyDict;
        }
        /// <summary>
        /// 查询券商端资金台帐余额[4010]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4010">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult QueryBrokerCapitalStationBalanceInterface(string serialNumber, Req_4010 req_4010, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4010");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4010);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4010();
            return retKeyDict;
        }
        /// <summary>
        /// 汇总批量付款电子回单查询[401802]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_401802">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult SummaryPatchPaymentReceiptBillInterface(string serialNumber, Req_401802 req_401802, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "401802");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_401802);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_401802();
            return retKeyDict;
        }
        /// <summary>
        /// 混合批量转账接口[4027]      
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4027">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult BlendPatchTransferMoneyInterface(string serialNumber, Req_4027 req_4027, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            // string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4027");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4027);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4027();
            return retKeyDict;
        }
        /// <summary>
        /// 借记卡客户信息验证接口[400101]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_400101">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult DebitCardCustomerInfoVerificationInterface(string serialNumber, Req_400101 req_400101, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "400101");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_400101);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_400101();
            return retKeyDict;
        }
        #endregion

        #region 第四章 直连交易明细下载
        /// <summary>
        /// 4.1 明细报表查询接口[F001]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_F001">请求参数</param>     
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult DetailReportQueryInterface(string serialNumber, Req_F001 req_F001, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "F001");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_F001);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_F001();
            return retKeyDict;
        }
        /// <summary>
        /// 4.2 明细报表生成通知接口F002 
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_F002">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult DetailReportCreateNotifyInterface(string serialNumber, Req_F002 req_F002, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "F002");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_F002);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }

        #endregion

        #region 第五章 现金管理接口设计
        /// <summary>
        /// 定期账户信息查询[4021]       
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4021">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult FixedDepositAccountInfoQueryInterface(string serialNumber, Req_4021 req_4021, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4021");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4021);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4021();
                var list = new List<Result_4021>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.PageRecCount.ToInt(0) < model.TotalCount.ToInt(0)); i++)
                    {
                        //第一次查询送1，若有后续送上次返回最后一个存款顺序号SeqNo+1
                        if (model.list.Count > 0) req_4021.PageNo = model.list[model.list.Count - 1].SeqNo.ToInt(0) + 1;
                        //延时
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = FixedDepositAccountInfoQueryInterface(serialNumber, req_4021, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 查询定活通存单信息[4025]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4025">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult QueryLiveComReceiptInfoInterface(string serialNumber, Req_4025 req_4025, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4025");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4025);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4025();
                var list = new List<Result_4025>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.Q10_END_FLG == "N"); i++)
                    {
                        //第一次查询送1，后续分页送前一次返回的起始存单序号Q10-STR-SEQNO
                        if (model.list.Count > 0) req_4025.ACSEQ = model.Q10_STR_SEQNO;
                        //延时
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = QueryLiveComReceiptInfoInterface(serialNumber, req_4025, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 集团内账户预结息/结息 (4054)
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4054">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult WithinGroupAccountPreKnotInterface(string serialNumber, Req_4054 req_4054, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4054");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4054);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4054();
            return retKeyDict;
        }
        /// <summary>
        ///  现金管理虚帐户合约建立/修改/删除(4058)
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4058">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult MoneyManageVirtualAccountContractAddOrUpdateOrDelInterface(string serialNumber, Req_4058 req_4058, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4058");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4058);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4058();
            return retKeyDict;
        }
        /// <summary>
        /// 集团内手工归集下拨[4052]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4052">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult WithinGroupHandModeNotionalPoolDownPickInterface(string serialNumber, Req_4052 req_4052, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4052");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4052);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4052();
            return retKeyDict;
        }
        /// <summary>
        /// 集团内虚拟子账户余额调整[4057] 
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4057">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult WithinGroupVirtualAccountBalanceAdjustInterface(string serialNumber, Req_4057 req_4057, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4057");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4057);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4057();
            return retKeyDict;
        }

        /// <summary>
        /// 5.4.1 集团总账户查询[4022]     
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4022">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult WithinGroupTotalAccountQueryInterface(string serialNumber, Req_4022 req_4022, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4022");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4022);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4022();
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.2 集团子账户列表查询 [4023]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4023">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult WithinGroupSubAccountListQueryInterface(string serialNumber, Req_4023 req_4023, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4023");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4023);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4023();
                var list = new List<ResultChildAccount_4023>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.PAGE.ToUpper().Trim() == "Y"); i++)
                    {
                        //子账户使用上次查询的最后一次返回的子账户
                        if (model.list.Count > 0) req_4023.SUBAC = model.list[model.list.Count - 1].SUBAC;
                        //延时
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = WithinGroupSubAccountListQueryInterface(serialNumber, req_4023, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.3 现金管理合约查询[4055] 查询集团总账户及下辖子账户间现金管理合约信息      
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4055">请求参数</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult CashMangeContractQueryInterface(string serialNumber, Req_4055 req_4055, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4055");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4055);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4055();
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.4 台账记录查询[4024] 
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4024">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult LedgerRecordQueryInterface(string serialNumber, Req_4024 req_4024, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4024");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4024);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4024();
                var list = new List<Result_4024>();
                list.AddRange(model.list);
                #region 查询所有

                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.turnPageFlag.ToUpper().Trim() == "Y"); i++)
                    {
                        //使用上次查询的最后一条交易记录序号
                        if (model.list.Count > 0) req_4024.serialNo = model.serialNo;
                        //延时
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = LedgerRecordQueryInterface(serialNumber, req_4024, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }

                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.5 结息查询[4056]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4056">请求参数</param>
        /// <param name="isAll">是否一次查完所有数据 true是 false否</param>
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult JieXiQueryInterface(string serialNumber, Req_4056 req_4056, bool isAll = false, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4056");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4056);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000"))
            {
                var model = retKeyDict.ToModel<DynamicXml>().To_4056();
                var list = new List<Result_4056>();
                list.AddRange(model.list);
                #region 查询所有数据
                if (isAll)
                {
                    var pinganPayConfig = GlobalData.LoadPinganConfig();
                    //最大请求8次
                    int maxCount = 8;
                    for (int i = 0; (i < maxCount && model != null && model.list.Count > 0); i++)
                    {
                        //日志号
                        if (model.list.Count > 0) req_4056.HostSeqNo = model.list[model.list.Count - 1].HostSeqNo;
                        //延时
                        Thread.Sleep(pinganPayConfig.SleepTime);
                        var rs = JieXiQueryInterface(serialNumber, req_4056, false, counterId);
                        if (rs.Model != null)
                        {
                            model = rs.Model;
                            list.AddRange(model.list);
                        }
                    }
                }
                #endregion
                model.list = list;
                retKeyDict.Model = model;
            }
            return retKeyDict;
        }
        /// <summary>
        /// 5.4.6 现金管理子账户余额查询[4059]
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <param name="req_4059">请求参数</param>   
        /// <param name="counterId">操作员</param>
        /// <returns></returns>
        public DataResult CashMangeSubAccountBalanceQueryInterface(string serialNumber, Req_4059 req_4059, string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            //string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "4059");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //传递对象
            parmaKeyDict.Add("Model", req_4059);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            if (retKeyDict.RspCode.Equals("000000")) retKeyDict.Model = retKeyDict.ToModel<DynamicXml>().To_4059();
            return retKeyDict;
        }
        #endregion

        #region 第六章 票据接口设计
        /// <summary>
        /// DP00
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <returns></returns>
        public DataResult DP00_Interface(string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "DP00");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);

            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }
        #endregion

        #region 第七章 供应链接口
        /// <summary>
        /// SC00
        /// </summary>
        /// <param name="serialNumber">请求流水号</param>
        /// <returns></returns>
        public DataResult SC00_Interface(string counterId = "")
        {
            //用于存放生成请求报文的参数
            ExHashTable parmaKeyDict = new ExHashTable();
            //请求流水号
            string serialNumber = AssistantHelper.GetOrderId(6, "yyyyMMddHHmmss", "");
            //交易码
            parmaKeyDict.Add("TranFunc", "SC00");
            //请求流水号
            parmaKeyDict.Add("ThirdLogNo", serialNumber);
            //操作员号
            parmaKeyDict.Add("CounterId", counterId);
            //获取结果
            var retKeyDict = GetResult(parmaKeyDict);
            return retKeyDict;
        }
        #endregion


    }
}

